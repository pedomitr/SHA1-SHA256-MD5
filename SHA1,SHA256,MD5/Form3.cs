using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHA1_SHA256_MD5
{
    public partial class Form3 : Form
    {
        Form1 f1;
        Form2 f2;
        public Form3()
        {
            InitializeComponent();
        }

        //Gumbi na glavnom meniju
        private void buttonHasher_Click(object sender, EventArgs e)
        {
            if(f1 == null)
            {
                f1 = new Form1();
                f1.FormClosed += f1_FormClosed; 
            }
            f1.Show(this);
            Hide();
        }
      
        private void buttonTest_Click(object sender, EventArgs e)
        {
            if (f2 == null)
            {
                f2 = new Form2();
                f2.FormClosed += f2_FormClosed;
            }
            f2.Show(this);
            Hide();
        }

        //Derefencira zatvoreni form.
        void f1_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1 = null;
            Show();
        }

        void f2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f2 = null;
            Show();
        }
    }
}
