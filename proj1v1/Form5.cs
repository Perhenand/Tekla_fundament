using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proj1v1
{
    public partial class Form5 : Form
    {
        private Dictionary<string, string> data_rit = new Dictionary<string, string>();

        public Form5(Dictionary<string, string> data_rit_in)
        {
            InitializeComponent();
            data_rit = data_rit_in;
        }

        public Dictionary<string, string> Data_rit
        {
            get { return data_rit; }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Text = data_rit["A-jarn"];
            textBox2.Text = data_rit["B-jarn"];
            textBox3.Text = data_rit["C-jarn"];
            textBox4.Text = data_rit["D-jarn"];
            textBox5.Text = data_rit["N-jarn"];
            textBox6.Text = data_rit["grskr"];
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            data_rit["A-jarn"] = textBox1.Text;
            data_rit["B-jarn"] = textBox2.Text;
            data_rit["C-jarn"] = textBox3.Text;
            data_rit["D-jarn"] = textBox4.Text;
            data_rit["N-jarn"] = textBox5.Text;
            data_rit["grskr"] = textBox6.Text;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) 
            {
                textBox1.Text = "A-järn";
                e.Cancel = true;
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = "B-järn";
                e.Cancel = true;
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.Text = "C-järn";
                e.Cancel = true;
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox4.Text = "D-järn";
                e.Cancel = true;
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                textBox5.Text = "N-järn";
                e.Cancel = true;
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                textBox6.Text = "Grundskruv";
                e.Cancel = true;
            }
        }
    }
}
