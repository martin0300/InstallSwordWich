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
    public partial class Form5 : Form
    {
        public string[] installerfile;
        public string installdir;
        public Form5()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            installerfile = null;
            installdir = null;
            installerfile = File.ReadAllLines("installerfile.txt");
            installdir = File.ReadAllText("installdir.txt");
            File.Delete("installdir.txt");
            checkBox1.Checked = false;
            this.Text = installerfile[11];
            label3.Text = installerfile[12] + " was sucessfully installed!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                System.Diagnostics.Process.Start(installdir + @"\" + installerfile[13]);
                Application.Exit();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
