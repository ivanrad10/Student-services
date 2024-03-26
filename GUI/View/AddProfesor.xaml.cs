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
    /// Interaction logic for AddProfesor.xaml
    /// </summary>
    public partial class AddProfesor : Window
    {
        public ProfesorDTO profesorDTO {  get; set; }

        private ProfesorController profesorController;

        public AddProfesor(ProfesorController preofesorController)
        {
            InitializeComponent();
            DataContext = this;
            profesorDTO = new ProfesorDTO();
            this.profesorController = preofesorController;
        }

        private void AddOnClick(object sender, RoutedEventArgs e)
        {
            if(profesorDTO.IsValid)
            {
                profesorController.Add(profesorDTO.ToProfesor());
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
