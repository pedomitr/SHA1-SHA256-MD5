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
            List<byte> mblock = new List<byte>();
            List<byte> modmessage= new List<byte>();
            bitmessage = ConvertStringToByteArray(message);
            modmessage.AddRange(bitmessage);
            int paddsize = Paddlength(bitmessage);//proslijediti direktno u funkciju
            //appendanje
            AppendPadd(modmessage, paddsize, bitmessage.Length);
            //blok od 512 bita
            mblock.AddRange(ExtractBlock(modmessage));
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
        private List<byte> ExtractBlock(List<byte> modmessage)
        {
            List<byte> block = new List<byte>();
            block.AddRange(modmessage.GetRange(0, 64));
            modmessage.RemoveRange(0, 64);
            return block;
        }
        //Proslijediti blok kroz runde
        private void MD5F1(byte[] F1, byte[] A, byte[] B, byte[] C, byte[] D)
        {
            List<byte> result = new List<byte>();
            //byte result;
            for (int i = 0; i < A.Length; ++i)
            {
                var opA = new BinaryOperator(A[i]);
                var opB = new BinaryOperator(B[i]);
                var opC = new BinaryOperator(C[i]);
                var opD = new BinaryOperator(D[i]);
                result.Add((byte)((opB.opA & opC.opA) | ((~opB.opA) & opD.opA)));
            }
        }

        
       // public static MyHash operator | (MyHash a, MyHash b)
           // => new  MyHash()

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
    }
}