using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ayubo_Drive
{
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\HND-13\Programming\Final Project\Ayubo Drive\Ayubo_Drive\Ayubo_Drive\AyuboDb.mdf;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = this.userNameTxt.Text;
            string password = this.passwordTxt.Text;
            string check = "SELECT * FROM user_login WHERE userName=@userName AND password=@password";
            conn.Open();
            SqlCommand cmdcheck = new SqlCommand(check, conn);
            cmdcheck.Parameters.AddWithValue("@userName", userName);
            cmdcheck.Parameters.AddWithValue("@password", password);
            SqlDataReader result = cmdcheck.ExecuteReader();

            if (result.Read())
            {
                this.Hide();
                new Dashboard().Show();
            }
            else
                //MessageBox.Show("Invalid username or password");
                label5.Show();

            conn.Close();

        }
    }
}
