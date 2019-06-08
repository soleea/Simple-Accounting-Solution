using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using College_Management_System;

namespace SimpleaccountingSys
{
    public partial class frmprofit_loss : Form
    {
        public frmprofit_loss()
        {
            InitializeComponent();
        }
        ConnectionString cs = new ConnectionString();
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
            
                    string cmdStrinzz = "SELECT  TFinancials.FDate, TFinancials.Particular, TFinancials.FCredit,"+
                        " TFinancials.FDebit, TFinancials.Names, Accounts.Account_type, Cash_Bank.Cash_type,"+
                        " CASE WHEN TFinancials.FDebit > 0 THEN 'Expense' ELSE 'Income' END AS Transaction_type " +//take note of the if else statement in there use for the p/l statement
                    " FROM            TFinancials INNER JOIN "+
                      "   Cash_Bank ON TFinancials.Id = Cash_Bank.Id INNER JOIN "+
                       "  Accounts ON TFinancials.Account_id = Accounts.Account_id" +
                       "  where (TFinancials.FDate >= @a2) AND (TFinancials.FDate <= @a3)  ";
                    cmd = new SqlCommand(cmdStrinzz, myConnection);
                   
                    cmd.Parameters.AddWithValue("@a2", SqlDbType.Date).Value = (dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@a3", SqlDbType.Date).Value = (dateTimePicker2.Value.Date);


                    myDA.SelectCommand = cmd;
                    myDA.Fill(myDS, "S_And_C_statment");

                    rptpandlst rpt3 = new rptpandlst();

                rpt3.SetDataSource(myDS);



                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();


                crParameterDiscreteValue.Value = "BIG LTD Profit And Loss Statement "
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
