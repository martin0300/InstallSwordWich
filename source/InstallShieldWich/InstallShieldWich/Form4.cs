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
    public partial class Form4 : Form
    {
        public string[] installerfile;
        public string[] setupfile;
        public string install;
        public int setup1;
        public int setup2;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            install = null;
            install = File.ReadAllText("installdir.txt");
            installerfile = null;
            setupfile = null;
            setup1 = 0;
            setup2 = 1;
            button1.Enabled = false;
            installerfile = File.ReadAllLines("installerfile.txt");
            this.Text = installerfile[9];
            if (File.Exists("setupfile.txt") == false)
            {
                label3.Text = "The setup configuration file is corrupted or missing! Please exit the installer!";
            }
            else
            {
                setupfile = File.ReadAllLines("setupfile.txt");
            }
            if (File.Exists("setupfile.txt") == true)
            {
                label3.Text = "Installing...";
                if (Directory.Exists(install) == true)
                {

                }
                else
                {
                    Directory.CreateDirectory(install);
                }
                progressBar1.Maximum = Convert.ToInt32(installerfile[10]);
                progressBar1.Value = 0;
                int i = 0;
                while (i != Convert.ToInt32(installerfile[10]))
                {
                    File.Copy(setupfile[setup1], install + @"\" + setupfile[setup2]);
                    setup1++;
                    setup1++;
                    setup2++;
                    setup2++;
                    progressBar1.Value++;
                    i++;
                }
                label3.Text = "Installed!";
                button1.Enabled = true;
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
            Form5 F5 = new Form5();
            F5.Show();
        }
    }
}
