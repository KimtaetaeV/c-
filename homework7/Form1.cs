using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dept.GotFocus += new EventHandler(dept_MouseDown); //
            len.GotFocus += new EventHandler(len_MouseDown); //
            textBox2.GotFocus += new EventHandler(textBox2_MouseDown); //
            textBox3.GotFocus += new EventHandler(textBox3_MouseDown); //
            textBox4.GotFocus += new EventHandler(textBox4_MouseDown); //
            textBox5.GotFocus += new EventHandler(textBox5_MouseDown); //


        }

        private Graphics graphics;
        double th1;
        double th2;
        double per1;
        double per2;
        int n;
        int leng;

        void drawGayLayTree(int n, double x0, double y0,double  leng,double th)
        {
            
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawGayLayTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawGayLayTree(n - 1, x1, y1, per2 * leng, th - th2);

        }

        void drawLine(double x0,double  y0,double x1,double y1)
        {

            switch (color.SelectedIndex)
            {
                case 0:
                    graphics.DrawLine(
                Pens.Black, (int)x0, (int)y0, (int)x1, (int)y1);break;
                case 1:
                    graphics.DrawLine(
                Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);break;
                case 2:
                    graphics.DrawLine(
                Pens.Red , (int)x0, (int)y0, (int)x1, (int)y1);break;
                default:break;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            panel1.Hide();
            th1 = Double.Parse(textBox5.Text) * Math.PI / 180;
            th2 = Double.Parse(textBox4.Text) * Math.PI / 180;
            per1 = Double.Parse(textBox3.Text);
            per2 = Double.Parse(textBox2.Text);
            n = Int32.Parse(dept.Text);
            leng = Int32.Parse(len.Text);
            if (graphics == null) graphics = this.CreateGraphics();
            drawGayLayTree(n, 200, 310,leng, -Math.PI /2);
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

     
        private void dept_MouseDown(object sender, EventArgs e)
        {
            if (this.dept.Text == "（1-30）")
            {
                this.dept.Text = "";
            }
        }

        private void len_MouseDown(object sender, EventArgs e)
        {
            if (this.len.Text == "（10-120）")
            {
                this.len.Text = "";
            }
        }


        private void textBox2_MouseDown(object sender, EventArgs e)
        {
            if (this.textBox2.Text == "（0-1）")
            {
                this.textBox2.Text = " ";
            }
        }
        private void textBox3_MouseDown(object sender, EventArgs e)
        {
            if (this.textBox3.Text == "（0-1）")
            {
                this.textBox3.Text = " ";
            }
        }
        private void textBox4_MouseDown(object sender, EventArgs e)
        {
            if (textBox4.Text == "（0-90）")
            {
                this.textBox4.Text = " ";
            }
        }

        private void textBox5_MouseDown(object sender, EventArgs e)
        {
            if (textBox5.Text == "（0-90）")
            {
                this.textBox5.Text = " ";
            }
        }




    }
}
