
namespace SHA1_SHA256_MD5
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonBack = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.checkBoxSHA1_1 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA1_2 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA1_3 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA256_1 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA256_2 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA256_3 = new System.Windows.Forms.CheckBox();
            this.checkBoxMD5_1 = new System.Windows.Forms.CheckBox();
            this.checkBoxMD5_2 = new System.Windows.Forms.CheckBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonDatoteka = new System.Windows.Forms.Button();
            this.textBoxDatoteka = new System.Windows.Forms.TextBox();
            this.buttonPregled = new System.Windows.Forms.Button();
            this.checkBoxMD5_3 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA1_4 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA256_4 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(989, 500);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(445, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonRun
            // 
            this.buttonRun.Enabled = false;
            this.buttonRun.Location = new System.Drawing.Point(12, 500);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 2;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // checkBoxSHA1_1
            // 
            this.checkBoxSHA1_1.AutoSize = true;
            this.checkBoxSHA1_1.Location = new System.Drawing.Point(12, 74);
            this.checkBoxSHA1_1.Name = "checkBoxSHA1_1";
            this.checkBoxSHA1_1.Size = new System.Drawing.Size(95, 21);
            this.checkBoxSHA1_1.TabIndex = 3;
            this.checkBoxSHA1_1.Text = "SHA1 Cng";
            this.checkBoxSHA1_1.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA1_2
            // 
            this.checkBoxSHA1_2.AutoSize = true;
            this.checkBoxSHA1_2.Location = new System.Drawing.Point(12, 101);
            this.checkBoxSHA1_2.Name = "checkBoxSHA1_2";
            this.checkBoxSHA1_2.Size = new System.Drawing.Size(211, 21);
            this.checkBoxSHA1_2.TabIndex = 4;
            this.checkBoxSHA1_2.Text = "SHA1 CryptoServiceProvider";
            this.checkBoxSHA1_2.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA1_3
            // 
            this.checkBoxSHA1_3.AutoSize = true;
            this.checkBoxSHA1_3.Location = new System.Drawing.Point(12, 128);
            this.checkBoxSHA1_3.Name = "checkBoxSHA1_3";
            this.checkBoxSHA1_3.Size = new System.Drawing.Size(129, 21);
            this.checkBoxSHA1_3.TabIndex = 5;
            this.checkBoxSHA1_3.Text = "SHA1 Managed";
            this.checkBoxSHA1_3.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA256_1
            // 
            this.checkBoxSHA256_1.AutoSize = true;
            this.checkBoxSHA256_1.Location = new System.Drawing.Point(12, 155);
            this.checkBoxSHA256_1.Name = "checkBoxSHA256_1";
            this.checkBoxSHA256_1.Size = new System.Drawing.Size(111, 21);
            this.checkBoxSHA256_1.TabIndex = 6;
            this.checkBoxSHA256_1.Text = "SHA256 Cng";
            this.checkBoxSHA256_1.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA256_2
            // 
            this.checkBoxSHA256_2.AutoSize = true;
            this.checkBoxSHA256_2.Location = new System.Drawing.Point(12, 182);
            this.checkBoxSHA256_2.Name = "checkBoxSHA256_2";
            this.checkBoxSHA256_2.Size = new System.Drawing.Size(227, 21);
            this.checkBoxSHA256_2.TabIndex = 7;
            this.checkBoxSHA256_2.Text = "SHA256 CryptoServiceProvider";
            this.checkBoxSHA256_2.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA256_3
            // 
            this.checkBoxSHA256_3.AutoSize = true;
            this.checkBoxSHA256_3.Location = new System.Drawing.Point(12, 209);
            this.checkBoxSHA256_3.Name = "checkBoxSHA256_3";
            this.checkBoxSHA256_3.Size = new System.Drawing.Size(145, 21);
            this.checkBoxSHA256_3.TabIndex = 8;
            this.checkBoxSHA256_3.Text = "SHA256 Managed";
            this.checkBoxSHA256_3.UseVisualStyleBackColor = true;
            // 
            // checkBoxMD5_1
            // 
            this.checkBoxMD5_1.AutoSize = true;
            this.checkBoxMD5_1.Location = new System.Drawing.Point(12, 236);
            this.checkBoxMD5_1.Name = "checkBoxMD5_1";
            this.checkBoxMD5_1.Size = new System.Drawing.Size(88, 21);
            this.checkBoxMD5_1.TabIndex = 9;
            this.checkBoxMD5_1.Text = "MD5 Cng";
            this.checkBoxMD5_1.UseVisualStyleBackColor = true;
            // 
            // checkBoxMD5_2
            // 
            this.checkBoxMD5_2.AutoSize = true;
            this.checkBoxMD5_2.Location = new System.Drawing.Point(12, 263);
            this.checkBoxMD5_2.Name = "checkBoxMD5_2";
            this.checkBoxMD5_2.Size = new System.Drawing.Size(204, 21);
            this.checkBoxMD5_2.TabIndex = 10;
            this.checkBoxMD5_2.Text = "MD5 CryptoServiceProvider";
            this.checkBoxMD5_2.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.Title = "ms";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Times New Roman", 8F);
            legend1.IsTextAutoFit = false;
            legend1.LegendItemOrder = System.Windows.Forms.DataVisualization.Charting.LegendItemOrder.SameAsSeriesOrder;
            legend1.Name = "Legend1";
            legend1.Title = "Hash:";
            legend1.TitleFont = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(285, 41);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(683, 370);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // buttonDatoteka
            // 
            this.buttonDatoteka.Location = new System.Drawing.Point(509, 477);
            this.buttonDatoteka.Name = "buttonDatoteka";
            this.buttonDatoteka.Size = new System.Drawing.Size(90, 23);
            this.buttonDatoteka.TabIndex = 13;
            this.buttonDatoteka.Text = "Datoteka";
            this.buttonDatoteka.UseVisualStyleBackColor = true;
            this.buttonDatoteka.Click += new System.EventHandler(this.buttonDatoteka_Click);
            // 
            // textBoxDatoteka
            // 
            this.textBoxDatoteka.Enabled = false;
            this.textBoxDatoteka.Location = new System.Drawing.Point(605, 477);
            this.textBoxDatoteka.Name = "textBoxDatoteka";
            this.textBoxDatoteka.Size = new System.Drawing.Size(363, 22);
            this.textBoxDatoteka.TabIndex = 14;
            // 
            // buttonPregled
            // 
            this.buttonPregled.Enabled = false;
            this.buttonPregled.Location = new System.Drawing.Point(285, 430);
            this.buttonPregled.Name = "buttonPregled";
            this.buttonPregled.Size = new System.Drawing.Size(99, 31);
            this.buttonPregled.TabIndex = 15;
            this.buttonPregled.Text = "Pretpregled";
            this.buttonPregled.UseVisualStyleBackColor = true;
            this.buttonPregled.Click += new System.EventHandler(this.buttonPregled_Click);
            // 
            // checkBoxMD5_3
            // 
            this.checkBoxMD5_3.AutoSize = true;
            this.checkBoxMD5_3.Location = new System.Drawing.Point(12, 290);
            this.checkBoxMD5_3.Name = "checkBoxMD5_3";
            this.checkBoxMD5_3.Size = new System.Drawing.Size(81, 21);
            this.checkBoxMD5_3.TabIndex = 16;
            this.checkBoxMD5_3.Text = "MyMD5 ";
            this.checkBoxMD5_3.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA1_4
            // 
            this.checkBoxSHA1_4.AutoSize = true;
            this.checkBoxSHA1_4.Location = new System.Drawing.Point(12, 317);
            this.checkBoxSHA1_4.Name = "checkBoxSHA1_4";
            this.checkBoxSHA1_4.Size = new System.Drawing.Size(88, 21);
            this.checkBoxSHA1_4.TabIndex = 17;
            this.checkBoxSHA1_4.Text = "MySHA1 ";
            this.checkBoxSHA1_4.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA256_4
            // 
            this.checkBoxSHA256_4.AutoSize = true;
            this.checkBoxSHA256_4.Location = new System.Drawing.Point(12, 344);
            this.checkBoxSHA256_4.Name = "checkBoxSHA256_4";
            this.checkBoxSHA256_4.Size = new System.Drawing.Size(100, 21);
            this.checkBoxSHA256_4.TabIndex = 18;
            this.checkBoxSHA256_4.Text = "MySHA256";
            this.checkBoxSHA256_4.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 535);
            this.Controls.Add(this.checkBoxSHA256_4);
            this.Controls.Add(this.checkBoxSHA1_4);
            this.Controls.Add(this.checkBoxMD5_3);
            this.Controls.Add(this.buttonPregled);
            this.Controls.Add(this.textBoxDatoteka);
            this.Controls.Add(this.buttonDatoteka);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.checkBoxMD5_2);
            this.Controls.Add(this.checkBoxMD5_1);
            this.Controls.Add(this.checkBoxSHA256_3);
            this.Controls.Add(this.checkBoxSHA256_2);
            this.Controls.Add(this.checkBoxSHA256_1);
            this.Controls.Add(this.checkBoxSHA1_3);
            this.Controls.Add(this.checkBoxSHA1_2);
            this.Controls.Add(this.checkBoxSHA1_1);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonBack);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.CheckBox checkBoxSHA1_1;
        private System.Windows.Forms.CheckBox checkBoxSHA1_2;
        private System.Windows.Forms.CheckBox checkBoxSHA1_3;
        private System.Windows.Forms.CheckBox checkBoxSHA256_1;
        private System.Windows.Forms.CheckBox checkBoxSHA256_2;
        private System.Windows.Forms.CheckBox checkBoxSHA256_3;
        private System.Windows.Forms.CheckBox checkBoxMD5_1;
        private System.Windows.Forms.CheckBox checkBoxMD5_2;
        private System.Windows.Forms.Button buttonDatoteka;
        private System.Windows.Forms.TextBox textBoxDatoteka;
        private System.Windows.Forms.Button buttonPregled;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox checkBoxMD5_3;
        private System.Windows.Forms.CheckBox checkBoxSHA1_4;
        private System.Windows.Forms.CheckBox checkBoxSHA256_4;
    }
}