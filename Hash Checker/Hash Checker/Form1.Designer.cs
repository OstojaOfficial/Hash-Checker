namespace Hash_Checker
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
            this.txtloc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textSHA256 = new System.Windows.Forms.TextBox();
            this.textMD5 = new System.Windows.Forms.TextBox();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.hash = new System.Windows.Forms.Button();
            this.textSHA1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.texthash = new System.Windows.Forms.TextBox();
            this.match = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textSHA512 = new System.Windows.Forms.TextBox();
            this.copy1 = new System.Windows.Forms.Button();
            this.copy2 = new System.Windows.Forms.Button();
            this.copy3 = new System.Windows.Forms.Button();
            this.copy4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtloc
            // 
            this.txtloc.Location = new System.Drawing.Point(83, 12);
            this.txtloc.Name = "txtloc";
            this.txtloc.Size = new System.Drawing.Size(533, 20);
            this.txtloc.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "File:";
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.Location = new System.Drawing.Point(622, 7);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(51, 29);
            this.search.TabIndex = 2;
            this.search.Text = "• • •";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.Search_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "MD5:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "SHA256:";
            // 
            // textSHA256
            // 
            this.textSHA256.Location = new System.Drawing.Point(83, 130);
            this.textSHA256.Name = "textSHA256";
            this.textSHA256.ReadOnly = true;
            this.textSHA256.Size = new System.Drawing.Size(509, 20);
            this.textSHA256.TabIndex = 5;
            // 
            // textMD5
            // 
            this.textMD5.Location = new System.Drawing.Point(83, 81);
            this.textMD5.Name = "textMD5";
            this.textMD5.ReadOnly = true;
            this.textMD5.Size = new System.Drawing.Size(509, 20);
            this.textMD5.TabIndex = 6;
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "ofdFile";
            // 
            // hash
            // 
            this.hash.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.hash.Location = new System.Drawing.Point(566, 191);
            this.hash.Name = "hash";
            this.hash.Size = new System.Drawing.Size(107, 32);
            this.hash.TabIndex = 7;
            this.hash.Text = "Check Hash";
            this.hash.UseVisualStyleBackColor = true;
            this.hash.Click += new System.EventHandler(this.Hash_Click);
            // 
            // textSHA1
            // 
            this.textSHA1.Location = new System.Drawing.Point(83, 106);
            this.textSHA1.Name = "textSHA1";
            this.textSHA1.ReadOnly = true;
            this.textSHA1.Size = new System.Drawing.Size(509, 20);
            this.textSHA1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "SHA1:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(12, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hash:";
            // 
            // texthash
            // 
            this.texthash.Location = new System.Drawing.Point(83, 38);
            this.texthash.Name = "texthash";
            this.texthash.Size = new System.Drawing.Size(590, 20);
            this.texthash.TabIndex = 10;
            // 
            // match
            // 
            this.match.AutoSize = true;
            this.match.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.match.Location = new System.Drawing.Point(10, 198);
            this.match.Name = "match";
            this.match.Size = new System.Drawing.Size(191, 25);
            this.match.TabIndex = 12;
            this.match.Text = "AWAITING HASH";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(12, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "SHA512:";
            // 
            // textSHA512
            // 
            this.textSHA512.Location = new System.Drawing.Point(83, 156);
            this.textSHA512.Name = "textSHA512";
            this.textSHA512.ReadOnly = true;
            this.textSHA512.Size = new System.Drawing.Size(509, 20);
            this.textSHA512.TabIndex = 13;
            // 
            // copy1
            // 
            this.copy1.Location = new System.Drawing.Point(598, 79);
            this.copy1.Name = "copy1";
            this.copy1.Size = new System.Drawing.Size(75, 23);
            this.copy1.TabIndex = 15;
            this.copy1.Text = "Copy";
            this.copy1.UseVisualStyleBackColor = true;
            this.copy1.Click += new System.EventHandler(this.Copy1_Click);
            // 
            // copy2
            // 
            this.copy2.Location = new System.Drawing.Point(598, 104);
            this.copy2.Name = "copy2";
            this.copy2.Size = new System.Drawing.Size(75, 23);
            this.copy2.TabIndex = 16;
            this.copy2.Text = "Copy";
            this.copy2.UseVisualStyleBackColor = true;
            this.copy2.Click += new System.EventHandler(this.Copy2_Click);
            // 
            // copy3
            // 
            this.copy3.Location = new System.Drawing.Point(598, 130);
            this.copy3.Name = "copy3";
            this.copy3.Size = new System.Drawing.Size(75, 23);
            this.copy3.TabIndex = 17;
            this.copy3.Text = "Copy";
            this.copy3.UseVisualStyleBackColor = true;
            this.copy3.Click += new System.EventHandler(this.Copy3_Click);
            // 
            // copy4
            // 
            this.copy4.Location = new System.Drawing.Point(598, 154);
            this.copy4.Name = "copy4";
            this.copy4.Size = new System.Drawing.Size(75, 23);
            this.copy4.TabIndex = 18;
            this.copy4.Text = "Copy";
            this.copy4.UseVisualStyleBackColor = true;
            this.copy4.Click += new System.EventHandler(this.Copy4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 232);
            this.Controls.Add(this.copy4);
            this.Controls.Add(this.copy3);
            this.Controls.Add(this.copy2);
            this.Controls.Add(this.copy1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textSHA512);
            this.Controls.Add(this.match);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.texthash);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textSHA1);
            this.Controls.Add(this.hash);
            this.Controls.Add(this.textMD5);
            this.Controls.Add(this.textSHA256);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtloc);
            this.Name = "Form1";
            this.Text = "Hash Checker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtloc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textSHA256;
        private System.Windows.Forms.TextBox textMD5;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.Button hash;
        private System.Windows.Forms.TextBox textSHA1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox texthash;
        private System.Windows.Forms.Label match;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textSHA512;
        private System.Windows.Forms.Button copy1;
        private System.Windows.Forms.Button copy2;
        private System.Windows.Forms.Button copy3;
        private System.Windows.Forms.Button copy4;
    }
}

