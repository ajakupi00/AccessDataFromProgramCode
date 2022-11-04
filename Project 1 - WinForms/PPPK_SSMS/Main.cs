using PPPK_SSMS.DAL;
using PPPK_SSMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zadatak.Dal;

namespace PPPK_SSMS
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
            cbDatabases.DataSource = RepositoryFactory.GetRepository().GetDatabases().ToArray();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteCMD();
        }

        private void ExecuteCMD()
        {
            lblMessage.ForeColor = Color.Black;
            dataGridView.DataSource = null;
            Database selectedDB = cbDatabases.SelectedItem as Database;
            string useDB = $"use {selectedDB.Name} ";
            try
            {
                string query = useDB + tbQuery.Text.Trim();
                DataSet ds = RepositoryFactory.GetRepository().GetDataSet(query);
                if(ds.Tables.Count != 0)
                {
                    foreach (DataTable dataTable in ds.Tables)
                    {
                        dataGridView.DataSource = dataTable;
                        lblMessage.Text = $"({dataTable.Rows.Count} " + $"rows affected)\n  Completion time: {DateTime.Now}";
                        tabControl.SelectedTab = tabPageResults;

                    }
                }
                else
                {
                    tabControl.SelectedTab = tabPageMessages;
                    lblMessage.Text = $"  Query successful.\n  Completion time: {DateTime.Now}";

                }
               
            }catch(Exception e)
            {
                tabControl.SelectedTab = tabPageMessages;
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = e.Message;
            }
        }

    


        private void pbRun_Click(object sender, EventArgs e)
        {
            ExecuteCMD();
        }
    }
}
