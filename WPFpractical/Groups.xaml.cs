using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFpractical
{
    /// <summary>
    /// Interaction logic for Groups.xaml
    /// </summary>
    public partial class Groups : Window
    {
        public Groups()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Students stud = new Students();
            stud.Show();
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string n1 = txtGroupid.Text;
            string n2 = txtGroupname.Text;

            string connectionString = "Data Source=AKICHAN;Initial Catalog=StudentPortal;Integrated Security=True";
            string query = "INSERT INTO dbo.Groups(groupID, groupName)" +
                "VALUES('" + n1 + "', '" + n2 + "')";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new(query, connection);
            connection.Open();

            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Successfully saved!");
            }
            connection.Close();

            Create cre = new Create();  
            cre.Show();
            this.Close();
        }
    }
}
