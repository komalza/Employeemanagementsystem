using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employeemangementsystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TGPPBT9\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True");
        private void Guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String username, password;

            username = guna2TextBox1.Text;
            password = guna2TextBox2.Text;

            try
            {
                String querry = "SELECT * FROM login WHERE username = '" + guna2TextBox1.Text + "' AND password ='" + guna2TextBox2.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, con);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);


                if(dtable.Rows.Count > 0)
                {
                    username = guna2TextBox1.Text;
                    password = guna2TextBox2.Text;


                    Home form3 = new Home();
                    form3.Show();
                    this.Hide();


                }

                else
                {
                    MessageBox.Show("invalid details!!","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();

                    guna2TextBox1.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                con.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();

            guna2TextBox1.Focus();
        }
    }
}
