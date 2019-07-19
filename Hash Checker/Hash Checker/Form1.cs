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
            textMD5.Text = BytesToString(GetHashMD5(txtloc.Text));
            textSHA512.Text = BytesToString(GetHashSha1(txtloc.Text));
            textSHA256.Text = BytesToString(GetHashSha256(txtloc.Text));
            textSHA1.Text = BytesToString(GetHashSha1(txtloc.Text));

            if (texthash.Text == textSHA256.Text || texthash.Text == textSHA1.Text || texthash.Text == textMD5.Text || texthash.Text == textSHA512.Text)
            {
                match.ForeColor = System.Drawing.Color.Green;
                match.Text = "Match";
            }
            else
            {
                match.ForeColor = System.Drawing.Color.Red;
                match.Text = "No match";
            }
        }

        public static string BytesToString(byte[] bytes)
        {
            string result = "";
            foreach (byte b in bytes) result += b.ToString("x2");
            return result;
        }

        //MD5
        private MD5 Md5 = MD5.Create();

        private byte[] GetHashMD5(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Md5.ComputeHash(stream);
            }
        }

        //SHA256
        private SHA256 Sha256 = SHA256.Create();

        private byte[] GetHashSha256(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha256.ComputeHash(stream);
            }
        }

        //SHA1
        private SHA1 Sha1 = SHA1.Create();

        private byte[] GetHashSha1(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha1.ComputeHash(stream);
            }
        }

        //SHA512
        private SHA256 Sha512 = SHA256.Create();

        private byte[] GetHashSha512(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha512.ComputeHash(stream);
            }
        }
    }
}
