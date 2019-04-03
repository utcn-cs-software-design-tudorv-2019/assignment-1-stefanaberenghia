using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tema1ps.BLLayer;

namespace tema1ps.UILayer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            UserBL userBL = new UserBL();
            int result = userBL.loginUser(textBoxUsername.Text, textBoxPassword.Text);
            if (result < 0)
                MessageBox.Show("Invalid credentials");
            else
                if (result == 0) {
                    this.Hide();
                    new Student().Show();

                }
            else
            {
                this.Hide();
                new Administrator().Show();
            }

        }
    }
}
