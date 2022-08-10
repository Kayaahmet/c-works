using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Data.SqlTypes;
using System.Drawing.Imaging;

namespace personelcardinfo
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
          
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'infoDataSet1.Info' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.infoTableAdapter.Fill(this.infoDataSet1.Info);









        }
        string imagepath;


        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
                
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title= "Choose the image file you want to upload";
            openFileDialog1.Filter = "Jpeg File (*.jpeg|*.jpeg|Png File (*.png)|*.png";
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                imagepath = openFileDialog1.FileName.ToString();
               
                

            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=Kaya;Initial Catalog=info;Integrated Security=True");
            SqlCommand command = new SqlCommand("insert into Info (ID,Name,Password,Relationship,Nationality,Languages,profession,img) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",connection);
            command.Parameters.AddWithValue("@p1", textBox1.Text);
            command.Parameters.AddWithValue("@p2", textBox3.Text);
            command.Parameters.AddWithValue("@p3", textBox4.Text);
            command.Parameters.AddWithValue("@p4", textBox5.Text);
            command.Parameters.AddWithValue("@p5", textBox6.Text);
            command.Parameters.AddWithValue("@p6", textBox7.Text);
            command.Parameters.AddWithValue("@p7", textBox8.Text);
            command.Parameters.AddWithValue("@p8", imagepath);



            try
            {
               
                connection.Open();
               
                command.ExecuteNonQuery();
                MessageBox.Show("Saving succesful");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int choosen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[choosen].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[choosen].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[choosen].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[choosen].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[choosen].Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.Rows[choosen].Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.Rows[choosen].Cells[6].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.Rows[choosen].Cells[7].Value.ToString();

        }

        private void label9_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
