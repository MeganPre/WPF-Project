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
    /// Interaction logic for Create4.xaml
    /// </summary>
    public partial class Create4 : Window
    {
        public Create4()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Subjects subjects = new Subjects();
            subjects.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string n1 = lbMarkID1.Text;
            string n2 = txtStudID.Text;
            string n3 = txtSubID.Text;
            string n4 = txtDate.Text;
            string n5 = txtMark.Text;

            string connectionString = "Data Source=AKICHAN;Initial Catalog=StudentPortal;Integrated Security=True";
            string query = "INSERT INTO dbo.Marks(markID, studentID, subjectID, date_time, mark)" +
                "VALUES('" + n1 + "', '" + n2 + "', '"+ n3 +"', '"+ n4 +"', '"+ n5 +"')";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new(query, connection);
            connection.Open();

            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Successfully saved!");
            }
            connection.Close();

            Marks marks = new Marks();
            marks.Show();
            this.Close();
        }
    }
}
