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
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        public Create()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string num1 = txtStudID.Text;
            string num2 = txtFirst.Text;
            string num3 = txtLast.Text;
            string num4 = txtGroupID.Text;

            string connectionString = "Data Source=AKICHAN;Initial Catalog=StudentPortal;Integrated Security=True";
            string query = "INSERT INTO dbo.Students(studentID, firstName, lastName, groupID)" +
                "VALUES('" + num1 + "', '" + num2 + "', '" + num3 + "', '" + num4 + "')";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new(query, connection);
            connection.Open();

            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Successfully saved!");
            }
            connection.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
