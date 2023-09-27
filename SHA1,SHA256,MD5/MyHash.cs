using System;
using System.Collections.Generic;
using System.Linq;

namespace SHA1_SHA256_MD5
{
    public class MyHash
    {
        public string MyMD5(byte[] array)
        {
            //Inicijalizacija
            List<byte> modmessage = new List<byte>(array);
            List<uint> imessage = new List<uint>();
            AppendPadd(modmessage, true);// LE = true
            //Dijelimo u riječi 32 bita
            imessage.AddRange(ConvertByteListToUintList(modmessage));
            //Inicijalizacija konstanti A, B, C, D
            uint[] h = { 0x67452301, 0xefcdab89, 0x98badcfe, 0x10325476 };
            //Inicijalizacija konstanti K
            List<uint> K = new List<uint>();
            for(int i = 0; i < 64; ++i)
            {
                K.Add((uint)Math.Floor(Math.Pow(2, 32) * Math.Abs(Math.Sin(i + 1.0))));
            }
            //Lista pomaka po rundi
            int[] s = { 7, 12, 17, 22,  7, 12, 17, 22,  7, 12, 17, 22,  7, 12, 17, 22,  //runde 1-16
                        5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,  //runde 17-32
                        4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,  //runde 33-48
                        6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21 };//runde 49-64

            //Vraća hash
            while (RoundsMD5(0, ref h, K, s, imessage));
            string mdigest = MessageDigest(h, true);
            return mdigest;
        }            

        //Obrađuje cijelu poruku i vraća hash u obiku stringa
        private bool RoundsMD5(int stack, ref uint[] h, List<uint> K, int[] s, List<uint> imessage)
        {
            //Blok od 512 bita reprezentira 32 bitne riječi Mi
            List<uint> mblock = new List<uint>(ExtractBlock(imessage, true));// LE = true
            //Glavna funkcija 
            uint A = h[0];
            uint B = h[1];
            uint C = h[2];
            uint D = h[3];

            for ( int i= 0,j = 0; i < 64; ++i)
            {               
                uint F = 0;
                if( i >= 0 && i <= 15)
                {
                    F = (B & C) | ((~B) & D);
                    j = i;
                }
                else if (i >= 16 && i <= 31)
                {
                    F = (D & B) | ((~D) & C);
                    j = ((5 * i) + 1) % 16;
                }
                else if (i >= 32 && i <= 47)
                {
                    F = B ^ C ^ D;
                    j = ((3 * i) + 5) % 16;
                }
                else if (i >= 48 && i <= 63)
                {
                    F = C ^ (B | (~D));
                    j = (7 * i) % 16;
                }

                uint tempA = A;
                A = D;
                D = C;
                C = B;
                B = RotateLeft(F + tempA + mblock[j] + K[i], s[i]) + B;
            }
            h[0] += A;
            h[1] += B;
            h[2] += C;
            h[3] += D;

            if (imessage.Count == 0)                                   
                return false;//imessage prazan            
            if (stack >= 100)
                return true;
            ++stack;
            return RoundsMD5(stack, ref h, K, s, imessage);// a dodan radi debugiranja
        }
      
        public string MySHA1(byte[] array)
        {
            //Inicijalizacija
            List<byte> modmessage = new List<byte>(array);
            List<uint> imessage = new List<uint>();;
            //Dijelimo u riječi 32 bita
            AppendPadd(modmessage, false);//BE = false
            imessage.AddRange(ConvertByteListToUintList(modmessage));
            //Inicijalizacija konstanti A, B, C, D, E
            uint[] h = { 0x67452301, 0xefcdab89, 0x98badcfe, 0x10325476, 0xc3d2e1f0 };
            //Vraća hash
            while (RoundsSHA1(0, ref h, imessage)) ;
            string mdigest = MessageDigest(h, false);
            return mdigest;
        }

        private bool RoundsSHA1(int stack, ref uint[] h, List<uint> imessage)
        {
            //Blok od 512 bita
            List<uint> mblock = new List<uint>(ExtractBlock(imessage, false));// BE = false
            //Proširiti blok sa 16 riječi na 80
            for (int i = 16; i < 80; ++i)
            {
                mblock.Add(RotateLeft(mblock[i - 3] ^ mblock[i - 8] ^ mblock[i - 14] ^ mblock[i - 16], 1));
            }
            //Glavna funkcija
            uint A = h[0];
            uint B = h[1];
            uint C = h[2];
            uint D = h[3];
            uint E = h[4];
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

            h[0] += A;
            h[1] += B;
            h[2] += C;
            h[3] += D;
            h[4] += E;

            if (imessage.Count == 0)
                return false;//imessage prazan            
            if (stack >= 100)
                return true;
            ++stack;
            //Vraća hash
            return RoundsSHA1(stack, ref h, imessage);
        }

        public string MySHA256(byte[] array)
        {
            //Inicijalizacija
            List<byte> modmessage = new List<byte>(array);
            List<uint> imessage = new List<uint>(); ;
            AppendPadd(modmessage, false);// BE = false
            //Dijelimo u riječi 32 bita
            imessage.AddRange(ConvertByteListToUintList(modmessage));  
            //Inicijalizacija konstanti A, B, C, D, E, F, G, H
            uint[] h = { 0x6a09e667, 0xbb67ae85, 0x3c6ef372, 0xa54ff53a, 
                         0x510e527f, 0x9b05688c, 0x1f83d9ab, 0x5be0cd19 };
            //Inicijalizacija konstante k
            List<uint> K = new List<uint>();
            List<int> prime = PrimeNumbers(64);
            //Uzimamo prva 32 bita frakcijskog djela 3. korijenna primarnih brojeva (2 do 311)
            foreach(int i in prime)
            {
                double a = Math.Pow(i, (1/3.0));
                K.Add((uint)(Math.Truncate((a - Math.Truncate(a)) * Math.Pow(2, 32))));
            }
            //Vraća hash
            while (RoundsSHA256(0, ref h, K, imessage));
            string mdigest = MessageDigest(h, false);
            return mdigest;
        }

        private bool RoundsSHA256(int stack, ref uint[] h, List<uint> K, List<uint> imessage)
        {
            //Blok od 512 bita
            List<uint> mblock = new List<uint>(ExtractBlock(imessage, false));// BE = false
            //Dodajemo 64 riječi w od 32 bita, početna vrijednost nebitna slobodno 0
            //Proširiti blok sa 16 na 64
            for (int i = 16; i < 64; ++i)
            {
                uint s0 = RotateRight(mblock[i - 15], 7) ^ RotateRight(mblock[i - 15], 18) ^ mblock[i - 15] >> 3;
                uint s1 = RotateRight(mblock[i - 2], 17) ^ RotateRight(mblock[i - 2], 19) ^ mblock[i - 2] >> 10;
                mblock.Add(mblock[i - 16] + s0 + mblock[i - 7] + s1);
            }
            //Glavna funkcija
            uint A = h[0];
            uint B = h[1];
            uint C = h[2];
            uint D = h[3];
            uint E = h[4];
            uint F = h[5];
            uint G = h[6];
            uint H = h[7];

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

            h[0] += A;
            h[1] += B;
            h[2] += C;
            h[3] += D;
            h[4] += E;
            h[5] += F;
            h[6] += G;
            h[7] += H;

            if (imessage.Count == 0)
                return false;//imessage prazan            
            if (stack >= 100)
                return true;
            ++stack;

            //Vraća hash
            return RoundsSHA256(stack, ref h, K, imessage);
        }

        //Dodaje padding i veličinu originalne poruke
        private void AppendPadd(List<byte> modmessage, bool le)
        {
            //Duljina poruke u bitovima 64 bita
            long ml = modmessage.Count * 8;
            //appendanje paddinga
            modmessage.Add(0x80);
            long paddsize;
            long padd = (ml + 8) % 512;
            if (padd > 448)
                paddsize = (512 - padd + 448) / 8;//ostavljamo mjesta za zadnja 64 bita
            else
                paddsize = (448 - padd) / 8;

            while (paddsize > 0) //popunjavamo nule
            {
                modmessage.Add(0x00);
                --paddsize;
            }
            if(BitConverter.IsLittleEndian && le)
                modmessage.AddRange(BitConverter.GetBytes(ml));
            else 
                modmessage.AddRange(SwitchEndianness(BitConverter.GetBytes(ml)));
        }

        //Podijeliti poruku na blokove od 512 bita/ 64 bytea
        private List<uint> ExtractBlock(List<uint> imessage, bool le)
        {
            List<uint> block = new List<uint>();
            //Prebacuje riječi(uint) u LE
            if (le)
            {
                for(int i = 0; i < 16; ++i)
                {
                    block.Add(BitConverter.ToUInt32(SwitchEndianness((BitConverter.GetBytes(imessage[i]))), 0));
                }
            }
            else
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
            while (modmessage.Count > 3)//privremeno rješenje kada je prevelik podatak
            {
                uimessage.Add((uint)((((((modmessage[0] << 8) | modmessage[1]) << 8) | modmessage[2]) << 8) | modmessage[3]));
                modmessage.RemoveRange(0, 4);
            }
            return uimessage;
        }

        //Uzima array koji je LE i pretvara ga u BE i obrnuto, implementirano za Uint
        private byte[] SwitchEndianness(byte[] le)
        {
            int i = le.Length;
            byte[] be = new byte[i];
            foreach(byte b in le)
            {
                be[(i--) - 1] = b;
                if (i == 0) break;
            }
            return be;
        }

        //Spaja članove u poruku odnosno hash u obliku stringa
        private string MessageDigest(uint[] digest, bool le)
        {
            string fdigest = "";
            if (le) 
                foreach (uint member in digest)
                        fdigest += ConvertByteArrayToString(BitConverter.GetBytes(member));
            else
                foreach (uint member in digest)
                    fdigest += ConvertByteArrayToString(SwitchEndianness(BitConverter.GetBytes(member)));
            return fdigest;
        }

        string ConvertByteArrayToString(byte[] array)
        {
            return BitConverter.ToString(array).Replace("-", "").ToLower();
        }
    }
}