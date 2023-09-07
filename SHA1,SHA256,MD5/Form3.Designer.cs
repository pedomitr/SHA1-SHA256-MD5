
namespace SHA1_SHA256_MD5
{
    partial class Form3
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
            this.buttonHasher = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonHasher
            // 
            this.buttonHasher.Location = new System.Drawing.Point(95, 56);
            this.buttonHasher.Name = "buttonHasher";
            this.buttonHasher.Size = new System.Drawing.Size(137, 74);
            this.buttonHasher.TabIndex = 0;
            this.buttonHasher.Text = "Hasher";
            this.buttonHasher.UseVisualStyleBackColor = true;
            this.buttonHasher.Click += new System.EventHandler(this.buttonHasher_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(95, 178);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(137, 74);
            this.buttonTest.TabIndex = 1;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 450);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonHasher);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonHasher;
        private System.Windows.Forms.Button buttonTest;
    }
}