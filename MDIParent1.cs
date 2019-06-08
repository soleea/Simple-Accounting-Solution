using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Accountzone;
using SimpleaccountingSys;

namespace E_examination
{
    public partial class MDIParent1 : Form
    {
        
        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            frmprofit_loss myview = new frmprofit_loss();
            myview.ShowDialog();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcustomerstatements myview = new frmcustomerstatements();
            myview.ShowDialog();
        }

        

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void viewMenu_Click(object sender, EventArgs e)
        {
           
        }

        private void toolsMenu_Click(object sender, EventArgs e)
        {
           
        }

        private void driversTripToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void cashTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmpayment myview = new frmpayment();
            myview.ShowDialog();
        }

        private void driversSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcustomers myview = new frmcustomers();
            myview.ShowDialog();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcustomers myview = new frmcustomers();
            myview.ShowDialog();
        }

        private void cashBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcashbank myview = new frmcashbank();
            myview.ShowDialog();
        }

        private void chartOfAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChartofaccts myview = new frmChartofaccts();
            myview.ShowDialog();
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcashbank_statem myview = new frmcashbank_statem();
            myview.ShowDialog();
        }
    }
}
