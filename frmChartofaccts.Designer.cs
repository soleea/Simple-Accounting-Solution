namespace SimpleaccountingSys
{
    partial class frmChartofaccts
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxaccounts = new System.Windows.Forms.TextBox();
            this.businessbutton3 = new System.Windows.Forms.Button();
            this.oktwobutton = new System.Windows.Forms.Button();
            this.saveonebutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1acctype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(269, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(427, 285);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 158;
            this.label2.Text = "Accounts";
            // 
            // textBoxaccounts
            // 
            this.textBoxaccounts.Location = new System.Drawing.Point(96, 91);
            this.textBoxaccounts.Name = "textBoxaccounts";
            this.textBoxaccounts.Size = new System.Drawing.Size(127, 20);
            this.textBoxaccounts.TabIndex = 157;
            // 
            // businessbutton3
            // 
            this.businessbutton3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.businessbutton3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.businessbutton3.Location = new System.Drawing.Point(205, 137);
            this.businessbutton3.Name = "businessbutton3";
            this.businessbutton3.Size = new System.Drawing.Size(50, 25);
            this.businessbutton3.TabIndex = 168;
            this.businessbutton3.Text = "Close";
            this.businessbutton3.UseVisualStyleBackColor = true;
            this.businessbutton3.Visible = false;
            // 
            // oktwobutton
            // 
            this.oktwobutton.Enabled = false;
            this.oktwobutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.oktwobutton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oktwobutton.Location = new System.Drawing.Point(151, 137);
            this.oktwobutton.Name = "oktwobutton";
            this.oktwobutton.Size = new System.Drawing.Size(50, 25);
            this.oktwobutton.TabIndex = 167;
            this.oktwobutton.Text = "Delete";
            this.oktwobutton.UseVisualStyleBackColor = true;
            // 
            // saveonebutton
            // 
            this.saveonebutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveonebutton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.saveonebutton.Location = new System.Drawing.Point(15, 137);
            this.saveonebutton.Name = "saveonebutton";
            this.saveonebutton.Size = new System.Drawing.Size(50, 25);
            this.saveonebutton.TabIndex = 165;
            this.saveonebutton.Text = "Save";
            this.saveonebutton.UseVisualStyleBackColor = true;
            this.saveonebutton.Click += new System.EventHandler(this.saveonebutton_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(72, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 25);
            this.button1.TabIndex = 166;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1acctype
            // 
            this.comboBox1acctype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1acctype.FormattingEnabled = true;
            this.comboBox1acctype.Items.AddRange(new object[] {
            "Income",
            "Expense"});
            this.comboBox1acctype.Location = new System.Drawing.Point(96, 43);
            this.comboBox1acctype.Name = "comboBox1acctype";
            this.comboBox1acctype.Size = new System.Drawing.Size(127, 21);
            this.comboBox1acctype.TabIndex = 169;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 170;
            this.label1.Text = "Account Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(7, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 40);
            this.label3.TabIndex = 171;
            this.label3.Text = "You can Double click on any cell\r\nto edit item and update";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(11, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 40);
            this.label4.TabIndex = 172;
            this.label4.Text = "This is where you create your\r\nChart of accounts with categories";
            // 
            // frmChartofaccts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 308);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1acctype);
            this.Controls.Add(this.businessbutton3);
            this.Controls.Add(this.oktwobutton);
            this.Controls.Add(this.saveonebutton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxaccounts);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmChartofaccts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chart Of Accounts";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxaccounts;
        private System.Windows.Forms.Button businessbutton3;
        private System.Windows.Forms.Button oktwobutton;
        private System.Windows.Forms.Button saveonebutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1acctype;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

