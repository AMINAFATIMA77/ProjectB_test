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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            string constr = "Data Source=DESKTOP-I2JLDNG\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Clo,Rubric,RubricLevel", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-I2JLDNG\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";

            // Establish connection
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd1 = new SqlCommand("Select Id from Clo where Name = @Name", con);
            cmd1.Parameters.AddWithValue("@Name", comboBox2.Text);
            int Id = Convert.ToInt32(cmd1.ExecuteScalar());
            SqlCommand cmd = new SqlCommand("insert into Rubric (Details, CloId) values(@Details,@CloId)", con);
            cmd.Parameters.AddWithValue("@Details", textBox2.Text);
            cmd.Parameters.AddWithValue("@CloId", Id);
            cmd.ExecuteNonQuery(); 
            SqlCommand cmd3 = new SqlCommand("Select Id from Rubric where Details = @Details", con);
            cmd3.Parameters.AddWithValue("@Details", textBox2.Text);
            int RubricId = Convert.ToInt32(cmd3.ExecuteScalar());
            SqlCommand cmd2 = new SqlCommand("insert into RubricLevel (RubricId, Details, MeasurementLevel) values(@RubricId, @Details, @MeasurementLevel)", con);
            cmd2.Parameters.AddWithValue("@RubricId", RubricId);
            cmd2.Parameters.AddWithValue("@Details", textBox2.Text);
            cmd2.Parameters.AddWithValue("@MeasurementLevel", comboBox1.Text);
            cmd2.ExecuteNonQuery(); 

            con.Close();
            MessageBox.Show("Successfully Inserted!");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-I2JLDNG\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select Id from Clo where Name = @Name", con);
            cmd1.Parameters.AddWithValue("@Name", comboBox2.Text);
            int Id = Convert.ToInt32(cmd1.ExecuteScalar());
            SqlCommand cmd3 = new SqlCommand("Select Id from Rubric where Details = @Details", con);
            cmd3.Parameters.AddWithValue("@Details", textBox2.Text);
            int RubricId = Convert.ToInt32(cmd3.ExecuteScalar());
            SqlCommand cmd2 = new SqlCommand("delete from RubricLevel where Details = @Details and RubricId = @RubricId", con);
            cmd2.Parameters.AddWithValue("@Details", textBox2.Text);
            cmd2.Parameters.AddWithValue("RubricId", RubricId);
            cmd2.ExecuteNonQuery();
            SqlCommand cmd4 = new SqlCommand("delete from Rubric where Details = @Details and CloId = @CloId", con);
            cmd4.Parameters.AddWithValue("@Details", textBox2.Text);
            cmd4.Parameters.AddWithValue("@CloId", Id);
            cmd4.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Deleted!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-I2JLDNG\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Id from Clo where Name = @Name", con);
            cmd.Parameters.AddWithValue("@Name", comboBox2.Text);
            int Id = Convert.ToInt32(cmd.ExecuteScalar());
           
            SqlCommand cmd1 = new SqlCommand("Update Rubric set Details = @Details where CloId = @CloId", con);
            cmd1.Parameters.AddWithValue("@Details", textBox2.Text);
            cmd1.Parameters.AddWithValue("@CloId", Id);
            cmd1.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("Select Id from Rubric where Details = @Details", con);
            cmd2.Parameters.AddWithValue("@Details", textBox2.Text);
            int RubricId = Convert.ToInt32(cmd2.ExecuteScalar());
            SqlCommand cmd3 = new SqlCommand("update RubricLevel set Details = @Details, MeasurementLevel = @MeasurementLevel where RubricId = @RubricId", con);
            cmd3.Parameters.AddWithValue("@Details", textBox2.Text);
            cmd3.Parameters.AddWithValue("@MeasurementLevel", comboBox1.Text);
            cmd3.Parameters.AddWithValue("@RubricId", RubricId);
            cmd3.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Updated!");
        }
    }
}
