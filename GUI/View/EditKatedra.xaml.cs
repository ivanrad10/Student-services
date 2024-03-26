using CLI.Controller;
using CLI.Model;
using CLI.Observer;
using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for EditKatedra.xaml
    /// </summary>
    public partial class EditKatedra : Window, IObserver
    {
        private KatedraController katedraController { get; set; }
        private KatedraProfesorController katedraProfesorController {  get; set; }
        private ObservableCollection<ProfesorDTO> Profesori {  get; set; }
        private ProfesorController profesorController { get; set; }
        private int Id;
        public EditKatedra(KatedraController katedraController, int id)
        {
            InitializeComponent();
            DataContext = this;
            this.katedraController = katedraController;

            Profesori = new ObservableCollection<ProfesorDTO>();
            katedraProfesorController = new KatedraProfesorController();
            Id = id;
        }

        public void Update()
        {
            Profesori.Clear();
            foreach (KatedraProfesor katProf in katedraProfesorController.GetAllKatProf())
            {
                if (katProf.KatedraID == Id)
                {
                    foreach (Profesor prof in profesorController.GetAllProfesors())
                    {
                        if (prof.ID == katProf.ProfesorID)
                        {
                            Profesori.Add(new ProfesorDTO(prof));
                        }
                    }
                }
            }
        }

        private void OpenInfo(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }
        private void OpenPredmeti(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void EditOnClick(object sender, RoutedEventArgs e)
        {

        }

        private void CloseOnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
