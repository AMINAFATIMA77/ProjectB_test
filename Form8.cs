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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-HC6LA9F\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Clo (Name, DateCreated, DateUpdated) VALUES (@Name, GETDATE(), GETDATE())", con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.ExecuteNonQuery();

    
            SqlCommand cmd1 = new SqlCommand("SELECT Id FROM Clo WHERE Name = @Name", con);
            cmd1.Parameters.AddWithValue("@Name", textBox1.Text);
            int id = Convert.ToInt32(cmd1.ExecuteScalar());

            SqlCommand cmd2 = new SqlCommand("INSERT INTO Rubric (id, Details, CloId) VALUES (@id, @Details, @CloId)", con);
            cmd2.Parameters.AddWithValue("@Details", textBox2.Text);
            cmd2.Parameters.AddWithValue("@CloId", id);
            cmd2.Parameters.AddWithValue("@id", 1);
            cmd2.ExecuteNonQuery();

            MessageBox.Show("Successfully inserted!");
        }
    }
}
