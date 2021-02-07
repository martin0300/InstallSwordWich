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
    public partial class Form3 : Form
    {
        public string[] installerfile;
        public string defaultdir;
        public static string installdir;
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 F2 = new Form2();
            F2.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            installerfile = null;
            textBox1.Text = null;
            defaultdir = null;
            installdir = null;
            installerfile = File.ReadAllLines("installerfile.txt");
            this.Text = installerfile[7];
            if (File.Exists("defaultdir.txt") == false)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                defaultdir = "The default directory configuration file missing or corrupted! Please exit the program!";
            }
            else
            {
                defaultdir = File.ReadAllText("defaultdir.txt");
            }
            textBox1.Text = defaultdir + @"\" + installerfile[8];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath + @"\" + installerfile[8];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            installdir = textBox1.Text;
            File.WriteAllText("installdir.txt", installdir);
            this.Hide();
            Form4 F4 = new Form4();
            F4.Show();
        }
    }
}
