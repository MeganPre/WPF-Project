using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFpractical
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            Students students = new Students();
            students.Show();
            this.Close();
        }

        private void btnTeacher_Click(object sender, RoutedEventArgs e)
        {
            Teachers teachers = new Teachers();
            teachers.Show();
            this.Close();
        }

        private void btnSubject_Click(object sender, RoutedEventArgs e)
        {
            Subjects subjects = new Subjects();
            subjects.Show();
            this.Close();
        }

        private void btmMark_Click(object sender, RoutedEventArgs e)
        {
            Marks marks = new Marks();
            marks.Show();
            this.Close();
        }
    }
}
