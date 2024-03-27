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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "RegistrationNumber";

                connection.Close();
            }
        }
    }
}
