using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : Window
    {
        public Students()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Groups groups = new Groups();
            groups.Show();
            this.Close();
        }

        SqlConnection connection1 = new SqlConnection("Data Source=AKICHAN;Initial Catalog=StudentPortal;Integrated Security=True");

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Students", connection1);
            DataTable dt = new DataTable();
            connection1.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            connection1.Close();
            dgStud.ItemsSource = dt.DefaultView;
        }
        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            LoadGrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            connection1.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Students WHERE studentID = " + txtStudNum.Text, connection1);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully deleted", "Deleted!", MessageBoxButton.OK, MessageBoxImage.Information);
                connection1.Close();
                txtStudNum.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("NOT successfully deleted" + ex.Message);
            }
            finally
            {
                connection1.Close();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Create create = new Create();
            create.txtStudID.Text = txtStudNum.Text;
            create.Show();
        }
    }
}