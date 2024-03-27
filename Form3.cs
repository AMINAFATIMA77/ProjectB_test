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

namespace ProjectB_test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-HC6LA9F\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Assessment (Title, DateCreated, TotalMarks, TotalWeightage) values(@Title,  (GETDATE()) , @TotalMarks, @TotalWeightage)", con);
            cmd.Parameters.AddWithValue("@Title", textBox1.Text);
            cmd.Parameters.AddWithValue("@TotalMarks", (textBox2.Text));
            cmd.Parameters.AddWithValue("@TotalWeightage", (textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Inserted!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-HC6LA9F\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Assessment WHERE Title = @Title", con);
            cmd.Parameters.AddWithValue("@Title", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted!");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-HC6LA9F\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Assessment SET TotalMarks = @TotalMarks, TotalWeightage = @TotalWeightage WHERE Title = @Title", con);
            cmd.Parameters.AddWithValue("@Title", textBox1.Text);
            cmd.Parameters.AddWithValue("@TotalMarks", textBox2.Text);
            cmd.Parameters.AddWithValue("@TotalWeightage", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated!");

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form9 form9=new Form9();
            form9.Show();
            this.Hide();
        }

      
    }
}
