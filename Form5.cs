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

        //private void button1_Click(object sender, EventArgs e)
        //{

        //     string constr = "Data Source=DESKTOP-HC6LA9F\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
        //     SqlConnection con = new SqlConnection(constr);
        //     con.Open();
        //     AssessmentItem selectedAssessment = (AssessmentItem)comboBox1.SelectedItem;
        //     RubricItem selectedRubric = (RubricItem)comboBox2.SelectedItem;
        //     SqlCommand cmd = new SqlCommand("insert into AssessmentComponent (Name,RubricId,TotalMarks, DateCreated, DateUpdated,AssessmentId) values(@Name,@RubricId, @TotalMarks,(GETDATE()),(GETDATE()),@AssessmentId)", con);
        //     cmd.Parameters.AddWithValue("@Name", (textBox1.Text));
        //     cmd.Parameters.AddWithValue("@TotalMarks", (textBox3.Text));
        //     cmd.Parameters.AddWithValue("@RubricId", 1);
        //     cmd.Parameters.AddWithValue("@AssessmentId", 2);

        //     cmd.ExecuteNonQuery();
        //     con.Close();
        //     MessageBox.Show("Successfully Inserted!");
        // }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-HC6LA9F\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            //     using (SqlConnection connection = new SqlConnection(constr))
            //     {
            //         string query = "SELECT Title FROM Assessments";
            //         SqlCommand command = new SqlCommand(query, connection);

            //         try
            //         {
            //             connection.Open();
            //             SqlDataReader reader = command.ExecuteReader();

            //             while (reader.Read())
            //             {
            //                 comboBox1.Items.Add(new AssessmentItem(reader.GetInt32(0), reader.GetString(1)));
            //             }
            //         }
            //         catch (Exception ex)
            //         {
            //             MessageBox.Show("Error retrieving assessments: " + ex.Message);
            //         }

           
        }


            ///*     using (SqlConnection con = new SqlConnection(constr))
            //     {
            //         con.Open();

            //         SqlCommand cmd = new SqlCommand("SELECT Title FROM Assessment Where Id=@Id", con);
            //        cmd.Parameters.AddWithValue("@Id", comboBox1.Text);


            //         // cmd.Parameters.AddWithValue("@Id", 2); 

            //         using (SqlDataReader reader = cmd.ExecuteReader())
            //         {
            //             while (reader.Read())
            //             {

            //                 comboBox1.Items.Add(reader["Title"].ToString());
            //             }
            //         }*/

            //         connection.Close();
            //     }


            // }

            // private void button2_Click(object sender, EventArgs e)
            // {
            //     string constr = "Data Source=DESKTOP-HC6LA9F\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            //     using (SqlConnection con = new SqlConnection(constr))
            //     {
            //         con.Open();
            //         SqlCommand cmd = new SqlCommand("DELETE FROM AssessmentComponent WHERE AssessmentId = @AssessmentId", con);
            //         cmd.Parameters.AddWithValue("@AssessmentId", 2); 
            //         int rowsAffected = cmd.ExecuteNonQuery();
            //         con.Close();
            //         MessageBox.Show("Successfully Deleted!");
            //     }

            // }

            // private void button3_Click(object sender, EventArgs e)
            // {
            //     string constr = "Data Source=DESKTOP-HC6LA9F\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            //     using (SqlConnection con = new SqlConnection(constr))
            //     {
            //         con.Open();

            //         SqlCommand cmd = new SqlCommand("UPDATE AssessmentComponent SET Name = @Name, TotalMarks = @TotalMarks, RubricId = @RubricId, DateUpdated = GETDATE() WHERE AssessmentId = @AssessmentId", con);
            //         cmd.Parameters.AddWithValue("@Name", textBox1.Text); 
            //         cmd.Parameters.AddWithValue("@TotalMarks", textBox3.Text); 
            //         cmd.Parameters.AddWithValue("@RubricId", 1); 
            //         cmd.Parameters.AddWithValue("@AssessmentId", 2); 
            //         int rowsAffected = cmd.ExecuteNonQuery();
            //         con.Close();
            //         MessageBox.Show("Successfully Udated!");
            //     }

            // }

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

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-HC6LA9F\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                string query = "SELECT RegistrationNumber FROM Student";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                comboBox.DataSource = dt;
                comboBox.DisplayMember = "RegistrationNumber";

                connection.Close();

            }
        }
    }
    }



