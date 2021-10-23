namespace WindowsFormsApp3
{
    partial class Display_categories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Display_categories));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_show_keywords = new System.Windows.Forms.RadioButton();
            this.radioButton_show_details = new System.Windows.Forms.RadioButton();
            this.dataGridView_show_details = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView_show_keywords = new System.Windows.Forms.DataGridView();
            this.Keyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_show_details)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_show_keywords)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_show_keywords);
            this.groupBox1.Controls.Add(this.radioButton_show_details);
            this.groupBox1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Location = new System.Drawing.Point(325, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Show";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radioButton_show_keywords
            // 
            this.radioButton_show_keywords.AutoSize = true;
            this.radioButton_show_keywords.Location = new System.Drawing.Point(0, 36);
            this.radioButton_show_keywords.Name = "radioButton_show_keywords";
            this.radioButton_show_keywords.Size = new System.Drawing.Size(118, 27);
            this.radioButton_show_keywords.TabIndex = 1;
            this.radioButton_show_keywords.TabStop = true;
            this.radioButton_show_keywords.Text = "Keywords.";
            this.radioButton_show_keywords.UseVisualStyleBackColor = true;
            // 
            // radioButton_show_details
            // 
            this.radioButton_show_details.AutoSize = true;
            this.radioButton_show_details.Location = new System.Drawing.Point(0, 77);
            this.radioButton_show_details.Name = "radioButton_show_details";
            this.radioButton_show_details.Size = new System.Drawing.Size(93, 27);
            this.radioButton_show_details.TabIndex = 2;
            this.radioButton_show_details.TabStop = true;
            this.radioButton_show_details.Text = "Details.";
            this.radioButton_show_details.UseVisualStyleBackColor = true;
            this.radioButton_show_details.CheckedChanged += new System.EventHandler(this.radioButton_show_details_CheckedChanged);
            // 
            // dataGridView_show_details
            // 
            this.dataGridView_show_details.AllowUserToAddRows = false;
            this.dataGridView_show_details.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_show_details.Location = new System.Drawing.Point(26, 157);
            this.dataGridView_show_details.Name = "dataGridView_show_details";
            this.dataGridView_show_details.Size = new System.Drawing.Size(576, 184);
            this.dataGridView_show_details.TabIndex = 2;
            this.dataGridView_show_details.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_show_details_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(541, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 44);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(26, 347);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 54);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(170, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(133, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView_show_keywords
            // 
            this.dataGridView_show_keywords.AllowUserToAddRows = false;
            this.dataGridView_show_keywords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_show_keywords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Keyword});
            this.dataGridView_show_keywords.Location = new System.Drawing.Point(229, 157);
            this.dataGridView_show_keywords.Name = "dataGridView_show_keywords";
            this.dataGridView_show_keywords.Size = new System.Drawing.Size(147, 184);
            this.dataGridView_show_keywords.TabIndex = 6;
            this.dataGridView_show_keywords.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_show_keywords_CellContentClick);
            // 
            // Keyword
            // 
            this.Keyword.HeaderText = "Keyword";
            this.Keyword.Name = "Keyword";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Categories List : ";
            this.label1.UseMnemonic = false;
            // 
            // Display_categories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(646, 404);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_show_keywords);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_show_details);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Display_categories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Display_categories";
            this.Load += new System.EventHandler(this.Display_categories_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_show_details)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_show_keywords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_show_keywords;
        private System.Windows.Forms.RadioButton radioButton_show_details;
        private System.Windows.Forms.DataGridView dataGridView_show_details;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView_show_keywords;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keyword;
        private System.Windows.Forms.Label label1;
    }
}