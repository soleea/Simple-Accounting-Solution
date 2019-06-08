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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace SimpleaccountingSys
{
    public partial class frmcustomerstatements : Form
    {
        public frmcustomerstatements()
        {
            InitializeComponent();
        }
        DataSet sqlDatasetbunit = new DataSet();
        ConnectionString cs = new ConnectionString();
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
            comboBox1acct.DataSource = sqlDatasetbunit.Tables[0];
            comboBox1acct.ValueMember = "Cus_id";
            comboBox1acct.DisplayMember = "Customer_name";
            comboBox1acct.SelectedIndex = -1;
            myconnection.Close();
        }
        private void frmcustomerstatements_Load(object sender, EventArgs e)
        {
            customernm();
        }

        private void button1ok_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
               
                SqlCommand cmd = new SqlCommand();
                SqlConnection myConnection = default(SqlConnection);
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                
                myConnection = new SqlConnection(cs.DBConn);
                cmd.Connection = myConnection;
                
                myConnection.Open();
                   // coolect all previous balances........................................................from both debit and credit.......
                    string cmdStringbunit1 = "SELECT sum(FDebit) as mysum from  TFinancials " +
                   " where  FDate<=@a4 and CID=@a3 ";
                    SqlCommand sqlCommandbunit1 = new SqlCommand(cmdStringbunit1, myConnection);
                    sqlCommandbunit1.Parameters.AddWithValue("@a3", SqlDbType.NVarChar).Value = comboBox1acct.SelectedValue;
                    sqlCommandbunit1.Parameters.AddWithValue("@a4", SqlDbType.NVarChar).Value = dateTimePicker1.Value.Date.AddDays(-1);
                    //sqlCommandbunit1.Parameters.AddWithValue("@a4", SqlDbType.NVarChar).Value = dateTimePicker4.Value.Date;
                    SqlDataReader comp2 = sqlCommandbunit1.ExecuteReader();
                    comp2.Read();
                    string deb = comp2[0].ToString();
                    decimal deb1 = 0;
                    if (deb != "")
                    {
                        deb1 = Convert.ToDecimal(deb);
                    }
                    comp2.Close();

                    string cmdStringbunit12 = "SELECT sum(FCredit) as mysum from  TFinancials " +
                   " where  FDate<=@a4 and CID=@a3";
                    sqlCommandbunit1 = new SqlCommand(cmdStringbunit12, myConnection);
                    //sqlCommandbunit1.Parameters.AddWithValue("@a1", SqlDbType.Int).Value = Convert.ToInt16(val);
                    sqlCommandbunit1.Parameters.AddWithValue("@a3", SqlDbType.NVarChar).Value = comboBox1acct.SelectedValue;
                    sqlCommandbunit1.Parameters.AddWithValue("@a4", SqlDbType.NVarChar).Value = dateTimePicker1.Value.Date.AddDays(-1);
                    comp2 = sqlCommandbunit1.ExecuteReader();
                    comp2.Read();
                    string deb2 = comp2[0].ToString();
                    decimal creditdeb12 = 0;
                    if (deb2 != "")
                    {
                        creditdeb12 = Convert.ToDecimal(deb2);
                    }
                    comp2.Close();
                   
                
                //now add the result to the next query

                    string cmdStrinzz = "SELECT  Customers.Customer_name, Customers.Phone, Customers.Address, TFinancials.Particular," +
                        " TFinancials.FCredit, TFinancials.FDate, TFinancials.FDebit,TFinancials.cid," + deb1 + " as debts," + creditdeb12 + " as credits  " +
                        " FROM            Customers INNER JOIN " +
                        " TFinancials ON Customers.Cus_id = TFinancials.CID where " +
                       "  (TFinancials.FDate >= @a2) AND (TFinancials.FDate <= @a3) and (TFinancials.cid = @a1) ";
                    cmd = new SqlCommand(cmdStrinzz, myConnection);
                    
                    cmd.Parameters.AddWithValue("@a2", SqlDbType.Date).Value = (dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@a3", SqlDbType.Date).Value = (dateTimePicker2.Value.Date);
                    cmd.Parameters.AddWithValue("@a1", SqlDbType.NVarChar).Value = comboBox1acct.SelectedValue;

                   
                    myDA.SelectCommand = cmd;
                    myDA.Fill(myDS, "S_And_C_statment");

                    rptscustomerst rpt3 = new rptscustomerst();

                rpt3.SetDataSource(myDS);



                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();


                crParameterDiscreteValue.Value = "BIG LTD Customer/Supplier Statement "
                    + Environment.NewLine + " For the period of " + dateTimePicker1.Value.ToShortDateString() + " To " + dateTimePicker2.Value.ToShortDateString();

                crParameterFieldDefinitions = rpt3.DataDefinition.ParameterFields;



                crParameterFieldDefinition = crParameterFieldDefinitions["My Parameter"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                //frmcashsummary frm2 = new frmcashsummary();
                crystalReportViewer1.ReportSource = rpt3;

                //frm2.ShowDialog();


                myConnection.Close();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error " + ex);
            }
        }
    }
}
