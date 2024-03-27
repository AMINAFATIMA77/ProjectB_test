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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-I2JLDNG\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd1 = new SqlCommand("Select Id from Rubric where Details = @Details", con);
            cmd1.Parameters.AddWithValue("@Details", comboBox2.Text);
            int Id = Convert.ToInt32(cmd1.ExecuteScalar());
            SqlCommand cmd3 = new SqlCommand("Select Id from Assessment where Title = @Title", con);
            cmd3.Parameters.AddWithValue("@Title", comboBox1.Text);
            int AsessmentId = Convert.ToInt32(cmd3.ExecuteScalar());
            SqlCommand cmd4 = new SqlCommand("Select TotalMarks from Assessment where Title = @Title", con);
            cmd4.Parameters.AddWithValue("@Title", comboBox1.Text);
            int AsessmentTotalMarks = Convert.ToInt32(cmd4.ExecuteScalar());
            SqlCommand cmd = new SqlCommand("insert into AssessmentComponent (Name, RubricId, TotalMarks, DateCreated, DateUpdated, AssessmentId) values(@Name, @RubricId, @TotalMarks, GETDATE(), GETDATE(), @AssessmentId)", con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@RubricId", Id);
            cmd.Parameters.AddWithValue("@TotalMarks", AsessmentTotalMarks);
            cmd.Parameters.AddWithValue("@AssessmentId", AsessmentId);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Inserted!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-I2JLDNG\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd1 = new SqlCommand("Select Id from Rubric where Details = @Details", con);
            cmd1.Parameters.AddWithValue("@Details", comboBox2.Text);
            int Id = Convert.ToInt32(cmd1.ExecuteScalar());
            SqlCommand cmd3 = new SqlCommand("Select Id from Assessment where Title = @Title", con);
            cmd3.Parameters.AddWithValue("@Title", comboBox1.Text);
            int AsessmentId = Convert.ToInt32(cmd3.ExecuteScalar());
            SqlCommand cmd4 = new SqlCommand("Select TotalMarks from Assessment where Title = @Title", con);
            cmd4.Parameters.AddWithValue("@Title", comboBox1.Text);
            int AsessmentTotalMarks = Convert.ToInt32(cmd4.ExecuteScalar());
            SqlCommand cmd = new SqlCommand("Update AssessmentComponent Set Name = @Name where RubricId =@RubricId and AssessmentId = @AssessmentId", con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@RubricId", Id);
            cmd.Parameters.AddWithValue("@AssessmentId", AsessmentId);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Updated!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-I2JLDNG\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd1 = new SqlCommand("Select Id from Rubric where Details = @Details", con);
            cmd1.Parameters.AddWithValue("@Details", comboBox2.Text);
            int Id = Convert.ToInt32(cmd1.ExecuteScalar());
            SqlCommand cmd3 = new SqlCommand("Select Id from Assessment where Title = @Title", con);
            cmd3.Parameters.AddWithValue("@Title", comboBox1.Text);
            int AsessmentId = Convert.ToInt32(cmd3.ExecuteScalar());
            SqlCommand cmd4 = new SqlCommand("Select TotalMarks from Assessment where Title = @Title", con);
            cmd4.Parameters.AddWithValue("@Title", comboBox1.Text);
            int AsessmentTotalMarks = Convert.ToInt32(cmd4.ExecuteScalar());
            SqlCommand cmd = new SqlCommand("delete from AssessmentComponent where RubricId =@RubricId and AssessmentId = @AssessmentId", con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@RubricId", Id);
            cmd.Parameters.AddWithValue("@AssessmentId", AsessmentId);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Deleted!");
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-I2JLDNG\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM AssessmentComponent", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
