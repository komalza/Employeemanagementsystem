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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TGPPBT9\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True");

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (empid.Text == "" || empGen.Text == "" || empEdu.Text == "" || empAdd.Text == "" || empname.Text == "" || empPhon.Text == "" || empPos.Text == "" || empDob.Text=="") 
            {
                MessageBox.Show("Information Missing!!");
            }

            else
            {
             try
                {
                    con.Open();
                    String querry = "insert into Employee  values ('"+empid.Text+"','"+empname.Text+"','"+empPos.SelectedItem.ToString()+ "','" + empAdd.Text + "','" + empGen.SelectedItem.ToString()+"','"+empPhon.Text+"','"+empEdu.SelectedItem.ToString()+"','"+empDob.Value.Date+"')";
                    SqlCommand cmd = new SqlCommand(querry, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee successfully Inserted!!");

                    con.Close();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void Label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            con.Open();
            String querry = "select * from Employee";
            SqlDataAdapter sda1 = new SqlDataAdapter(querry, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda1);
            var ds = new DataSet();
            sda1.Fill(ds);
            GridView.DataSource = ds.Tables[0];


            con.Close();

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void Empid_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmpPhon_TextChanged(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton23_Click(object sender, EventArgs e)
        {
            if(empid.Text == "")
            {
                MessageBox.Show("Enter Employee Id!!");
            }
            else
            {
                try
                {
                    con.Open();
                    String querry = " delete  from Employee where empid = '" + empid.Text + "';";
                    SqlCommand cmd1 = new SqlCommand(querry, con);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Employee successfully Deleted!!");
                    con.Close();
                    populate();

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            empid.Text = GridView.SelectedRows[0].Cells[0].Value.ToString();
            empname.Text = GridView.SelectedRows[0].Cells[1].Value.ToString();
            empPos.Text = GridView.SelectedRows[0].Cells[2].Value.ToString();
            empAdd.Text = GridView.SelectedRows[0].Cells[3].Value.ToString();
            empGen.Text = GridView.SelectedRows[0].Cells[4].Value.ToString();
            empPhon.Text = GridView.SelectedRows[0].Cells[5].Value.ToString();
            empEdu.Text = GridView.SelectedRows[0].Cells[6].Value.ToString();
            empDob.Text = GridView.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (empid.Text == "" || empGen.Text == "" || empEdu.Text == "" || empAdd.Text == "" || empname.Text == "" || empPhon.Text == "" || empPos.Text == "" || empDob.Text == "")
            {
                MessageBox.Show("Information Missing!!");
            }

            else
            {
                try
                {
                    con.Open();
                    String querry = "update Employee set empid ='" + empid.Text + "',empname ='" + empname.Text + "',empPhon = '" + empPhon.Text + "', empPos ='" + empPos.SelectedItem.ToString() + "',empGen ='" + empGen.SelectedItem.ToString() + "',empEdu ='" + empEdu.SelectedItem.ToString() + "',empAdd = '" + empAdd.Text + "',empDob ='" + empDob.Value.Date + "' where empid = '" + empid.Text + "';";
                    SqlCommand cmd2 = new SqlCommand(querry, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Information Updated!!");

                    con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void BunifuThinButton24_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
