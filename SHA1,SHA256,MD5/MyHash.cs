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
using System.Numerics;

namespace SHA1_SHA256_MD5
{
    public class MyHash
    {
        public string MyMD5(byte[] array)
        {
            //Inicijalizacija
            List<byte> modmessage = new List<byte>(array);
            List<uint> imessage = new List<uint>(); ;
            AppendPadd(modmessage);
            //Dijelimo u riječi 32 bita
            imessage.AddRange(ConvertByteListToUintList(modmessage));          
            //Inicijalizacija konstanti A, B, C, D
            uint a0 = 0x67452301;
            uint b0 = 0xefcdab89;
            uint c0 = 0x98badcfe;
            uint d0 = 0x10325476;
            //inicijalizacija konstanti K
            List<uint> K = new List<uint>();
            for(int i = 0; i < 64; ++i)
            {
                K.Add((uint)Math.Floor(Math.Pow(2, 32) * Math.Abs(Math.Sin(i + 1))));
            }
            //Lista pomaka po rundi
            int[] s = { 7, 12, 17, 22,  7, 12, 17, 22,  7, 12, 17, 22,  7, 12, 17, 22,  //runde 1-16
                        5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,  //runde 17-32
                        4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,  //runde 33 48
                        6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21 };//runde 49-64

            //Vraća hash
            return RoundsMD5(a0, b0, c0, d0, K, s, imessage);
        }            

        //Obrađuje cijelu poruku i vraća hash u obiku stringa
        private string RoundsMD5(uint a0, uint b0, uint c0, uint d0, List<uint> K, int[] s, List<uint> imessage)
        {
            //Blok od 512 bita reprezentira 32 bitne riječi Mi
            List<uint> mblock = new List<uint>(ExtractBlock(imessage));
            //Glavna funkcija
            int i;
            uint F = 0;
            int j = 0;
            uint A = a0;
            uint B = b0;
            uint C = c0;
            uint D = d0;

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
                else if (i >= 32 && i <= 47)
                {
                    F = B ^ C ^ D;
                    j = (((3 * i) + 5) % 16);
                }
                else if (i >= 48 && i <= 63)
                {
                    F = C ^ (B | (~D));
                    j = ((7 * i) % 16);
                }

                F = F + A + K[i] + mblock[j];
                A = D;
                D = C;
                C = B;
                B += RotateLeft(F, s[i]);
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
            else return RoundsMD5(a0, b0, c0, d0, K, s, imessage);
        }
      
        public string MySHA1(byte[] array)
        {
            //Inicijalizacija
            List<byte> modmessage = new List<byte>(array);
            List<uint> imessage = new List<uint>();;
            AppendPadd(modmessage);
            //Dijelimo u riječi 32 bita
            imessage.AddRange(ConvertByteListToUintList(modmessage));
            //Inicijalizacija konstanti A, B, C, D, E
            uint a0 = 0x67452301;
            uint b0 = 0xefcdab89;
            uint c0 = 0x98badcfe;
            uint d0 = 0x10325476;
            uint e0 = 0xc3d2e1f0;
            //Vraća hash
            return RoundsSHA1(a0, b0, c0, d0, e0, imessage);
        }

        private string RoundsSHA1(uint a0, uint b0, uint c0, uint d0, uint e0, List<uint> imessage)
        {
            //Blok od 512 bita
            List<uint> mblock = new List<uint>(ExtractBlock(imessage));
            //Proširiti blok sa 16 riječi na 80
            for (int i = 16; i < 80; ++i)
            {
                mblock.Add(RotateLeft(mblock[i - 3] ^ mblock[i - 8] ^ mblock[i - 14] ^ mblock[i - 16], 1));
            }
            //Glavna funkcija
            uint A = a0;
            uint B = b0;
            uint C = c0;
            uint D = d0;
            uint E = e0;
            uint F = 0;
            uint k = 0;

            for (int i = 0; i < 80; ++i)
            {
                if (i >= 0 && i <= 19)//moguća optimizacija, zamijeniti pozicije uvjeta
                {
                    F = (B & C) | ((~B) & D);
                    k = 0x5A827999;
                }
                else if (i >= 20 && i <= 39)
                {
                    F = B ^ C ^ D;
                    k = 0x6ED9EBA1;
                }
                else if (i >= 40 && i <= 59)
                {
                    F = (B & C) | (B & D) | (C & D);
                    k = 0x8F1BBCDC;
                }
                else if (i >= 60 && i <= 79)
                {
                    F = B ^ C ^ D;
                    k = 0xCA62C1D6;
                }

                uint temp = RotateLeft(A, 5) + F + E + k + mblock[i];
                E = D;
                D = C;
                C = RotateLeft(B, 30);
                B = A;
                A = temp;
            }

            a0 += A;
            b0 += B;
            c0 += C;
            d0 += D;
            e0 += E;

            if (imessage.Count == 0)
            {
                List<byte> digest = new List<byte>();
                digest.AddRange(BitConverter.GetBytes(a0));
                digest.AddRange(BitConverter.GetBytes(b0));
                digest.AddRange(BitConverter.GetBytes(c0));
                digest.AddRange(BitConverter.GetBytes(d0));
                digest.AddRange(BitConverter.GetBytes(e0));
                string fdigest = ConvertByteArrayToString(digest.ToArray());
                return fdigest;//promijeniti direktno return nakon debugiranja            
            }
            //Vraća hash
            return RoundsSHA1(a0, b0, c0, d0, e0, imessage);
        }

        public string MySHA256(byte[] array)
        {
            //Inicijalizacija
            List<byte> modmessage = new List<byte>(array);
            List<uint> imessage = new List<uint>(); ;
            AppendPadd(modmessage);
            //Dijelimo u riječi 32 bita
            imessage.AddRange(ConvertByteListToUintList(modmessage));  
            //Inicijalizacija konstanti A, B, C, D, E, F, G, H
            uint a0 = 0x6a09e667;
            uint b0 = 0xbb67ae85;
            uint c0 = 0x3c6ef372;
            uint d0 = 0xa54ff53a;
            uint e0 = 0x510e527f;
            uint f0 = 0x9b05688c;
            uint g0 = 0x1f83d9ab;
            uint h0 = 0x5be0cd19;
            //Inicijalizacija konstante k
            List<uint> K = new List<uint>();
            List<int> prime = PrimeNumbers(64);
            //Uzimamo prva 32 bita frakcijskog djela 3. korijenna primarnih brojeva (2 do 311)
            foreach(int i in prime)
            {
                double a = Math.Pow(i, (1/3.0));
                K.Add((uint)(Math.Truncate((a - Math.Truncate(a)) * Math.Pow(10, 8))));
            }
            //Vraća hash
            return RoundsSHA256(a0, b0, c0, d0, e0, f0, g0, h0, K, imessage);
        }

        private string RoundsSHA256(uint a0, uint b0, uint c0, uint d0, uint e0, uint f0, uint g0, uint h0, List<uint> K, List<uint> imessage)
        {
            //Blok od 512 bita
            List<uint> mblock = new List<uint>(ExtractBlock(imessage));
            //Dodajemo 64 riječi w od 32 bita, početna vrijednost nebitna slobodno 0
            //Proširiti blok sa 16 na 80
            for (int i = 16; i < 64; ++i)
            {
                uint s0 = (RotateRight(mblock[i - 15], 7)) ^ (RotateRight(mblock[i - 15], 18)) ^ (mblock[i - 15] >> 3);
                uint s1 = RotateRight(mblock[i - 2], 17) ^ RotateRight(mblock[i - 2], 19) ^ (mblock[i - 2] >> 10);
                mblock.Add(mblock[i - 16] + s0 + mblock[i - 7] + s1);
            }
            //Glavna funkcija
            uint A = a0;
            uint B = b0;
            uint C = c0;
            uint D = d0;
            uint E = e0;
            uint F = f0;
            uint G = g0;
            uint H = h0;

            for (int i = 0; i < 64; ++i)
            {
                uint s1 = RotateRight(E, 6) ^ RotateRight(E, 11) ^ RotateRight(E, 25);
                uint Ch = (E & F) ^ ((~E) & G);
                uint temp0 = H + s1 + Ch + K[i] + mblock[i];
                uint s0 = RotateRight(A, 2) ^ RotateRight(A, 13) ^ RotateRight(A, 22);
                uint Ma = (A & B) ^ (A & C) ^ (B & C);
                uint temp1 = s0 + Ma;

                H = G;
                G = F;
                F = E;
                E = D + temp0;
                D = C;
                C = B;
                B = A;
                A = temp0 + temp1;
            }

            a0 += A;
            b0 += B;
            c0 += C;
            d0 += D;
            e0 += E;
            f0 += F;
            g0 += G;
            h0 += H;

            if (imessage.Count == 0)
            {
                List<byte> digest = new List<byte>();
                digest.AddRange(BitConverter.GetBytes(a0));
                digest.AddRange(BitConverter.GetBytes(b0));
                digest.AddRange(BitConverter.GetBytes(c0));
                digest.AddRange(BitConverter.GetBytes(d0));
                digest.AddRange(BitConverter.GetBytes(e0));
                digest.AddRange(BitConverter.GetBytes(f0));
                digest.AddRange(BitConverter.GetBytes(g0));
                digest.AddRange(BitConverter.GetBytes(h0));
                string fdigest = ConvertByteArrayToString(digest.ToArray());
                return fdigest;//promijeniti direktno return nakon debugiranja            
            }
            //Vraća hash
            return RoundsSHA256(a0, b0, c0, d0, e0, f0, g0, h0, K, imessage);
            // Console.WriteLine(hash.ToString());
        }

        //dodaje padding i veličinu originalne poruke
        private void AppendPadd(List<byte> modmessage)
        {
            //Duljina poruke u bitovima 64 bita
            long ml = modmessage.Count() * 8;
            //appendanje paddinga
            modmessage.Add(0x80);
            long paddsize = Math.Abs(((ml + 1) % 512) - 448) / 8;//ostavljamo mjesta za zadnja 64 bita
            while (paddsize > 0) //popunjavamo nule
            {
                modmessage.Add(0x00);
                --paddsize;
            }
            modmessage.AddRange(BitConverter.GetBytes(ml));
        }

        //Podijeliti poruku na blokove od 512 bita/ 64 bytea
        private List<uint> ExtractBlock(List<uint> imessage)
        {
            List<uint> block = new List<uint>();
            block.AddRange(imessage.GetRange(0, 16));
            imessage.RemoveRange(0, 16);
            return block;
        }

        public static uint RotateLeft(uint value, int count)
        {
            return (value << count) | (value >> (32 - count));
        }

        public static uint RotateRight(uint value, int count)
        {
            return (value >> count) | (value << (32 - count));
        }

        //Vraća listu primarnih brojeva
        private List<int> PrimeNumbers(int a)
        {
            List<int> prime = new List<int>();
            for (int i = 2, number = 2;  prime.Count < a;)
            {
                if (number % i  == 0 && number > i)
                {
                    ++number;
                    i = 2;
                    continue;
                }
                else if (number % i == 0  && (i >= number / 3))
                {
                    prime.Add(number++);
                    i = 2;
                }
                else
                    ++i;
            }
            return prime;
        }


        private List<uint> ConvertByteListToUintList(List<byte> modmessage)
        {
            List<uint> uimessage = new List<uint>();
            List<byte> bmessage = new List<byte>();
            bmessage.AddRange(modmessage);
            while (bmessage.Count > 0)
            {
                uimessage.Add((uint)((((((bmessage[0] << 8) | bmessage[1]) << 8) | bmessage[2]) << 8) | bmessage[3]));
                bmessage.RemoveRange(0, 4);
            }
            return uimessage;
        }

        string ConvertByteArrayToString(byte[] array)
        {
            return BitConverter.ToString(array).Replace("-", "").ToLower();
        }
    }
}