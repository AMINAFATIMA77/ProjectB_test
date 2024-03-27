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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectB_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(textBox1, "Cannot be empty");

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-HC6LA9F\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Student SET FirstName = @FirstName, LastName = @LastName, Contact = @Contact, Email = @Email, RegistrationNumber = @RegistrationNo, Status = @Status WHERE RegistrationNumber = @RegistrationNo", con);
                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
                cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                cmd.Parameters.AddWithValue("@RegistrationNo", textBox5.Text);
                cmd.Parameters.AddWithValue("@Status", 1); 
                                                           
              
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Successfully updated!");
                }
                else
                {
                    MessageBox.Show("Update failed. No records were updated.");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBox1.Text.Trim()) || string.IsNullOrWhiteSpace(this.textBox2.Text.Trim()) )
            {
                
                errorProvider1.SetError(textBox1, "Field Cannot be empty");
                errorProvider2.SetError(textBox2, "Field Cannot be empty");

                return;
                //errorProvider3.SetError(textBox3, "Field Cannot be empty");
                //errorProvider4.SetError(textBox4, "Field Cannot be empty");
                //errorProvider5.SetError(textBox5, "Field Cannot be empty");
            }
            else
            {

            string constr = "Data Source=DESKTOP-HC6LA9F\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Student values(@FirstName, @LastName, @Contact, @Email, @RegistrationNo, @Status)", con);
            cmd.Parameters.AddWithValue("@FirstName", (textBox1.Text));
            cmd.Parameters.AddWithValue("@LastName", (textBox2.Text));
            cmd.Parameters.AddWithValue("@Contact", "textBox3.Text");
            cmd.Parameters.AddWithValue("@Email", "(textBox4.Text)");
            cmd.Parameters.AddWithValue("@RegistrationNo", "textBox5.Text");
            cmd.Parameters.AddWithValue("@Status", 1);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Inserted!");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-HC6LA9F\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE RegistrationNumber = @RegistrationNo", con);

                cmd.Parameters.AddWithValue("@RegistrationNo", textBox5.Text);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted!");
                }
                else
                {
                    MessageBox.Show("Deletion failed. No records were deleted.");
                }
            }

        }

      

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-I2JLDNG\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Student", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
