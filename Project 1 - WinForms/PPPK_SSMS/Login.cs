using PPPK_SSMS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPK_SSMS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string server = tbServer.Text.Trim();
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();

            try
            {
                RepositoryFactory.GetRepository().LogIn(server, username, password);
                new Main().Visible = true;
                Hide();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;

            }
        }
    }
}
