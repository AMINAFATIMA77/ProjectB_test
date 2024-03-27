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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectB_test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        string connectionString = "Data Source=DESKTOP-HC6LA9F\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form2_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT RegistrationNumber FROM Student";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "RegistrationNumber";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DateTime selectedDate = dateTimePicker1.Value;
                SqlCommand insertClassAttendanceCommand = new SqlCommand("INSERT INTO ClassAttendance (AttendanceDate) VALUES (@AttendanceDate); SELECT SCOPE_IDENTITY();", connection);
                insertClassAttendanceCommand.Parameters.AddWithValue("@AttendanceDate", selectedDate);
                int attendanceId = Convert.ToInt32(insertClassAttendanceCommand.ExecuteScalar());
                SqlCommand selectStudentIdCommand = new SqlCommand("SELECT Id FROM Student WHERE RegistrationNumber = @RegistrationNumber", connection);
                selectStudentIdCommand.Parameters.AddWithValue("@RegistrationNumber", comboBox2.Text);
                int studentId = Convert.ToInt32(selectStudentIdCommand.ExecuteScalar());
                SqlCommand insertStudentAttendanceCommand = new SqlCommand("INSERT INTO StudentAttendance (AttendanceId, StudentId, AttendanceStatus) VALUES (@AttendanceId, @StudentId, @AttendanceStatus)", connection);
                insertStudentAttendanceCommand.Parameters.AddWithValue("@AttendanceId", attendanceId);
                insertStudentAttendanceCommand.Parameters.AddWithValue("@StudentId", studentId);
                insertStudentAttendanceCommand.Parameters.AddWithValue("AttendanceStatus", 1);
               
                
                    MessageBox.Show("Successfully updated!");
                
              
                insertStudentAttendanceCommand.ExecuteNonQuery();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

    }
}
