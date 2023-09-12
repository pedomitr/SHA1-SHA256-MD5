using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SHA1_SHA256_MD5
{
    public class MyHash
    {
        //TO DO dodati overload za unos iz text boxa i iz Dialoga
        //pseudocode: string uzima direktno i poziva MyMD5, a stream prvo pretvara u string pa poziva MyMD5
        private void MyMD5(string text)
        {
            //inicijalizacija
            string message = "";
            string hash;
            byte[] bitmessage;
            List<byte> modmessage= new List<byte>();
            bitmessage = ConvertStringToByteArray(message);//proslijediti text ili stream
            modmessage.AddRange(bitmessage);
            //appendanje paddinga
            AppendPadd(modmessage, Paddlength(bitmessage), bitmessage.Length);
            //Konverzija u uint list
            List<uint> imessage = new List<uint>();
            imessage.AddRange(ConvertByteListToIntList(modmessage));
            //blok od 512 bita
            //inicijalizacija konstanti A, B, C, D
            uint a0 = 0x67452301;
            uint b0 = 0xefcdab89;
            uint c0 = 0x98badcfe;
            uint d0 = 0x10325476;
            //inicijalizacija konstanti K
            List<uint> K = new List<uint>();
            for(int i = 0; i < 64; ++i)
            {
                K.Add((uint)Math.Floor(232 * Math.Abs(Math.Sin(i + 1))));
            }
            //Lista pomaka po rundi
           // List<uint> s = new List<uint>(); //array je ovdje možda bolji
            uint[] s = { 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22,        //runde 1-16
                          5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,    //runde 17-32
                          4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,    //runde 33 48
                          6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21 };  //runde 49-64
            //Podijeliti poruku u 32 bitne riječi Mi
                //mblock lista sadržava 16 članova koji predstavljaju Mi,
                //ne zaboraviti refrešanje mblocka nakon rundi
            //Pozvati prvi set rundi 1-16
            hash = Rounds(a0, b0, c0, d0, K, s, imessage);
            Console.WriteLine(hash);
        }

        //vraća podatak koliko je paddinga potrebno u bitovima + 64 bita za spremanje duljine originalne poruke
        private int Paddlength(byte[] bitmessage)
        {
            int paddinglength = (bitmessage.Length * 8) % 512;
            if (paddinglength < (512 - (64 + 8))) return (paddinglength + 512)/8;//64 +1 po algoritmu, nam definira logični minimum od 8 bitova pa to koristimo
            return paddinglength/8;// dijelimo sa 8 pošto računamo sa byte moguća nepreciznost!!!
        }

        //dodaje padding i veličinu originalne poruke
        private void AppendPadd(List<byte> modmessage, int paddsize, int leng)
        {
            //minimalna veličina padinga je 65(teoretski zapravo 72 pošto pretvramo sa UTF8, a max 
            //dodamo prvo 1 i sedam 0 pošto je to minimum u ovom sustavu
            modmessage.Add(128);
            while(paddsize-8 > 0)
            {
                modmessage.Add(0);
            }
            List<byte> osize = new List<byte>();//broj 0 od 64 bita za veličinu poruke
            osize.Append((byte)(8 * leng));
            //populira ostatak veličine poruke nulama dok se ne ispune sva 64 bita
            while(osize.Count < 8)
            {
                osize.Insert(0, 0);               
            }
            //dodajemo veličinu originalne poruke           
            modmessage.Concat(osize);
        }

        //Podijeliti poruku na blokove od 512 bita/ 64 bytea
        private List<uint> ExtractBlock(List<uint> imessage)
        {
            List<uint> block = new List<uint>();
            block.AddRange(imessage.GetRange(0, 16));
            imessage.RemoveRange(0, 16);
            return block;
        }

        //Obrađuje cijelu poruku i vraća hash u obiku stringa
        private string Rounds(uint a0, uint b0, uint c0, uint d0, List<uint> K, uint[] s, List<uint> imessage)
        {
            int i;
            uint F = 0;
            int j = 0;
            uint A = a0;
            uint B = b0;
            uint C = c0;
            uint D = d0;
            List<uint> mblock = new List<uint>();
            mblock.AddRange(ExtractBlock(imessage));
            for (i = 0; i < 64; ++i)
            {
                if( i >= 0 && i <= 15)
                {
                    F = (B & C) | ((~B) & D);
                    j = i;
                }
                else if (i >= 16 && i <= 31)
                {
                    F = (B & D) | (C & (~D));
                    j = (((5 * i) + 1) % 16);
                }
                else if (i >= 16 && i <= 31)
                {
                    F = B ^ C ^ D;
                    j = (((3 * i) + 5) % 16);
                }
                else if (i >= 16 && i <= 31)
                {
                    F = C ^ (B | (~D));
                    j = ((7 * i) % 16);
                }

                F = F + A + K[i] + mblock[j];
                A = D;
                D = C;
                C = B;
                B = (uint)(B + ((int)F << (int)s[i]));
            }

            a0 += A;
            b0 += B;
            c0 += C;
            d0 += D;

            if (imessage.Count > 0) Rounds(a0, b0, c0, d0, K, s, imessage);
            else
            {
                List<byte> digest = new List<byte>();
                digest.AddRange(BitConverter.GetBytes(a0));
                digest.AddRange(BitConverter.GetBytes(b0));
                digest.AddRange(BitConverter.GetBytes(c0));
                digest.AddRange(BitConverter.GetBytes(d0));
                return ConvertByteArrayToString(digest.ToArray());
            }
            return "Hash not found";
            //Dodati rekurziju koja obavlja runde dok se ne obradi cijela poruka,
            //Za veće poruke rekurzija može biti prezahtjevna??
        }

        byte[] ConvertStringToByteArray(string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }

        string ConvertByteArrayToString(byte[] array)
        {
            return BitConverter.ToString(array).Replace("-", "").ToLower();
        }

        private List<uint> ConvertByteListToIntList(List<byte> modmessage)
        {
            List<uint> imessage = new List<uint>();
            List<byte> bmessage = new List<byte>();
            bmessage.AddRange(modmessage);//kasnije direktno koristiti modmessage zasad kopiramo !!!
            while ( bmessage.Count > 0)
            {
                imessage.Add((uint)(bmessage[0] | bmessage[1] | bmessage[2] | bmessage[3]));
                bmessage.RemoveRange(0, 4);
            }
            return imessage;           
        }
        private void MySHA1()
        {

        }

        private void MySHA256()
        {

        }
    }
}