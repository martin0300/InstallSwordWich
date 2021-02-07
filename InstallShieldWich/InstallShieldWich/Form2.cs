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
    public partial class Form2 : Form
    {
        public string[] installerfile;
        public string agreement;
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing()
        {
            Form1 F1 = new Form1();
            F1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F1 = new Form1();
            F1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = null;
            richTextBox1.ReadOnly = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            installerfile = null;
            agreement = null;
            installerfile = File.ReadAllLines("installerfile.txt");
            if (File.Exists("agreement.txt") == false)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                agreement = "The agreement file is corrupted or missing! Please exit the installer!";
            }
            else
            {
                agreement = File.ReadAllText("agreement.txt");
            }
            richTextBox1.Text = agreement;
            this.Text = installerfile[4];
            this.Width = Convert.ToInt32(installerfile[6]);
            this.Height = Convert.ToInt32(installerfile[5]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //Do something
                this.Hide();
                Form3 F3 = new Form3();
                F3.Show();
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    //Do something
                    MessageBox.Show("If you not agree with the agreements you cannot continue!");
                }
                else
                {
                    MessageBox.Show("Please select something!");
                }
            }
        }
    }
}
