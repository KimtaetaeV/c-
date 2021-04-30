
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.urlBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.crwal_btn = new System.Windows.Forms.Button();
            this.numberBox = new System.Windows.Forms.TextBox();
            this.numberBar = new System.Windows.Forms.VScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // urlBox
            // 
            this.urlBox.Location = new System.Drawing.Point(115, 18);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(308, 28);
            this.urlBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "网址：";
            // 
            // crwal_btn
            // 
            this.crwal_btn.Location = new System.Drawing.Point(688, 14);
            this.crwal_btn.Name = "crwal_btn";
            this.crwal_btn.Size = new System.Drawing.Size(86, 36);
            this.crwal_btn.TabIndex = 2;
            this.crwal_btn.Text = "爬行";
            this.crwal_btn.UseVisualStyleBackColor = true;
            this.crwal_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // numberBox
            // 
            this.numberBox.Location = new System.Drawing.Point(559, 18);
            this.numberBox.Name = "numberBox";
            this.numberBox.ReadOnly = true;
            this.numberBox.Size = new System.Drawing.Size(49, 28);
            this.numberBox.TabIndex = 3;
            // 
            // numberBar
            // 
            this.numberBar.LargeChange = 1;
            this.numberBar.Location = new System.Drawing.Point(611, 18);
            this.numberBar.Maximum = 10;
            this.numberBar.Minimum = 1;
            this.numberBar.Name = "numberBar";
            this.numberBar.Size = new System.Drawing.Size(26, 28);
            this.numberBar.TabIndex = 4;
            this.numberBar.Value = 1;
            this.numberBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.numberBar_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(474, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "爬取次数";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(36, 70);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(738, 341);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numberBar);
            this.Controls.Add(this.numberBox);
            this.Controls.Add(this.crwal_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.urlBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button crwal_btn;
        private System.Windows.Forms.TextBox numberBox;
        private System.Windows.Forms.VScrollBar numberBar;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RichTextBox richTextBox1;
    }
}

