using CLI.Controller;
using CLI.Model;
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
    /// Interaction logic for AddProfesorToPredmet.xaml
    /// </summary>
    public partial class AddProfesorToPredmet : Window
    {
        public ObservableCollection<ProfesorDTO> Profesori { get; set; }
        public ObservableCollection<ProfesorDTO> ProfesoriPreostali { get; set; }
        private PredmetController predmetController;
        private ProfesorController profesorController;
        private ProfesorPredmetController profesorPredmetController;
        public int predId;
        public AddProfesorToPredmet(ObservableCollection<ProfesorDTO> Profesori, ProfesorPredmetController profesorPredmetController, int id)
        {
            InitializeComponent();
            DataContext = this;

            profesorController = new ProfesorController();
            ProfesoriPreostali = new ObservableCollection<ProfesorDTO>();
            this.profesorPredmetController = profesorPredmetController;
            this.Profesori = Profesori;

            predId = id;

            ObservableCollection<int> ids = new ObservableCollection<int>();
            foreach (ProfesorDTO prof in Profesori)
            {
                ids.Add(prof.Id);
            }


            foreach (Profesor prof in profesorController.GetAllProfesors())
            {
                if (!ids.Contains(prof.ID))
                {
                    ListBoxProfesori.Items.Add(prof.Ime + " " + prof.Prezime);
                    ProfesoriPreostali.Add(new ProfesorDTO(prof));
                }
            }
        }

        public void PotvrdiOnCLick(object sender, RoutedEventArgs e)
        {
            if (ListBoxProfesori.SelectedItem == null)
            {
                MessageBox.Show("Izaberite profesora.");
                return;
            }

            ProfesorDTO prof = ProfesoriPreostali[ListBoxProfesori.SelectedIndex];
            profesorPredmetController.Add(new ProfesorPredmet(prof.Id, predId));
            /*
            Subject pred = predmetController.GetPredById(predId);
            pred.Profesor = prof.ToProfesor();
            predmetController.Edit(pred);
            */
            Close();
        }

        public void OdustaniOnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
