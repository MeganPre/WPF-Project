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
    /// Interaction logic for Create3.xaml
    /// </summary>
    public partial class Create3 : Window
    {
        public Create3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string n1 = txtSubID.Text;
            string n2 = txtTitle.Text;

            string connectionString = "Data Source=AKICHAN;Initial Catalog=StudentPortal;Integrated Security=True";
            string query = "INSERT INTO dbo.Subjects(subjectID, title)" +
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

            Create4 cre = new();
            cre.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Subjects subjects = new Subjects();
            subjects.Show();
            this.Close();
        }
    }
}
