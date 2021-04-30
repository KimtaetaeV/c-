using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SimpleCrawler myCrawler = new SimpleCrawler();
        public Form1()
        {
            
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Action<string> action = s => { richTextBox1.Text+= "正在爬取：\n" + s + "已完成 \n"; };
            myCrawler.max = numberBar.Value-1;
            myCrawler.urls.Add(urlBox.Text, false);
            myCrawler.Crawl2(urlBox.Text, action);
        }

        private void numberBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.numberBox.Text = numberBar.Value.ToString();
        }
    }
}
