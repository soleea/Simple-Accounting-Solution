namespace SimpleaccountingSys
{
    partial class frmcashbank
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1acctype = new System.Windows.Forms.ComboBox();
            this.businessbutton3 = new System.Windows.Forms.Button();
            this.oktwobutton = new System.Windows.Forms.Button();
            this.saveonebutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxaccounts = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1acctno = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 179;
            this.label1.Text = "Category";
            // 
            // comboBox1acctype
            // 
            this.comboBox1acctype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1acctype.FormattingEnabled = true;
            this.comboBox1acctype.Items.AddRange(new object[] {
            "Bank",
            "Cash"});
            this.comboBox1acctype.Location = new System.Drawing.Point(113, 110);
            this.comboBox1acctype.Name = "comboBox1acctype";
            this.comboBox1acctype.Size = new System.Drawing.Size(127, 21);
            this.comboBox1acctype.TabIndex = 178;
            // 
            // businessbutton3
            // 
            this.businessbutton3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.businessbutton3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.businessbutton3.Location = new System.Drawing.Point(222, 168);
            this.businessbutton3.Name = "businessbutton3";
            this.businessbutton3.Size = new System.Drawing.Size(50, 25);
            this.businessbutton3.TabIndex = 177;
            this.businessbutton3.Text = "Close";
            this.businessbutton3.UseVisualStyleBackColor = true;
            this.businessbutton3.Visible = false;
            // 
            // oktwobutton
            // 
            this.oktwobutton.Enabled = false;
            this.oktwobutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.oktwobutton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oktwobutton.Location = new System.Drawing.Point(168, 168);
            this.oktwobutton.Name = "oktwobutton";
            this.oktwobutton.Size = new System.Drawing.Size(50, 25);
            this.oktwobutton.TabIndex = 176;
            this.oktwobutton.Text = "Delete";
            this.oktwobutton.UseVisualStyleBackColor = true;
            // 
            // saveonebutton
            // 
            this.saveonebutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveonebutton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.saveonebutton.Location = new System.Drawing.Point(32, 168);
            this.saveonebutton.Name = "saveonebutton";
            this.saveonebutton.Size = new System.Drawing.Size(50, 25);
            this.saveonebutton.TabIndex = 174;
            this.saveonebutton.Text = "Save";
            this.saveonebutton.UseVisualStyleBackColor = true;
            this.saveonebutton.Click += new System.EventHandler(this.saveonebutton_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(89, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 25);
            this.button1.TabIndex = 175;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 173;
            this.label2.Text = "Account Names";
            // 
            // textBoxaccounts
            // 
            this.textBoxaccounts.Location = new System.Drawing.Point(113, 19);
            this.textBoxaccounts.Name = "textBoxaccounts";
            this.textBoxaccounts.Size = new System.Drawing.Size(170, 20);
            this.textBoxaccounts.TabIndex = 172;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(316, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 305);
            this.dataGridView1.TabIndex = 171;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(28, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 40);
            this.label4.TabIndex = 181;
            this.label4.Text = "This is where you create your\r\nBank or Cash Accounts";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(24, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 40);
            this.label3.TabIndex = 180;
            this.label3.Text = "You can Double click on any cell\r\nto edit item and update";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 183;
            this.label5.Text = "Account no";
            // 
            // textBox1acctno
            // 
            this.textBox1acctno.Location = new System.Drawing.Point(113, 59);
            this.textBox1acctno.Name = "textBox1acctno";
            this.textBox1acctno.Size = new System.Drawing.Size(170, 20);
            this.textBox1acctno.TabIndex = 182;
            // 
            // frmcashbank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 329);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1acctno);
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
            this.Name = "frmcashbank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cash/Bank Form";
            this.Load += new System.EventHandler(this.frmcashbank_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1acctype;
        private System.Windows.Forms.Button businessbutton3;
        private System.Windows.Forms.Button oktwobutton;
        private System.Windows.Forms.Button saveonebutton;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxaccounts;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1acctno;
    }
}