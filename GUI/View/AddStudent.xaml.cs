using CLI.Controller;
using CLI.DAO;
using GUI.DTO;
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
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public StudentDTO studentDTO { get; set; }

        public StudentController studentController { get; set; }
        public AddStudent(StudentController studentController)
        {
            InitializeComponent();
            DataContext = this;
            studentDTO = new StudentDTO();
            this.studentController = studentController;
        }
        private void AddOnClick(object sender, RoutedEventArgs e)
        {
            if (studentDTO.IsValid)
            {
                studentController.Add(studentDTO.ToStudent());
                Close();
            }
            else
            {
                MessageBox.Show("Izmene ne mogu da se obrade. Nisu sva polja ispravno popunjena.");
            }
        }

        private void CloseOnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
