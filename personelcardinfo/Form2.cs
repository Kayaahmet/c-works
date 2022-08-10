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
using ns1;

namespace personelcardinfo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        SqlConnection con = new SqlConnection(@"Data Source=Kaya;Initial Catalog=info;Integrated Security=True");
        SqlDataReader dr;
        public SqlDataReader  userr (TextBox adminame,TextBox password)
        {
            SqlConnection con = new SqlConnection(@"Data Source=Kaya;Initial Catalog=info;Integrated Security=True");

            this.passbox.Size = new System.Drawing.Size(250, 36);

            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Adminpanel where adminname='" + userbox.Text + "' AND password='" + passbox.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Congratulations! You have successfully logged in.");
                this.Hide();
                Form1 fr = new Form1();
                fr.Show();
            }
            else
            {
                MessageBox.Show("Check your username , password and restart program.");


                

            }
            return dr;
        }
       
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            userr(userbox, passbox);

            
        }

    }
}
