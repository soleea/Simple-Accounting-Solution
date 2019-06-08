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

namespace E_examination
{
    public partial class frmpayment : Form
    {
        public frmpayment()
        {
            InitializeComponent();
        }

        private void textBoxdrsalary_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //get the textbox that fired the event
                var textBox = sender as TextBox;
                if (textBox == null) return;

                var text = textBox.Text;
                var output = new StringBuilder();
                //use this boolean to determine if the dot already exists
                //in the text so far.
                var dotEncountered = false;
                //loop through all of the text
                for (int i = 0; i < text.Length; i++)
                {
                    var c = text[i];
                    if (char.IsDigit(c))
                    {
                        //append any digit.
                        output.Append(c);
                    }
                    else if (!dotEncountered && c == '.')
                    {
                        //append the first dot encountered
                        output.Append(c);
                        dotEncountered = true;
                    }
                }
                var newText = output.ToString();
                textBox.Text = newText;
                //calago();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        DataSet sqlDatasetaccounts = new DataSet();
        ConnectionString cs = new ConnectionString();
        void account()
        {
            sqlDatasetaccounts.Clear();
            SqlDataAdapter FacultyDataAdapter2 = new SqlDataAdapter();
            string cmdStringbunit = " select Id,Cash_type" +
                    " from Cash_Bank";
            SqlConnection myconnection = new SqlConnection(cs.DBConn);
            myconnection.Open();
            SqlCommand sqlCommandbunit = new SqlCommand(cmdStringbunit, myconnection);

            FacultyDataAdapter2.SelectCommand = sqlCommandbunit;
            FacultyDataAdapter2.Fill(sqlDatasetaccounts, "Cash_type");
            comboBox1acct.DataSource = sqlDatasetaccounts.Tables[0];
            comboBox1acct.ValueMember = "Id";
            comboBox1acct.DisplayMember = "Cash_type";
            comboBox1acct.SelectedIndex = -1;
            myconnection.Close();
        }
        void Chartofaccounts()
        {
            DataSet mydataset = new DataSet();
            SqlDataAdapter FacultyDataAdapter2 = new SqlDataAdapter();
            string cmdStringbunit = " select Account_id,Account" +
                    " from Accounts";
            SqlConnection myconnection = new SqlConnection(cs.DBConn);
            myconnection.Open();
            SqlCommand sqlCommandbunit = new SqlCommand(cmdStringbunit, myconnection);

            FacultyDataAdapter2.SelectCommand = sqlCommandbunit;
            FacultyDataAdapter2.Fill(mydataset, "Accounts");
            comboBox1accts.DataSource = mydataset.Tables[0];
            comboBox1accts.ValueMember = "Account_id";
            comboBox1accts.DisplayMember = "Account";
            comboBox1accts.SelectedIndex = -1;
            myconnection.Close();
        }
        DataSet sqlDatasetbunit = new DataSet();
        void customernm()
        {
            //sqlDatasetbunit.Clear();
            sqlDatasetbunit.Reset();
            SqlDataAdapter FacultyDataAdapter2 = new SqlDataAdapter();
            string cmdStringbunit = " select Cus_id,Customer_name" +
                    " from Customers ";
            SqlConnection myconnection = new SqlConnection(cs.DBConn);
            myconnection.Open();
            SqlCommand sqlCommandbunit = new SqlCommand(cmdStringbunit, myconnection);
            //sqlCommandbunit.Parameters.AddWithValue("@a1", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            FacultyDataAdapter2.SelectCommand = sqlCommandbunit;
            FacultyDataAdapter2.Fill(sqlDatasetbunit, "Customers");
            comboBoxcust.DataSource = sqlDatasetbunit.Tables[0];
            comboBoxcust.ValueMember = "Cus_id";
            comboBoxcust.DisplayMember = "Customer_name";
            comboBoxcust.SelectedIndex = -1;
            myconnection.Close();
        }
        private void frmpayment_Load(object sender, EventArgs e)
        {
            customernm();
            account();
            getdata();
            Chartofaccounts();
        }
        void getdata()
        {
            SqlCommand cmd = null;
            SqlConnection con = new SqlConnection(cs.DBConn);
            con.Open();
            DataSet sqlDatasetbunit = new DataSet();
            SqlDataAdapter FacultyDataAdapter2 = new SqlDataAdapter();

            string cb2 = "select TFinancials.names as Name,TFinancials.FDate as Date,Cash_Bank.Cash_type," +
                "TFinancials.CID,TFinancials.id," +
                       "TFinancials.FCredit,TFinancials.FDebit,TFinancials.Particular,TFinancials.FID from TFinancials" +
             " inner join Cash_Bank ON TFinancials.id = Cash_Bank.id where TFinancials.FDate>=@a1 and TFinancials.FDate<=@a2";
            
            cmd = new SqlCommand(cb2);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@a1", dateTimePicker3.Value.Date);//
            cmd.Parameters.AddWithValue("@a2", dateTimePicker4.Value.Date);//
            FacultyDataAdapter2.SelectCommand = cmd;
            FacultyDataAdapter2.Fill(sqlDatasetbunit, "TFinancials");
            dataGridView1.DataSource = sqlDatasetbunit.Tables[0];
            dataGridView1.Columns[8].Visible = false;//hide the transaction id
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
           
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void saveonebutton_Click(object sender, EventArgs e)
        {
            if (comboBoxcust.Text.Trim()=="")
            {
                MessageBox.Show("Please enter customer name");
                comboBoxcust.Focus();
                return;
            }//
            if (comboBox1accts.Text.Trim() == "")
            {
                MessageBox.Show("Please select account");
                comboBox1accts.Focus();
                return;
            }
            if (textBox1partic.Text.Trim() == "")
            {
                MessageBox.Show("Please give a detail description of what this transaction is all about");
                textBox1partic.Focus();
                return;
            }
            if (textBoxdramt.Text.Trim() == "")//
            {
                MessageBox.Show("Please enter amount");
                textBoxdramt.Focus();
                return;
            }
            if (comboBoxdbcr.Text.Trim() == "")//comboBoxdbcr
            {
                MessageBox.Show("Please select Debit or Credit");
                comboBoxdbcr.Focus();
                return;
            }
            if (comboBox1acct.Text.Trim() == "")//comboBoxdbcr
            {
                MessageBox.Show("Please select account type");
                comboBox1acct.Focus();
                return;
            }
            SqlCommand cmd = null;
            SqlConnection con = new SqlConnection(cs.DBConn);
            con.Open();

            string cb2 = "insert Into TFinancials(FDate,CID,id,Particular," +
                       "FCredit,FDebit,names,Account_id)" +
             " VALUES (@FDate,@CID,@id,@Particular,@FCredit,@FDebit,@names,@Account_id)";

            cmd = new SqlCommand(cb2);
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@FDate", dtpInvoiceDateFrom.Value.Date);
            cmd.Parameters.AddWithValue("@names", comboBoxcust.Text);
            cmd.Parameters.AddWithValue("@Account_id", comboBox1accts.SelectedValue);
            if (comboBoxcust.SelectedValue == null)//if no customer id found 
            {
            cmd.Parameters.AddWithValue("@CID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CID", comboBoxcust.SelectedValue);
            }

            cmd.Parameters.AddWithValue("@id", comboBox1acct.SelectedValue);


            if (comboBoxdbcr.Text.Trim() == "Debit")
            {
                cmd.Parameters.AddWithValue("@FDebit", textBoxdramt.Text);
                cmd.Parameters.AddWithValue("@FCredit", 0);
                
             }
            else
            {
                cmd.Parameters.AddWithValue("@FDebit", 0);
                cmd.Parameters.AddWithValue("@FCredit", textBoxdramt.Text);
               
           }
            cmd.Parameters.AddWithValue("@Particular", textBox1partic.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved successfully");
            con.Close();
            
            reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                getdata();
            }
            catch(Exception exe)
            {
                MessageBox.Show("Error "+exe);
            }
        }
        void reset()
        {
            textBox1partic.Text = "";
            comboBoxdbcr.Text = "";
            textBoxdramt.Text = "";
            accountid = "";
            saveonebutton.Enabled = true;
            button1.Enabled = false;
            oktwobutton.Enabled = false;
          
        }
        private void businessbutton3_Click(object sender, EventArgs e)
        {

        }
        string accountid = "";
        void select()
        {
            int ty = dataGridView1.SelectedRows[0].Index;
            //val = dataGridView1[7, ty].Value.ToString();
            accountid = dataGridView1[8, ty].Value.ToString().Trim();
            if (accountid == "")
            {
                MessageBox.Show("Please ensure you select the right data");
                return;
            }
            SqlConnection myconnection = new SqlConnection(cs.DBConn);
            myconnection.Open();

            string activitylog = "select TFinancials.id,TFinancials.names,TFinancials.FDate," +
             "TFinancials.FCredit,TFinancials.FDebit,TFinancials.Particular,TFinancials.Account_id,TFinancials.cid from TFinancials" +
           " inner join Cash_Bank ON TFinancials.id = Cash_Bank.id where TFinancials.FID=@a1";
          

             SqlCommand sqlDataTableactivitylog = new SqlCommand(activitylog, myconnection);
             sqlDataTableactivitylog.Parameters.AddWithValue("@a1", SqlDbType.Int).Value = accountid;
            SqlDataReader rdr = sqlDataTableactivitylog.ExecuteReader();
            while (rdr.Read())
            {
                 
                comboBox1acct.SelectedValue = rdr[0].ToString().Trim();
              
                    comboBoxcust.Text = rdr[1].ToString().Trim();
                    
               
                
                dtpInvoiceDateFrom.Text = rdr[2].ToString().Trim();
                if (Convert.ToDecimal(rdr[3].ToString().Trim())>0)
                {
                textBoxdramt.Text = rdr[3].ToString().Trim();
                comboBoxdbcr.Text = "Credit";
                }
                else
                {
                    textBoxdramt.Text = rdr[4].ToString().Trim();
                    comboBoxdbcr.Text = "Debit";
                }
                comboBox1accts.SelectedValue = rdr[6].ToString().Trim();
                textBox1partic.Text = rdr[5].ToString().Trim();
                
              
            }
            rdr.Close();
            myconnection.Close();
            
            button1.Enabled = true;
                oktwobutton.Enabled = true;
                saveonebutton.Enabled = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            reset();
            select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxcust.Text.Trim() == "")
            {
                MessageBox.Show("Please enter customer name");
                comboBoxcust.Focus();
                return;
            }
                if (comboBox1accts.Text.Trim() == "")
            {
                MessageBox.Show("Please select account");
                comboBox1accts.Focus();
                return;
            }
            if (textBox1partic.Text.Trim() == "")
            {
                MessageBox.Show("Please give a detail description of what this transaction is all about");
                textBox1partic.Focus();
                return;
            }
            if (textBoxdramt.Text.Trim() == "")//
            {
                MessageBox.Show("Please enter amount");
                textBoxdramt.Focus();
                return;
            }
            if (comboBoxdbcr.Text.Trim() == "")//comboBoxdbcr
            {
                MessageBox.Show("Please select Debit or Credit");
                comboBoxdbcr.Focus();
                return;
            }
            if (comboBox1acct.Text.Trim() == "")//comboBoxdbcr
            {
                MessageBox.Show("Please select account type");
                comboBox1acct.Focus();
                return;
            }
            SqlCommand cmd = null;
            SqlConnection con = new SqlConnection(cs.DBConn);
            con.Open();

            string cb2 = "update TFinancials set FDate=@FDate,Particular=@Particular,Account_id=@Account_id," +
                       "FCredit=@FCredit,FDebit=@FDebit,names=@names,id=@id,CID=@CID where FID=@FID";
            

            cmd = new SqlCommand(cb2);
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@FDate", dtpInvoiceDateFrom.Value.Date);
            cmd.Parameters.AddWithValue("@names", comboBoxcust.Text);
            cmd.Parameters.AddWithValue("@Account_id", comboBox1accts.SelectedValue);
            if (comboBoxcust.SelectedValue != null)
            {
               
                   
                    cmd.Parameters.AddWithValue("@CID", comboBoxcust.SelectedValue);
               
            }
            else
            {
                cmd.Parameters.AddWithValue("@CID", DBNull.Value);
               
            }
           
            cmd.Parameters.AddWithValue("@id", comboBox1acct.SelectedValue);


            if (comboBoxdbcr.Text.Trim() == "Debit")
            {
                cmd.Parameters.AddWithValue("@FDebit", textBoxdramt.Text);
                cmd.Parameters.AddWithValue("@FCredit", 0);
                
           
            }
            else
            {
                cmd.Parameters.AddWithValue("@FDebit", 0);
                cmd.Parameters.AddWithValue("@FCredit", textBoxdramt.Text);
              
               
            }
            cmd.Parameters.AddWithValue("@Particular", textBox1partic.Text);
            cmd.Parameters.AddWithValue("@FID", accountid.Trim());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated successfully");
            con.Close();

            reset();
        }

        private void oktwobutton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs.DBConn);
            con.Open();

          
                
                    string cq1b = "delete from TFinancials where FID=@a1";
                    SqlCommand cmd = new SqlCommand(cq1b);
                    cmd.Connection = con;
                    //cmd.Transaction = tran;
                    //cmd.Parameters.AddWithValue("@a2", "Sales Invoice");
                    cmd.Parameters.AddWithValue("@a1", accountid.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully");
                    reset();
              

           

            con.Close();
        }
        void drivernm()
        {
            sqlDatasetbunit.Reset();
            SqlDataAdapter FacultyDataAdapter2 = new SqlDataAdapter();
            string cmdStringbunit = " select VID,(RTRIM(DriverName)+' Truck '+RTRIM(Truck_type)) AS Drivernames" +
                    " from tvehicles ";
            SqlConnection myconnection = new SqlConnection(cs.DBConn);
            myconnection.Open();
            SqlCommand sqlCommandbunit = new SqlCommand(cmdStringbunit, myconnection);
          
            FacultyDataAdapter2.SelectCommand = sqlCommandbunit;
            FacultyDataAdapter2.Fill(sqlDatasetbunit, "tvehicles");
            comboBoxcust.DataSource = sqlDatasetbunit.Tables[0];
            comboBoxcust.ValueMember = "VID";
            comboBoxcust.DisplayMember = "Drivernames";
            comboBoxcust.SelectedIndex = -1;
            myconnection.Close();
        }
       

       
        
        
    }
}
