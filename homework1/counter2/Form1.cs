using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace counter2
{
    public partial class Form1 : Form
    {
        int a = 0, b = 0, c = 0;
        string s = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            s = "+";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            s = "-";
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            s = "*";
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            s = "/";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (text1.Text == "" || text2.Text == "")
            {
                label1.Text = "数字不可为空！";
            }
            else
            {
                string p = text1.Text;
                string q = text2.Text;
                a = Int32.Parse(p);
                b = Int32.Parse(q);
                switch (s)
                {
                    case "+":c = a + b;break;
                    case "-": c = a - b;break;
                    case "*": c = a * b; break;
                    case "/": c = a / b; break;
                }
                label1.Text = "结果为："+c.ToString();
            }
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void text1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
