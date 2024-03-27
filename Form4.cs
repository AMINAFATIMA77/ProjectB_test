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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-I2JLDNG\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Clo (Name, DateCreated, DateUpdated) VALUES (@Name, GETDATE(), GETDATE())", con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully inserted!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-I2JLDNG\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Clo SET Name = @Name, DateUpdated = GETDATE() WHERE Name = @Name", con);
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-I2JLDNG\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE  FROM Clo WHERE Name = @Name", con);
                cmd.Parameters.AddWithValue("@Name", textBox1.Text); 
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted!");
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-I2JLDNG\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Clo", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
