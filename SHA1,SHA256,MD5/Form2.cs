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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SHA1_SHA256_MD5
{
    public partial class Form2 : Form
    {
        byte[] array;//sprema podatke odabranog filea
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Hide();
        }      

        //Pokreće odabrane hasheve i prikazuje rezultat u chartu.//Višak
        private void buttonRun_Click(object sender, EventArgs e)
        {
            List<int> check = PickedHash();
            if (checkBoxSHA1_1.Checked)
            {
                
            }
        }

        //Hash metode, ako nije odabran ne izvađa se
        List<double> Hasher()
        {
            List<int> picked = PickedHash();
            List<double> time = new List<double>();
            var timer = new Stopwatch();
            foreach (int i in picked)
            {
                switch(i)
                    {
                    case 0:
                        var hashSHA1 = new SHA1Cng();
                        timer.Start();
                        hashSHA1.ComputeHash(array);
                        hashSHA1.Clear();
                        timer.Stop();
                        time.Add(timer.Elapsed.TotalMilliseconds);
                        timer.Reset();
                        break;
                    case 1:
                        var hashSHA2 = new SHA1CryptoServiceProvider();
                        timer.Start();
                        hashSHA2.ComputeHash(array);
                        hashSHA2.Clear();
                        timer.Stop();
                        time.Add(timer.Elapsed.TotalMilliseconds);
                        timer.Reset();
                        break;
                    case 2:
                        var hashSHA3 = new SHA1Managed();
                        timer.Start();
                        hashSHA3.ComputeHash(array);
                        hashSHA3.Clear();
                        timer.Stop();
                        time.Add(timer.Elapsed.TotalMilliseconds);
                        timer.Reset();
                        break;
                    case 3:
                        var hashSHA256_1 = new SHA256Cng();
                        timer.Start();
                        hashSHA256_1.ComputeHash(array);
                        hashSHA256_1.Clear();
                        timer.Stop();
                        time.Add(timer.Elapsed.TotalMilliseconds);
                        timer.Reset();
                        break;
                    case 4:
                        var hashSHA256_2 = new SHA256CryptoServiceProvider();
                        timer.Start();
                        hashSHA256_2.ComputeHash(array);
                        hashSHA256_2.Clear();
                        timer.Stop();
                        time.Add(timer.Elapsed.TotalMilliseconds);
                        break;
                    case 5:
                        var hashSHA256_3 = new SHA256Managed();
                        timer.Start();
                        hashSHA256_3.ComputeHash(array);
                        hashSHA256_3.Clear();
                        timer.Stop();
                        time.Add(timer.Elapsed.TotalMilliseconds);
                        timer.Reset();
                        break;
                    case 6:
                        var hashMD5_1 = new MD5Cng();
                        timer.Start();
                        hashMD5_1.ComputeHash(array);
                        hashMD5_1.Clear();
                        timer.Stop();
                        time.Add(timer.Elapsed.TotalMilliseconds);
                        timer.Reset();
                        break;
                    case 7:
                        var hashMD5_2 = new MD5CryptoServiceProvider();
                        timer.Start();
                        hashMD5_2.ComputeHash(array);
                        hashMD5_2.Clear();
                        timer.Stop();
                        time.Add(timer.Elapsed.TotalMilliseconds);
                        timer.Reset();
                        break;
                    default:
                        break;
                }
            }
            return time;
        }
    
         //Odabir datoteke za hashiranje i spremanje puta do datoteke
         private void buttonDatoteka_Click(object sender, EventArgs e)
         {
             OpenFileDialog open = new OpenFileDialog();
             open.Title = "Odaberite datoteku";
             open.Filter = "Text Files (*txt)|*txt";
             if (open.ShowDialog() == DialogResult.OK)
             {
                //StreamReader reader = new StreamReader(File.OpenRead(open.FileName));//višak
                textBoxDatoteka.Text = open.SafeFileName;
                array = File.ReadAllBytes(open.FileName);
                buttonRun.Enabled = true;
                buttonPregled.Enabled = true;
             }
         }

        //Pripremiti chart s obzirom na odabrane tipove hasha
        private void buttonPregled_Click(object sender, EventArgs e)
        {
            //array odabranih tipa hasha
            List<string> names = HashNames();
            List<double> times = Hasher();
            chart1.Series.Clear();
            chart1.Palette = ChartColorPalette.Fire;
            for (int i = 0; i < names.Count; i++ )
            {
                Series series = chart1.Series.Add(names[i]);
                series.Points.Add(times[i]);
            }          
        }

        //Vraća listu odabranih hasheva
        List<int> PickedHash()
        {
            bool[] a = { checkBoxSHA1_1.Checked, checkBoxSHA1_2.Checked, checkBoxSHA1_3.Checked, checkBoxSHA256_1.Checked, checkBoxSHA256_2.Checked, checkBoxSHA256_3.Checked, checkBoxMD5_1.Checked, checkBoxMD5_2.Checked };
            List<int> picked = new List<int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i])
                {
                    picked.Add(i);
                }
            }
            return picked;
        }

        //Vraća listu imena odabranih hasheva
        List<string> HashNames()
        {
            List<int> picked = PickedHash();
            List<string> names = new List<string> { checkBoxSHA1_1.Text, checkBoxSHA1_2.Text, checkBoxSHA1_3.Text, checkBoxSHA256_1.Text, checkBoxSHA256_2.Text, checkBoxSHA256_3.Text, checkBoxMD5_1.Text, checkBoxMD5_2.Text };
            List<string> pickednames = new List<string>();
            for(int i = 0; i < picked.Count; ++i)
            {
                pickednames.Add(names[picked[i]]);
            }
            return pickednames;
        }

        //Missclick
        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
