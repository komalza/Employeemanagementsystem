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
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TGPPBT9\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True");
        private void fetchempdata()
        {
            con.Open();
            String querry = " select *  from Employee where empid = '" + Empid.Text + "';";
            SqlCommand cmd = new SqlCommand(querry, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                empidtb.Text = dr["empid"].ToString();
                empname.Text = dr["empname"].ToString();
                empPos.Text = dr["empPos"].ToString();
                empAdd.Text = dr["empAdd"].ToString();
                empGen.Text = dr["empGen"].ToString();
                empPhon.Text = dr["empPhon"].ToString();
                empEdu.Text = dr["empEdu"].ToString();
                empDob.Text = dr["empDob"].ToString();

            }
            con.Close();
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void View_Load(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        private void BunifuThinButton23_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void Label12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog()== DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("=========EMPLOYEE DETAILS=======", new Font("Century Gothic", 20, FontStyle.Bold),Brushes.DarkBlue,new Point(180));
            e.Graphics.DrawString("Employee Id :"+empidtb.Text+"\tEmployee Nmae :"+empname.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(10,120));
            e.Graphics.DrawString("Employee Postion:" + empPos.Text + "\tEmployee Address :" + empAdd.Text,new Font("Century Gothic", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(10, 140));
            e.Graphics.DrawString("Employee Gender :" + empGen.Text + "\tEmployee Phone :" + empPhon.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(10, 160));
            e.Graphics.DrawString("Employee Gender :" + empGen.Text + "\tEmployee Phone :" + empPhon.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(10, 180));
            e.Graphics.DrawString("Employee Education :" + empEdu.Text + "\tEmployee Dob :" + empDob.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(10, 200));
        }
    }
}
