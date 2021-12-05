namespace MyExcel
{
    partial class MyExcel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зберегтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.відкритиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редагуватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.довідкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.додатиРядокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видалитиРядокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.додатиСтовпчикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видалитиСтовпчикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.редагуватиToolStripMenuItem,
            this.довідкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1146, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.зберегтиToolStripMenuItem,
            this.відкритиToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.fileToolStripMenuItem.Text = "Файл";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // зберегтиToolStripMenuItem
            // 
            this.зберегтиToolStripMenuItem.Name = "зберегтиToolStripMenuItem";
            this.зберегтиToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.зберегтиToolStripMenuItem.Text = "Зберегти";
            this.зберегтиToolStripMenuItem.Click += new System.EventHandler(this.зберегтиToolStripMenuItem_Click);
            // 
            // відкритиToolStripMenuItem
            // 
            this.відкритиToolStripMenuItem.Name = "відкритиToolStripMenuItem";
            this.відкритиToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.відкритиToolStripMenuItem.Text = "Відкрити";
            this.відкритиToolStripMenuItem.Click += new System.EventHandler(this.відкритиToolStripMenuItem_Click_1);
            // 
            // редагуватиToolStripMenuItem
            // 
            this.редагуватиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.додатиРядокToolStripMenuItem,
            this.видалитиРядокToolStripMenuItem,
            this.додатиСтовпчикToolStripMenuItem,
            this.видалитиСтовпчикToolStripMenuItem});
            this.редагуватиToolStripMenuItem.Name = "редагуватиToolStripMenuItem";
            this.редагуватиToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.редагуватиToolStripMenuItem.Text = "Редагувати";
            // 
            // довідкаToolStripMenuItem
            // 
            this.довідкаToolStripMenuItem.Name = "довідкаToolStripMenuItem";
            this.довідкаToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.довідкаToolStripMenuItem.Text = "Довідка";
            this.довідкаToolStripMenuItem.Click += new System.EventHandler(this.довідкаToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(233, 22);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ввести";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(419, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 31);
            this.button2.TabIndex = 3;
            this.button2.Text = "Додати рядок";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(547, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 31);
            this.button3.TabIndex = 4;
            this.button3.Text = "Видалити рядок";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(705, 35);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(142, 31);
            this.button4.TabIndex = 5;
            this.button4.Text = "Додати стовпчик";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(853, 35);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(152, 31);
            this.button5.TabIndex = 6;
            this.button5.Text = "Видалити стовпчик";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1145, 478);
            this.dataGridView1.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // додатиРядокToolStripMenuItem
            // 
            this.додатиРядокToolStripMenuItem.Name = "додатиРядокToolStripMenuItem";
            this.додатиРядокToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.додатиРядокToolStripMenuItem.Text = "Додати рядок";
            this.додатиРядокToolStripMenuItem.Click += new System.EventHandler(this.додатиРядокToolStripMenuItem_Click);
            // 
            // видалитиРядокToolStripMenuItem
            // 
            this.видалитиРядокToolStripMenuItem.Name = "видалитиРядокToolStripMenuItem";
            this.видалитиРядокToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.видалитиРядокToolStripMenuItem.Text = "Видалити рядок";
            this.видалитиРядокToolStripMenuItem.Click += new System.EventHandler(this.видалитиРядокToolStripMenuItem_Click);
            // 
            // додатиСтовпчикToolStripMenuItem
            // 
            this.додатиСтовпчикToolStripMenuItem.Name = "додатиСтовпчикToolStripMenuItem";
            this.додатиСтовпчикToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.додатиСтовпчикToolStripMenuItem.Text = "Додати стовпчик";
            this.додатиСтовпчикToolStripMenuItem.Click += new System.EventHandler(this.додатиСтовпчикToolStripMenuItem_Click);
            // 
            // видалитиСтовпчикToolStripMenuItem
            // 
            this.видалитиСтовпчикToolStripMenuItem.Name = "видалитиСтовпчикToolStripMenuItem";
            this.видалитиСтовпчикToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.видалитиСтовпчикToolStripMenuItem.Text = "Видалити стовпчик";
            this.видалитиСтовпчикToolStripMenuItem.Click += new System.EventHandler(this.видалитиСтовпчикToolStripMenuItem_Click);
            // 
            // MyExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 550);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MyExcel";
            this.Text = "MyExcel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редагуватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem довідкаToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem зберегтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem відкритиToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem додатиРядокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видалитиРядокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem додатиСтовпчикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видалитиСтовпчикToolStripMenuItem;
    }
}

