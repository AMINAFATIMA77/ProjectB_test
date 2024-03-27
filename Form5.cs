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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string constr = "Data Source=DESKTOP-HC6LA9F\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            //AssessmentItem selectedAssessment = (AssessmentItem)comboBox1.SelectedItem;
            //RubricItem selectedRubric = (RubricItem)comboBox2.SelectedItem;
            SqlCommand cmd = new SqlCommand("insert into AssessmentComponent (Name,RubricId,TotalMarks, DateCreated, DateUpdated,AssessmentId) values(@Name,@RubricId, @TotalMarks,(GETDATE()),(GETDATE()),@AssessmentId)", con);
            cmd.Parameters.AddWithValue("@Name", (textBox1.Text));
            cmd.Parameters.AddWithValue("@TotalMarks", (textBox3.Text));
            cmd.Parameters.AddWithValue("@RubricId", 1);
            cmd.Parameters.AddWithValue("@AssessmentId", 2);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Inserted!");
        }
        private void button2_click(object sender, EventArgs e)
        {
            string constr = "data source=desktop-hc6la9f\\sqlexpress;initial catalog=projectb;integrated security=true";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from assessmentcomponent where assessmentid = @assessmentid", con);
                cmd.Parameters.AddWithValue("@assessmentid", 2);
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("successfully deleted!");
            }

        }


        private void button3_click(object sender, EventArgs e)
        {
            string constr = "data source=desktop-hc6la9f\\sqlexpress;initial catalog=projectb;integrated security=true";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("update assessmentcomponent set name = @name, totalmarks = @totalmarks, rubricid = @rubricid, dateupdated = getdate() where assessmentid = @assessmentid", con);
                //cmd.Parameters.AddWithValue("@name", textbox1.text);
                //cmd.Parameters.AddWithValue("@totalmarks", textbox3.text);
                cmd.Parameters.AddWithValue("@rubricid", 1);
                cmd.Parameters.AddWithValue("@assessmentid", 2);
                int rowsaffected = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("successfully udated!");
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

            string constr = "Data Source=DESKTOP-I2JLDNG\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                string query = "SELECT Title FROM Assessment";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                AssessmentComboBox.DataSource = dt;
                AssessmentComboBox.DisplayMember = "Title";
                connection.Close();

            }
            {
                string constr1 = "Data Source=DESKTOP-I2JLDNG\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(constr1))
                {
                    connection.Open();
                    string query = "SELECT Details FROM Rubric";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "Details";
                    connection.Close();

                }
            }
        }
    }
}




