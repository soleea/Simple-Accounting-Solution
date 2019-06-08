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
    public partial class frmcashbank_statem : Form
    {
        public frmcashbank_statem()
        {
            InitializeComponent();
        }
        ConnectionString cs = new ConnectionString();
        DataSet sqlDatasetaccounts = new DataSet();
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
            FacultyDataAdapter2.Fill(sqlDatasetaccounts, "Cash_Bank");
            comboBox1acct.DataSource = sqlDatasetaccounts.Tables[0];
            comboBox1acct.ValueMember = "Id";
            comboBox1acct.DisplayMember = "Cash_type";
            comboBox1acct.SelectedIndex = -1;
            myconnection.Close();
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
                string accnames = "";
                //sum all previous balances
                    string cmdStringbunit1 = "SELECT sum(FDebit) as mysum from  TFinancials " +
                   " where  FDate<=@a4 and id=@a3 ";
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
                   " where  FDate<=@a4 and id=@a3 ";
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
                    decimal sum = 0;
                    //sum = deb1 + creditdeb12;

                    string cmdStrinzz = "SELECT     Cash_Bank.Cash_type as Customer_name,  TFinancials.FDate, TFinancials.id as CUTID, TFinancials.Particular, " +
                        "TFinancials.FCredit, TFinancials.FDebit, TFinancials.Names," + deb1 + " as debts," + creditdeb12 + " as credits  " +
                " FROM            TFinancials INNER JOIN " +
                    "     Cash_Bank ON TFinancials.id = Cash_Bank.id " +
                " WHERE   " +
                       "  (TFinancials.FDate >= @a2) AND (TFinancials.FDate <= @a3) and (TFinancials.id = @a1)";

                    cmd = new SqlCommand(cmdStrinzz, myConnection);
                    // string cmdStringbunit = "SELECT [Account name],[Acc number],[Starting bal],[Starting date],cash_id from cash_Table where cash_id=@a1 ORDER BY Open_date desc";

                    // SqlCommand sqlCommandbunit = new SqlCommand(cmdStringbunit, myconnection);
                    cmd.Parameters.AddWithValue("@a2", SqlDbType.Date).Value = (dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@a3", SqlDbType.Date).Value = (dateTimePicker2.Value.Date);
                    cmd.Parameters.AddWithValue("@a1", SqlDbType.NVarChar).Value = comboBox1acct.SelectedValue;

                   
                    myDA.SelectCommand = cmd;
                    myDA.Fill(myDS, "S_And_C_statment");
               

                rptscashsummary rpt3 = new rptscashsummary();

                rpt3.SetDataSource(myDS);



                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();


                crParameterDiscreteValue.Value = "BIG LTD Cash summary Statement "
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

        private void frmcashbank_statem_Load(object sender, EventArgs e)
        {
            account();
        }
    }
}
