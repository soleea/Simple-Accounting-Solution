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
    public partial class frmcustomers : Form
    {
        public frmcustomers()
        {
            InitializeComponent();
        }
        ConnectionString cs = new ConnectionString();
        SqlCommand cmd = null;
        private void saveonebutton_Click(object sender, EventArgs e)
        {
            if (textBox1address.Text == "")
            {
                MessageBox.Show("Please enter address");
                textBox1address.Focus();
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

            string cb2 = "insert into Customers (Customer_name,Phone,Address) values(@a1,@a2,@a3) ";

            cmd = new SqlCommand(cb2);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@a1", textBoxaccounts.Text);//
            cmd.Parameters.AddWithValue("@a2", textBox1acctno.Text);//
            cmd.Parameters.AddWithValue("@a3", textBox1address.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Saved.....................");
            reset();
            load();
        }
        void reset()
        {
            textBox1address.Text = "";
            textBoxaccounts.Text = "";
            textBox1acctno.Text = "";
        }
        string accountid = "";
        private void button1_Click(object sender, EventArgs e)
        {
             if (textBox1address.Text == "")
            {
                MessageBox.Show("Please enter address");
                textBox1address.Focus();
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

            string cb2 = "update Customers set Customer_name=@a1,Phone=@a2,Address=@a4 where Cus_id=@a3 ";

            cmd = new SqlCommand(cb2);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@a1", textBoxaccounts.Text);
            cmd.Parameters.AddWithValue("@a2", textBox1acctno.Text);
            cmd.Parameters.AddWithValue("@a4", textBox1address.Text);
            cmd.Parameters.AddWithValue("@a3", accountid);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated.....................");
            reset();
            load();
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

            string activitylog = "select * from Customers where Cus_id=@a1 ";//select item to update based on id selected from grid


            cmd = new SqlCommand(activitylog, con);
            cmd.Parameters.AddWithValue("@a1", SqlDbType.Int).Value = accountid;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                textBoxaccounts.Text = rdr[1].ToString().Trim();// pass value to textbox or combox
                textBox1acctno.Text = rdr[2].ToString().Trim();// pass value to textbox or combox
                textBox1address.Text = rdr[3].ToString().Trim();// pass value to textbox or combox


            }
            rdr.Close();
            con.Close();
        }
        void load()
        {
            SqlConnection con = new SqlConnection(cs.DBConn);
            con.Open();
            DataSet sqlDatasetbunit = new DataSet();
            SqlDataAdapter FacultyDataAdapter2 = new SqlDataAdapter();

            string cb2 = "select * from Customers ";

            cmd = new SqlCommand(cb2);
            cmd.Connection = con;
            FacultyDataAdapter2.SelectCommand = cmd;
            FacultyDataAdapter2.Fill(sqlDatasetbunit, "Customers");
            dataGridView1.DataSource = sqlDatasetbunit.Tables[0];
            dataGridView1.Columns[0].Visible = false;//hide the id column. this will be used for update purpose
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void frmcustomers_Load(object sender, EventArgs e)
        {
            try
            {
                load();
            }
            catch (Exception exe)//always place try and catch in your code to prevent annoying errors........................
            {

            }
        }
    }
}
