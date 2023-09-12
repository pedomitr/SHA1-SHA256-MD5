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
        //provjeriti duljinu poruke u bitovima i modulo 512
        private void MyMD5(string text)
        {
            //inicijalizacija
            string message = "";
            string hash;
            byte[] bitmessage;
            List<uint> mblock = new List<uint>();
            List<byte> modmessage= new List<byte>();
            bitmessage = ConvertStringToByteArray(message);
            modmessage.AddRange(bitmessage);
            int paddsize = Paddlength(bitmessage);//proslijediti direktno u funkciju
            //appendanje
            AppendPadd(modmessage, paddsize, bitmessage.Length);
            //Konverzija u int list
            List<uint> imessage = new List<uint>();
            imessage.AddRange(ConvertByteListToIntList(modmessage));
            //blok od 512 bita
            mblock.AddRange(ExtractBlock(imessage));
            //inicijalizacija konstanti A, B, C, D
            uint A = 0x67452301;
            uint B = 0xefcdab89;
            uint C = 0x98badcfe;
            uint D = 0x10325476;
            //inicijalizacija konstanti K
            List<uint> K = new List<uint>();
            for(int i = 0; i < 64; ++i)
            {
                K.Add((uint)Math.Floor(232 * Math.Abs(Math.Sin(i + 1))));
            }
            //Lista pomaka po rundi
           // List<uint> s = new List<uint>(); //array je ovdje možda bolji
            uint[] s = { 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22,      //runde 1-16
                          5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,    //runde 17-32
                          4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,    //runde 33 48
                          6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21 };  //runde 49-64
            //Pozvati prvi set rundi 1-16

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

        //TO DO
        //Podijeliti poruku na blokove od 512 bita/ 64 bytea
        private List<uint> ExtractBlock(List<uint> imessage)
        {
            List<uint> block = new List<uint>();
            block.AddRange(imessage.GetRange(0, 16));
            imessage.RemoveRange(0, 64);
            return block;
        }
        //Proslijediti blok kroz runde
        private List<byte> MD5F1(byte[] F1, byte[] A, byte[] B, byte[] C, byte[] D)
        {
            List<byte> result = new List<byte>();
            //byte result;
            for (int i = 0; i < A.Length; ++i)
            {
                result.Add((byte)((B[i] & C[i]) | ((~B[i]) & D[i])));
            }
            return result;
        }

        //Postavlja vrijednosti A,B,C,D
        private void SetABCD(List<byte> sblock, List<byte> A, List<byte> B, List<byte> C, List<byte> D)
        {
            A.Clear();
            B.Clear();
            C.Clear();
            D.Clear();
            A.AddRange(sblock.GetRange(0, 4));
            B.AddRange(sblock.GetRange(4, 4));
            C.AddRange(sblock.GetRange(8, 4));
            D.AddRange(sblock.GetRange(12, 4));
        }

        private void MySHA1()
        {

        }

        private void MySHA256()
        {

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
    }
}