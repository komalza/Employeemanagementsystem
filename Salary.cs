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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TGPPBT9\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True");
        private void fetchempdata()
        {
            con.Open();
            String querry = " select *  from Employee where empid = '" + EmpidTb.Text + "';";
            SqlCommand cmd = new SqlCommand(querry, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                empname.Text = dr["empname"].ToString();
                empPos.Text = dr["empPos"].ToString();


            }
            con.Close();
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Salary_Load(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton24_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        int Dailybase;
        int total;
        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            if(empPos.Text == "")
            {
                MessageBox.Show("Select an Employee");
            }
            else if(empWork.Text == "" || Convert.ToInt32(empWork.Text) > 28)
            {
                MessageBox.Show("Enter Valid No. of Days");
            }
            else
            {
                if(empPos.Text == "Manager")
                {
                    Dailybase = 250;
                }
                else if(empPos.Text == "Senior developer")
                {
                    Dailybase = 200;
                }
                else if(empPos.Text == "Junior developer")
                {
                    Dailybase = 190;
                }
                else
                {
                    Dailybase = 150;
                }
                total = Dailybase * Convert.ToInt32(empWork.Text);
                SalarySlip.Text = "Employee Id  :"+ EmpidTb.Text + "\n" +"Employee Name   :"+ empname.Text + "\n" +"Employee Position    :"+ empPos.Text + "\n" +"Working Days  :"+ empWork.Text + "\n" +"Daily Salary  :" + Dailybase + "\n"  + "Total Salary   :   " + total;


            }
        }

        private void BunifuThinButton23_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        private void Label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("=========SALARY DETAILS=======", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.DarkBlue, new Point(180));

            e.Graphics.DrawString("Employee Id :" + EmpidTb.Text , new Font("Century Gothic", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(10, 120));
            e.Graphics.DrawString( "Employee Nmae :" + empname.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(10, 140));

            e.Graphics.DrawString("Employee Postion:" + empPos.Text , new Font("Century Gothic", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(10, 160));
            e.Graphics.DrawString("Working days :" + empWork.Text , new Font("Century Gothic", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(10, 180));
            e.Graphics.DrawString("Dailybase :" + Dailybase , new Font("Century Gothic", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(10, 200));
            e.Graphics.DrawString("Total Salary :" + total, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(10, 220));
        }
    }
}
