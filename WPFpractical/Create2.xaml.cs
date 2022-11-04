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
    /// Interaction logic for Create2.xaml
    /// </summary>
    public partial class Create2 : Window
    {
        public Create2()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Teachers teachers = new Teachers();
            teachers.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string teachID = txtTeach.Text;
            string teachF = txtTeachF.Text;
            string teachL = txtTeachL.Text;

            string connection = "Data Source=AKICHAN;Initial Catalog=StudentPortal;Integrated Security=True";
            string insert = "INSERT INTO dbo.Teachers (teacherID, firstName, lastName)" + "VALUES('" + teachID + "', '" + teachF + "', '"+ teachL + "')";
            SqlConnection con = new(connection);
            SqlCommand sqlCommand = new SqlCommand(insert, con);

            con.Open();

            int result = sqlCommand.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Successfully saved!");
            }
            con.Close();

            Teachers teach = new Teachers();
            teach.Show();
            this.Close();
        }
    }
}
