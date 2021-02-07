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

namespace InstallShieldWich
{
    public partial class Form1 : Form
    {
        public string[] installerfile;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = null;
            richTextBox1.Text = null;
            richTextBox1.ReadOnly = true;
            installerfile = null;
            button2.Enabled = false;
            if (File.Exists("installerfile.txt") == true)
            {
                installerfile = File.ReadAllLines("installerfile.txt");
                if (installerfile.Length == 14)
                {
                    this.Height = Convert.ToInt32(installerfile[2]);
                    this.Width = Convert.ToInt32(installerfile[3]);
                    this.Text = installerfile[0];
                    richTextBox1.Text = installerfile[1];
                }
                else
                {
                    this.Text = "ERROR";
                    richTextBox1.Text = "ERROR: The installer configuration file is incomplete or corrupted! Please exit the installer!";
                    button1.Enabled = false;
                }
            }
            else
            {
                this.Text = "ERROR";
                richTextBox1.Text = "ERROR: The installer configuration file is missing or corrupted! Please exit the installer!";
                button1.Enabled = false;
            }
            if (File.Exists("installdir.txt") == true)
            {
                File.Delete("installdir.txt");
            }
            else
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 F2 = new Form2();
            F2.Show();
        }
    }
}
