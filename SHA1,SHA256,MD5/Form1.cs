using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace SHA1_SHA256_MD5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Odabir datoteke za hashiranje i istovremena obrada
        private void buttonDatoteka_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Odaberite datoteku";
            open.Filter = "Text Files (*txt)|*txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBoxDatoteka.Text = open.SafeFileName;
                //Hashiranje
                SHA1(File.ReadAllBytes(open.FileName));
                SHA256(File.ReadAllBytes(open.FileName));
                MD5(File.ReadAllBytes(open.FileName));
                MD5me(File.ReadAllBytes(open.FileName));
                SHA1me(File.ReadAllBytes(open.FileName));
                SHA256me(File.ReadAllBytes(open.FileName));
            }
        }

        //Hash metode
        private void SHA1(byte[] array)
        {
            var hashSHA1 = new SHA1Cng();          
            textBoxSHA1.Text = ConvertByteArrayToString(hashSHA1.ComputeHash(array));
            hashSHA1.Clear();
        }

        private void SHA256(byte[] array)
        {
            var hashSHA256 = new SHA256Cng();
            textBoxSHA256.Text = ConvertByteArrayToString(hashSHA256.ComputeHash(array));
            hashSHA256.Clear();
        }

        private void MD5(byte[] array)
        {
            var hashMD5 = new MD5Cng();
            textBoxMD5.Text = ConvertByteArrayToString(hashMD5.ComputeHash(array));
            hashMD5.Clear();
        }
        private void MD5me(byte[] array)
        {
            var hashMD5me = new MyHash();
            textBoxMD5me.Text = hashMD5me.MyMD5(array);
            //hashMD5.Clear();
        }

        private void SHA1me(byte[] array)
        {
            var hashSHA1me = new MyHash();
            textBoxMD5me.Text = hashSHA1me.MySHA1(array);
            //hashMD5.Clear();
        }

        private void SHA256me(byte[] array)
        {
            var hashSHA256me = new MyHash();
            textBoxMD5me.Text = hashSHA256me.MySHA256(array);
            //hashMD5.Clear();
        }

        //Gumbi koji pokreću hashiranje unesenog teksta u TextBoxUnesite
        private void buttonSHA1_Click(object sender, EventArgs e)
        {
            SHA1(ConvertStringToByteArray());
        }

        private void buttonSHA256_Click(object sender, EventArgs e)
        {
            SHA256(ConvertStringToByteArray());
        }

        private void buttonMD5_Click(object sender, EventArgs e)
        {
            MD5(ConvertStringToByteArray());
        }

        private void buttonRunAll_Click(object sender, EventArgs e)
        {
            buttonSHA1_Click(sender, e);
            buttonSHA256_Click(sender, e);
            buttonMD5_Click(sender, e);
            buttonMD5me_Click(sender, e);
            buttonSHA1me_Click(sender, e);
            buttonSHA256me_Click(sender, e);

        }



        //Pomoćne metode za hashiranje. Pretvorbe string/byte [].
        byte[] ConvertStringToByteArray()
        {
            return Encoding.UTF8.GetBytes(textBoxUnesite.Text);
        }

        string ConvertByteArrayToString(byte[] array)
        {
            return BitConverter.ToString(array).Replace("-", "").ToLower();
        }

        //Dvoklik slučajni, ak izbrišem briše mi element iz Form1. Ne dirati ako nije potrebno.
        private void textBoxUnesite_TextChanged(object sender, EventArgs e)
        {

        }

        //Brže kpoiranje rezultata hashiranja
        private void buttonSHA1Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxSHA1.Text);
        }

        private void buttonSHA256Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxSHA256.Text);
        }

        private void buttonMD5Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxMD5.Text);
        }

        //Omogućuje/onemogućuje jednu funkciju tako da ste sigurni šta hashirate
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDatoteka.Checked)
            {
                radioButtonUnesite.Checked = false;
                textBoxUnesite.Enabled = false;
            }
            else
            {
                radioButtonUnesite.Checked = true;
                textBoxUnesite.Enabled = true;
                buttonSHA1.Enabled = true;
                buttonSHA256.Enabled = true;
                buttonMD5.Enabled = true;
                buttonMD5me.Enabled = true;
                buttonSHA1me.Enabled = true;
                buttonSHA256me.Enabled = true;
                buttonRunAll.Enabled = true;

            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUnesite.Checked)
            {
                radioButtonDatoteka.Checked = false;
                buttonDatoteka.Enabled = false;
            }
            else
            {
                radioButtonDatoteka.Checked = true;
                buttonDatoteka.Enabled = true;
                buttonSHA1.Enabled = false;
                buttonSHA256.Enabled = false;
                buttonMD5.Enabled = false;
                buttonMD5me.Enabled = false;
                buttonSHA1me.Enabled = false;
                buttonSHA256me.Enabled = false;
                buttonRunAll.Enabled = false;
            }
        }

        //Vraća na glavni meni
        private void buttonBack_Click(object sender, EventArgs e)
        {          
            Owner.Show();
            Hide();          
        }

        //Moji hashevi
        private void buttonMD5me_Click(object sender, EventArgs e)
        {
           MD5me(ConvertStringToByteArray());
        }

        private void buttonSHA1me_Click(object sender, EventArgs e)
        {
            SHA1me(ConvertStringToByteArray());
        }

        private void buttonSHA256me_Click(object sender, EventArgs e)
        {
            SHA256me(ConvertStringToByteArray());
        }

        private void buttonMD5meCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxMD5me.Text);
        }

        private void buttonSHA1meCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxSHA1me.Text);
        }

        private void buttonSHA256meCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxSHA256me.Text);
        }
    }
}
