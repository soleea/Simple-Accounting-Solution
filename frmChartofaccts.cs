using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using College_Management_System;

namespace SimpleaccountingSys
{
    public partial class frmChartofaccts : Form
    {
        public frmChartofaccts()
        {
            InitializeComponent();
        }
        ConnectionString cs = new ConnectionString();
        SqlCommand cmd = null;
        private void saveonebutton_Click(object sender, EventArgs e)
        {
            if (comboBox1acctype.Text=="")
            {
                MessageBox.Show("Please enter account type");
                return;
            }
            if (textBoxaccounts.Text == "")
            {
                MessageBox.Show("Please enter account");
                textBoxaccounts.Focus();
                return;
            }
            
            SqlConnection con = new SqlConnection(cs.DBConn);
            con.Open();
          
            string cb2 = "insert into Accounts (Account_type,Account) values(@a1,@a2) ";

            cmd = new SqlCommand(cb2);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@a1", comboBox1acctype.Text);//
            cmd.Parameters.AddWithValue("@a2", textBoxaccounts.Text);//

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Saved.....................");
            reset();
            load();
        }
        void reset()
        {
            textBoxaccounts.Text = "";
            comboBox1acctype.Text = "";
            accountid = "";
        }
        string accountid = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1acctype.Text == "")
            {
                MessageBox.Show("Please enter account type");
                return;
            }
            if (textBoxaccounts.Text == "")
            {
                MessageBox.Show("Please enter account");
                textBoxaccounts.Focus();
                return;
            }
            SqlConnection con = new SqlConnection(cs.DBConn);
            con.Open();
           
            string cb2 = "update Accounts set Account_type=@a1,Account=@a2 where Account_id=@a3 ";

            cmd = new SqlCommand(cb2);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@a1", comboBox1acctype.Text);
            cmd.Parameters.AddWithValue("@a2", textBoxaccounts.Text);
            cmd.Parameters.AddWithValue("@a3", accountid);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated.....................");
            reset();
            load();
        }
        void load()
        {
            SqlConnection con = new SqlConnection(cs.DBConn);
            con.Open();
            DataSet sqlDatasetbunit = new DataSet();
            SqlDataAdapter FacultyDataAdapter2 = new SqlDataAdapter();

            string cb2 = "select * from Accounts ";

            cmd = new SqlCommand(cb2);
            cmd.Connection = con;
            FacultyDataAdapter2.SelectCommand = cmd;
            FacultyDataAdapter2.Fill(sqlDatasetbunit, "Accounts");
            dataGridView1.DataSource = sqlDatasetbunit.Tables[0];
            dataGridView1.Columns[0].Visible = false;//hide the id column. this will be used for update purpose
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                load();
            }
            catch(Exception exe)//always place try and catch in your code to prevent annoying errors........................
            {

            }
        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            reset();//clear data from textbox or combo before adding selected item
            int ty = dataGridView1.SelectedRows[0].Index;
           
            accountid = dataGridView1[0, ty].Value.ToString().Trim();// id is located in column 0
            if (accountid == "")// check it is not empty
            {
                MessageBox.Show("Please ensure you select the right data");
                return;
            }
            SqlConnection con = new SqlConnection(cs.DBConn);
            con.Open();

            string activitylog = "select * from accounts where Account_id=@a1 ";//select item to update based on id selected from grid
          

             cmd = new SqlCommand(activitylog, con);
             cmd.Parameters.AddWithValue("@a1", SqlDbType.Int).Value = accountid;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                comboBox1acctype.Text=rdr[1].ToString().Trim();// pass value to textbox or combox
                textBoxaccounts.Text = rdr[2].ToString().Trim();
            }
            rdr.Close();
            con.Close();
        }
    }
}
