namespace memory_allocation
{
    partial class Form1
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
            this.numh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.datagridview1 = new System.Windows.Forms.DataGridView();
            this.submit = new System.Windows.Forms.Button();
            this.nump = new System.Windows.Forms.TextBox();
            this.submit2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.process_size = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.deallocate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // numh
            // 
            this.numh.Location = new System.Drawing.Point(140, 44);
            this.numh.Name = "numh";
            this.numh.Size = new System.Drawing.Size(71, 20);
            this.numh.TabIndex = 0;
            this.numh.TextChanged += new System.EventHandler(this.numh_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of holes";
            // 
            // datagridview1
            // 
            this.datagridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview1.Location = new System.Drawing.Point(12, 80);
            this.datagridview1.Name = "datagridview1";
            this.datagridview1.Size = new System.Drawing.Size(427, 254);
            this.datagridview1.TabIndex = 2;
            this.datagridview1.Visible = false;
            this.datagridview1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview1_CellContentClick);
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(172, 340);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 3;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // nump
            // 
            this.nump.Location = new System.Drawing.Point(151, 44);
            this.nump.Name = "nump";
            this.nump.Size = new System.Drawing.Size(71, 20);
            this.nump.TabIndex = 4;
            this.nump.Visible = false;
            this.nump.TextChanged += new System.EventHandler(this.nump_TextChanged);
            // 
            // submit2
            // 
            this.submit2.Location = new System.Drawing.Point(329, 90);
            this.submit2.Name = "submit2";
            this.submit2.Size = new System.Drawing.Size(75, 23);
            this.submit2.TabIndex = 6;
            this.submit2.Text = "submit";
            this.submit2.UseVisualStyleBackColor = true;
            this.submit2.Visible = false;
            this.submit2.Click += new System.EventHandler(this.submit2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "First fit",
            "Best fit"});
            this.comboBox1.Location = new System.Drawing.Point(342, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(97, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Allocation Type";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "process size";
            this.label3.Visible = false;
            // 
            // process_size
            // 
            this.process_size.Location = new System.Drawing.Point(339, 119);
            this.process_size.Name = "process_size";
            this.process_size.Size = new System.Drawing.Size(100, 20);
            this.process_size.TabIndex = 10;
            this.process_size.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "allocate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(55, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 366);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "deallocate process number :";
            this.label4.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(322, 231);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(82, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.Visible = false;
            // 
            // deallocate
            // 
            this.deallocate.Location = new System.Drawing.Point(329, 257);
            this.deallocate.Name = "deallocate";
            this.deallocate.Size = new System.Drawing.Size(75, 23);
            this.deallocate.TabIndex = 15;
            this.deallocate.Text = "deallocate";
            this.deallocate.UseVisualStyleBackColor = true;
            this.deallocate.Visible = false;
            this.deallocate.Click += new System.EventHandler(this.deallocate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 390);
            this.Controls.Add(this.deallocate);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.process_size);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.submit2);
            this.Controls.Add(this.nump);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.datagridview1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numh);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint_1);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox numh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView datagridview1;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.TextBox nump;
        private System.Windows.Forms.Button submit2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox process_size;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button deallocate;
    }
}

