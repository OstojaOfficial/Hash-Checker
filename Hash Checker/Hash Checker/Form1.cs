#region using
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
#endregion

namespace Hash_Checker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtloc.Text = Application.ExecutablePath;
            texthash.CharacterCasing = CharacterCasing.Lower;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            ofdFile.FileName = txtloc.Text;
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                txtloc.Text = ofdFile.FileName;
                textMD5.Clear();
                textSHA512.Clear();
                textSHA256.Clear();
                textSHA1.Clear();
            }
        }

        private void Hash_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtloc.Text))
            {
                textMD5.Text = BytesToString(GetHashMD5(txtloc.Text));
                textSHA512.Text = BytesToString(GetHashSha1(txtloc.Text));
                textSHA256.Text = BytesToString(GetHashSha256(txtloc.Text));
                textSHA1.Text = BytesToString(GetHashSha1(txtloc.Text));
            }
            else
            {
                MessageBox.Show("File doesn't exist.", "Error: File not found");
            }

            if (texthash.Text == textSHA256.Text || texthash.Text == textSHA1.Text || texthash.Text == textMD5.Text || texthash.Text == textSHA512.Text)
            {
                match.ForeColor = System.Drawing.Color.Green;
                match.Text = "MATCH";
            }
            else
            {
                match.ForeColor = System.Drawing.Color.Red;
                match.Text = "NO MATCH";
            }
        }

        public static string BytesToString(byte[] bytes)
        {
            string result = "";
            foreach (byte b in bytes)
            {
                result += b.ToString("x2");
            }
            return result;
        }

        #region Algorithms
        //MD5
        readonly private MD5 Md5 = MD5.Create();

        private byte[] GetHashMD5(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Md5.ComputeHash(stream);
            }
        }

        //SHA256
        readonly private SHA256 Sha256 = SHA256.Create();

        private byte[] GetHashSha256(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha256.ComputeHash(stream);
            }
        }

        //SHA1
        readonly private SHA1 Sha1 = SHA1.Create();

        private byte[] GetHashSha1(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha1.ComputeHash(stream);
            }
        }

        //SHA512
        readonly private SHA256 Sha512 = SHA256.Create();

        private byte[] GetHashSha512(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha512.ComputeHash(stream);
            }
        }
        #endregion

        #region Copy
        //Copy
        private void Copy1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textMD5.Text))
            {
                MessageBox.Show("Textbox cannot be null.", "Error: MD5");
            }
            else
            {
                Clipboard.SetText(textMD5.Text);
            }
        }

        private void Copy2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textSHA1.Text))
            {
                MessageBox.Show("Textbox cannot be null.", "Error: SHA1");
            }
            else
            {
                Clipboard.SetText(textSHA1.Text);
            }
        }

        private void Copy3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textSHA256.Text))
            {
                MessageBox.Show("Textbox cannot be null.", "Error: SHA256");
            }
            else
            {
                Clipboard.SetText(textSHA256.Text);
            }
        }

        private void Copy4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textSHA512.Text))
            {
                MessageBox.Show("Textbox cannot be null.", "Error: SHA512");
            }
            else
            {
                Clipboard.SetText(textSHA512.Text);
            }
        }
        #endregion
    }
}
