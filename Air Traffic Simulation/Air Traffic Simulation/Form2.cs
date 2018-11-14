using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air_Traffic_Simulation
{
    public partial class Form2 : Form
    {
        Database dbConnection;
        bool loggedIn;

        public Form2()
        {
            InitializeComponent();
            tbUsername.Text = "Name";
            tbPassword.Text = "Password";
            loggedIn = false;
            dbConnection = new Database();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            var newForm = new Form1();
            newForm.Show();
            this.Hide();

            //            if (dbConnection.GetLogin(bunifuMaterialTextbox1.Text, bunifuMaterialTextbox1.Text) == true)
            //            {
            //                MessageBox.Show("Login successfull.");
            //                loggedIn = true;
            //
            //            }
            //            else
            //            {
            //                MessageBox.Show("Login denied.");
            //            }
        }
    }
}
