
namespace SHA1_SHA256_MD5
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxUnesite = new System.Windows.Forms.TextBox();
            this.buttonDatoteka = new System.Windows.Forms.Button();
            this.buttonSHA1 = new System.Windows.Forms.Button();
            this.buttonSHA256 = new System.Windows.Forms.Button();
            this.buttonMD5 = new System.Windows.Forms.Button();
            this.textBoxSHA1 = new System.Windows.Forms.TextBox();
            this.textBoxSHA256 = new System.Windows.Forms.TextBox();
            this.textBoxMD5 = new System.Windows.Forms.TextBox();
            this.buttonRunAll = new System.Windows.Forms.Button();
            this.buttonSHA1Copy = new System.Windows.Forms.Button();
            this.buttonSHA256Copy = new System.Windows.Forms.Button();
            this.buttonMD5Copy = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelRezultat = new System.Windows.Forms.Label();
            this.textBoxDatoteka = new System.Windows.Forms.TextBox();
            this.folderBrowserDialogDatoteka = new System.Windows.Forms.FolderBrowserDialog();
            this.radioButtonUnesite = new System.Windows.Forms.RadioButton();
            this.radioButtonDatoteka = new System.Windows.Forms.RadioButton();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonMD5me = new System.Windows.Forms.Button();
            this.textBoxMD5me = new System.Windows.Forms.TextBox();
            this.buttonSHA1me = new System.Windows.Forms.Button();
            this.buttonSHA256me = new System.Windows.Forms.Button();
            this.buttonMD5meCopy = new System.Windows.Forms.Button();
            this.buttonSHA1meCopy = new System.Windows.Forms.Button();
            this.buttonSHA256meCopy = new System.Windows.Forms.Button();
            this.textBoxSHA1me = new System.Windows.Forms.TextBox();
            this.textBoxSHA256me = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxUnesite
            // 
            this.textBoxUnesite.Location = new System.Drawing.Point(138, 55);
            this.textBoxUnesite.Multiline = true;
            this.textBoxUnesite.Name = "textBoxUnesite";
            this.textBoxUnesite.Size = new System.Drawing.Size(513, 103);
            this.textBoxUnesite.TabIndex = 0;
            this.textBoxUnesite.TextChanged += new System.EventHandler(this.textBoxUnesite_TextChanged);
            // 
            // buttonDatoteka
            // 
            this.buttonDatoteka.Enabled = false;
            this.buttonDatoteka.Location = new System.Drawing.Point(138, 191);
            this.buttonDatoteka.Name = "buttonDatoteka";
            this.buttonDatoteka.Size = new System.Drawing.Size(140, 23);
            this.buttonDatoteka.TabIndex = 2;
            this.buttonDatoteka.Text = "Pronađi datoteku";
            this.buttonDatoteka.UseVisualStyleBackColor = true;
            this.buttonDatoteka.Click += new System.EventHandler(this.buttonDatoteka_Click);
            // 
            // buttonSHA1
            // 
            this.buttonSHA1.Location = new System.Drawing.Point(42, 292);
            this.buttonSHA1.Name = "buttonSHA1";
            this.buttonSHA1.Size = new System.Drawing.Size(90, 23);
            this.buttonSHA1.TabIndex = 3;
            this.buttonSHA1.Text = "SHA1";
            this.buttonSHA1.UseVisualStyleBackColor = true;
            this.buttonSHA1.Click += new System.EventHandler(this.buttonSHA1_Click);
            // 
            // buttonSHA256
            // 
            this.buttonSHA256.Location = new System.Drawing.Point(42, 323);
            this.buttonSHA256.Name = "buttonSHA256";
            this.buttonSHA256.Size = new System.Drawing.Size(90, 23);
            this.buttonSHA256.TabIndex = 4;
            this.buttonSHA256.Text = "SHA256";
            this.buttonSHA256.UseVisualStyleBackColor = true;
            this.buttonSHA256.Click += new System.EventHandler(this.buttonSHA256_Click);
            // 
            // buttonMD5
            // 
            this.buttonMD5.Location = new System.Drawing.Point(42, 261);
            this.buttonMD5.Name = "buttonMD5";
            this.buttonMD5.Size = new System.Drawing.Size(90, 23);
            this.buttonMD5.TabIndex = 5;
            this.buttonMD5.Text = "MD5";
            this.buttonMD5.UseVisualStyleBackColor = true;
            this.buttonMD5.Click += new System.EventHandler(this.buttonMD5_Click);
            // 
            // textBoxSHA1
            // 
            this.textBoxSHA1.Location = new System.Drawing.Point(138, 292);
            this.textBoxSHA1.Name = "textBoxSHA1";
            this.textBoxSHA1.ReadOnly = true;
            this.textBoxSHA1.Size = new System.Drawing.Size(513, 22);
            this.textBoxSHA1.TabIndex = 6;
            // 
            // textBoxSHA256
            // 
            this.textBoxSHA256.Location = new System.Drawing.Point(138, 322);
            this.textBoxSHA256.Name = "textBoxSHA256";
            this.textBoxSHA256.ReadOnly = true;
            this.textBoxSHA256.Size = new System.Drawing.Size(513, 22);
            this.textBoxSHA256.TabIndex = 7;
            // 
            // textBoxMD5
            // 
            this.textBoxMD5.Location = new System.Drawing.Point(138, 261);
            this.textBoxMD5.Name = "textBoxMD5";
            this.textBoxMD5.ReadOnly = true;
            this.textBoxMD5.Size = new System.Drawing.Size(513, 22);
            this.textBoxMD5.TabIndex = 8;
            // 
            // buttonRunAll
            // 
            this.buttonRunAll.Location = new System.Drawing.Point(57, 480);
            this.buttonRunAll.Name = "buttonRunAll";
            this.buttonRunAll.Size = new System.Drawing.Size(75, 23);
            this.buttonRunAll.TabIndex = 9;
            this.buttonRunAll.Text = "Run All";
            this.buttonRunAll.UseVisualStyleBackColor = true;
            this.buttonRunAll.Click += new System.EventHandler(this.buttonRunAll_Click);
            // 
            // buttonSHA1Copy
            // 
            this.buttonSHA1Copy.Location = new System.Drawing.Point(657, 291);
            this.buttonSHA1Copy.Name = "buttonSHA1Copy";
            this.buttonSHA1Copy.Size = new System.Drawing.Size(143, 25);
            this.buttonSHA1Copy.TabIndex = 10;
            this.buttonSHA1Copy.Text = "Copy to Clipboard";
            this.buttonSHA1Copy.UseVisualStyleBackColor = true;
            this.buttonSHA1Copy.Click += new System.EventHandler(this.buttonSHA1Copy_Click);
            // 
            // buttonSHA256Copy
            // 
            this.buttonSHA256Copy.Location = new System.Drawing.Point(657, 322);
            this.buttonSHA256Copy.Name = "buttonSHA256Copy";
            this.buttonSHA256Copy.Size = new System.Drawing.Size(143, 25);
            this.buttonSHA256Copy.TabIndex = 11;
            this.buttonSHA256Copy.Text = "Copy to Clipboard";
            this.buttonSHA256Copy.UseVisualStyleBackColor = true;
            this.buttonSHA256Copy.Click += new System.EventHandler(this.buttonSHA256Copy_Click);
            // 
            // buttonMD5Copy
            // 
            this.buttonMD5Copy.Location = new System.Drawing.Point(657, 260);
            this.buttonMD5Copy.Name = "buttonMD5Copy";
            this.buttonMD5Copy.Size = new System.Drawing.Size(143, 25);
            this.buttonMD5Copy.TabIndex = 12;
            this.buttonMD5Copy.Text = "Copy to Clipboard";
            this.buttonMD5Copy.UseVisualStyleBackColor = true;
            this.buttonMD5Copy.Click += new System.EventHandler(this.buttonMD5Copy_Click);
            // 
            // labelRezultat
            // 
            this.labelRezultat.AutoSize = true;
            this.labelRezultat.Location = new System.Drawing.Point(135, 241);
            this.labelRezultat.Name = "labelRezultat";
            this.labelRezultat.Size = new System.Drawing.Size(49, 17);
            this.labelRezultat.TabIndex = 13;
            this.labelRezultat.Text = "Hash :";
            // 
            // textBoxDatoteka
            // 
            this.textBoxDatoteka.Location = new System.Drawing.Point(284, 191);
            this.textBoxDatoteka.Name = "textBoxDatoteka";
            this.textBoxDatoteka.ReadOnly = true;
            this.textBoxDatoteka.Size = new System.Drawing.Size(367, 22);
            this.textBoxDatoteka.TabIndex = 15;
            // 
            // radioButtonUnesite
            // 
            this.radioButtonUnesite.AutoSize = true;
            this.radioButtonUnesite.Checked = true;
            this.radioButtonUnesite.Location = new System.Drawing.Point(123, 28);
            this.radioButtonUnesite.Name = "radioButtonUnesite";
            this.radioButtonUnesite.Size = new System.Drawing.Size(115, 21);
            this.radioButtonUnesite.TabIndex = 16;
            this.radioButtonUnesite.TabStop = true;
            this.radioButtonUnesite.Text = "Unesite tekst:";
            this.radioButtonUnesite.UseVisualStyleBackColor = true;
            this.radioButtonUnesite.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButtonDatoteka
            // 
            this.radioButtonDatoteka.AutoSize = true;
            this.radioButtonDatoteka.Location = new System.Drawing.Point(123, 164);
            this.radioButtonDatoteka.Name = "radioButtonDatoteka";
            this.radioButtonDatoteka.Size = new System.Drawing.Size(155, 21);
            this.radioButtonDatoteka.TabIndex = 17;
            this.radioButtonDatoteka.Text = "Odaberite tatoteku: ";
            this.radioButtonDatoteka.UseVisualStyleBackColor = true;
            this.radioButtonDatoteka.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(725, 480);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 18;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonMD5me
            // 
            this.buttonMD5me.Location = new System.Drawing.Point(42, 353);
            this.buttonMD5me.Name = "buttonMD5me";
            this.buttonMD5me.Size = new System.Drawing.Size(90, 23);
            this.buttonMD5me.TabIndex = 19;
            this.buttonMD5me.Text = "MyMD5";
            this.buttonMD5me.UseVisualStyleBackColor = true;
            this.buttonMD5me.Click += new System.EventHandler(this.buttonMD5me_Click);
            // 
            // textBoxMD5me
            // 
            this.textBoxMD5me.Location = new System.Drawing.Point(138, 353);
            this.textBoxMD5me.Name = "textBoxMD5me";
            this.textBoxMD5me.ReadOnly = true;
            this.textBoxMD5me.Size = new System.Drawing.Size(513, 22);
            this.textBoxMD5me.TabIndex = 20;
            // 
            // buttonSHA1me
            // 
            this.buttonSHA1me.Location = new System.Drawing.Point(42, 383);
            this.buttonSHA1me.Name = "buttonSHA1me";
            this.buttonSHA1me.Size = new System.Drawing.Size(90, 23);
            this.buttonSHA1me.TabIndex = 21;
            this.buttonSHA1me.Text = "MySHA1";
            this.buttonSHA1me.UseVisualStyleBackColor = true;
            this.buttonSHA1me.Click += new System.EventHandler(this.buttonSHA1me_Click);
            // 
            // buttonSHA256me
            // 
            this.buttonSHA256me.Location = new System.Drawing.Point(42, 414);
            this.buttonSHA256me.Name = "buttonSHA256me";
            this.buttonSHA256me.Size = new System.Drawing.Size(90, 23);
            this.buttonSHA256me.TabIndex = 22;
            this.buttonSHA256me.Text = "MySHA256";
            this.buttonSHA256me.UseVisualStyleBackColor = true;
            this.buttonSHA256me.Click += new System.EventHandler(this.buttonSHA256me_Click);
            // 
            // buttonMD5meCopy
            // 
            this.buttonMD5meCopy.Location = new System.Drawing.Point(657, 350);
            this.buttonMD5meCopy.Name = "buttonMD5meCopy";
            this.buttonMD5meCopy.Size = new System.Drawing.Size(143, 25);
            this.buttonMD5meCopy.TabIndex = 23;
            this.buttonMD5meCopy.Text = "Copy to Clipboard";
            this.buttonMD5meCopy.UseVisualStyleBackColor = true;
            this.buttonMD5meCopy.Click += new System.EventHandler(this.buttonMD5meCopy_Click);
            // 
            // buttonSHA1meCopy
            // 
            this.buttonSHA1meCopy.Location = new System.Drawing.Point(657, 382);
            this.buttonSHA1meCopy.Name = "buttonSHA1meCopy";
            this.buttonSHA1meCopy.Size = new System.Drawing.Size(143, 25);
            this.buttonSHA1meCopy.TabIndex = 24;
            this.buttonSHA1meCopy.Text = "Copy to Clipboard";
            this.buttonSHA1meCopy.UseVisualStyleBackColor = true;
            this.buttonSHA1meCopy.Click += new System.EventHandler(this.buttonSHA1meCopy_Click);
            // 
            // buttonSHA256meCopy
            // 
            this.buttonSHA256meCopy.Location = new System.Drawing.Point(657, 413);
            this.buttonSHA256meCopy.Name = "buttonSHA256meCopy";
            this.buttonSHA256meCopy.Size = new System.Drawing.Size(143, 25);
            this.buttonSHA256meCopy.TabIndex = 25;
            this.buttonSHA256meCopy.Text = "Copy to Clipboard";
            this.buttonSHA256meCopy.UseVisualStyleBackColor = true;
            this.buttonSHA256meCopy.Click += new System.EventHandler(this.buttonSHA256meCopy_Click);
            // 
            // textBoxSHA1me
            // 
            this.textBoxSHA1me.Location = new System.Drawing.Point(138, 382);
            this.textBoxSHA1me.Name = "textBoxSHA1me";
            this.textBoxSHA1me.ReadOnly = true;
            this.textBoxSHA1me.Size = new System.Drawing.Size(513, 22);
            this.textBoxSHA1me.TabIndex = 26;
            // 
            // textBoxSHA256me
            // 
            this.textBoxSHA256me.Location = new System.Drawing.Point(138, 414);
            this.textBoxSHA256me.Name = "textBoxSHA256me";
            this.textBoxSHA256me.ReadOnly = true;
            this.textBoxSHA256me.Size = new System.Drawing.Size(513, 22);
            this.textBoxSHA256me.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 515);
            this.Controls.Add(this.textBoxSHA256me);
            this.Controls.Add(this.textBoxSHA1me);
            this.Controls.Add(this.buttonSHA256meCopy);
            this.Controls.Add(this.buttonSHA1meCopy);
            this.Controls.Add(this.buttonMD5meCopy);
            this.Controls.Add(this.buttonSHA256me);
            this.Controls.Add(this.buttonSHA1me);
            this.Controls.Add(this.textBoxMD5me);
            this.Controls.Add(this.buttonMD5me);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.radioButtonDatoteka);
            this.Controls.Add(this.radioButtonUnesite);
            this.Controls.Add(this.textBoxDatoteka);
            this.Controls.Add(this.labelRezultat);
            this.Controls.Add(this.buttonMD5Copy);
            this.Controls.Add(this.buttonSHA256Copy);
            this.Controls.Add(this.buttonSHA1Copy);
            this.Controls.Add(this.buttonRunAll);
            this.Controls.Add(this.textBoxMD5);
            this.Controls.Add(this.textBoxSHA256);
            this.Controls.Add(this.textBoxSHA1);
            this.Controls.Add(this.buttonMD5);
            this.Controls.Add(this.buttonSHA256);
            this.Controls.Add(this.buttonSHA1);
            this.Controls.Add(this.buttonDatoteka);
            this.Controls.Add(this.textBoxUnesite);
            this.Name = "Form1";
            this.Text = "Hasher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUnesite;
        private System.Windows.Forms.Button buttonDatoteka;
        private System.Windows.Forms.Button buttonSHA1;
        private System.Windows.Forms.Button buttonSHA256;
        private System.Windows.Forms.Button buttonMD5;
        private System.Windows.Forms.TextBox textBoxSHA1;
        private System.Windows.Forms.TextBox textBoxSHA256;
        private System.Windows.Forms.TextBox textBoxMD5;
        private System.Windows.Forms.Button buttonRunAll;
        private System.Windows.Forms.Button buttonSHA1Copy;
        private System.Windows.Forms.Button buttonSHA256Copy;
        private System.Windows.Forms.Button buttonMD5Copy;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelRezultat;
        private System.Windows.Forms.TextBox textBoxDatoteka;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogDatoteka;
        private System.Windows.Forms.RadioButton radioButtonUnesite;
        private System.Windows.Forms.RadioButton radioButtonDatoteka;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonMD5me;
        private System.Windows.Forms.TextBox textBoxMD5me;
        private System.Windows.Forms.Button buttonSHA1me;
        private System.Windows.Forms.Button buttonSHA256me;
        private System.Windows.Forms.Button buttonMD5meCopy;
        private System.Windows.Forms.Button buttonSHA1meCopy;
        private System.Windows.Forms.Button buttonSHA256meCopy;
        private System.Windows.Forms.TextBox textBoxSHA1me;
        private System.Windows.Forms.TextBox textBoxSHA256me;
    }
}

