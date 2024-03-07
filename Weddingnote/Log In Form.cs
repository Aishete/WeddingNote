using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weddingnote
{
    public partial class Log_In_Form : Form
    {
        public Log_In_Form()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Log_In_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           Login();
        }
        private void Login()
        {
            string username = "Admin";
            string password = "123456";
            if (txtname.Text == username && txtpassword.Text == password)
            {
                // Menu menu = new Menu();
                //menu.Show();
  
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            //MessageBox.Show("Login Success!", "Success!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Login Failed!", "Failed!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
