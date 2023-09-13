﻿using System;
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
        public string MyMD5(byte[] array)
        {
            //inicijalizacija
            List<byte> modmessage= new List<byte>();
            modmessage.AddRange(array);
            //appendanje paddinga
            AppendPadd(modmessage);
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
            uint[] s = { 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22,        //runde 1-16
                          5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,    //runde 17-32
                          4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,    //runde 33 48
                          6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21 };  //runde 49-64
            //Podijeliti poruku u 32 bitne riječi Mi
                //mblock lista sadržava 16 članova koji predstavljaju Mi,
                //ne zaboraviti refrešanje mblocka nakon rundi
            //Vraća hash
            return Rounds(a0, b0, c0, d0, K, s, imessage);
           // Console.WriteLine(hash.ToString());
        }

        //dodaje padding i veličinu originalne poruke
        private void AppendPadd(List<byte> modmessage)
        {           
            //Sprema duljinu originalne poruke u 64 bita
            List<byte> osize = new List<byte>(BitConverter.GetBytes((Int64)(modmessage.Count << 32)));
            modmessage.Add(255);// appendamo 1, 8 bita
            int paddsize = 64 - ((modmessage.Count * 8 % 512)/8); //prostor za padding do 64 bytea         
            if (paddsize < 8) paddsize = paddsize % 8 + 64;//dodajemo mjesta tako da duljina je poruke %512 bita
            while (paddsize - 8 > 0) //ostavljamo mjesta za zadnja 64 bita/8 bytea i popunjavamo nule
            {
                modmessage.Add(0);
                --paddsize;
            }                    
            modmessage.AddRange(osize);//dodajemo veličinu originalne poruke,  64 bita
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

            if (imessage.Count == 0)
            {
                List<byte> digest = new List<byte>();
                digest.AddRange(BitConverter.GetBytes(a0));
                digest.AddRange(BitConverter.GetBytes(b0));
                digest.AddRange(BitConverter.GetBytes(c0));
                digest.AddRange(BitConverter.GetBytes(d0));
                string fdigest = ConvertByteArrayToString(digest.ToArray()); 
               return fdigest;//promijeniti direktno return nakon debugiranja            
            }
            else return Rounds(a0, b0, c0, d0, K, s, imessage);
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
            List<uint> uimessage = new List<uint>();
            List<byte> bmessage = new List<byte>();
            bmessage.AddRange(modmessage);//kasnije direktno koristiti modmessage zasad kopiramo !!!
            while ( bmessage.Count > 0)
            {
                uimessage.Add((uint)((((((bmessage[0] << 8) | bmessage[1]) << 8) | bmessage[2]) << 8) | bmessage[3]));
                bmessage.RemoveRange(0, 4);
            }
            return uimessage;           
        }
        private void MySHA1()
        {

        }

        private void MySHA256()
        {

        }
    }
}