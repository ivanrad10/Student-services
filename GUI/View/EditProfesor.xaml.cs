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
    /// Interaction logic for EditProfesor.xaml
    /// </summary>
    public partial class EditProfesor : Window, IObserver
    {
        public ProfesorDTO profesorDTO { get; set; }
        public ObservableCollection<PredmetDTO> Predmeti { get; set; }

        private ProfesorController profesorController;

        private ProfesorPredmetController profesorPredmetController;
        private PredmetController predmetController;
        public PredmetDTO? SelectedPredmet { get; set; }
        private int Id;

        public EditProfesor(ProfesorController profesorController, int id)
        {
            InitializeComponent();
            DataContext = this;
            profesorDTO = ProfesorDTO.ToDTO(profesorController.GetProfById(id));
            this.profesorController = profesorController;

            Predmeti = new ObservableCollection<PredmetDTO>();
            profesorPredmetController = new ProfesorPredmetController();
            profesorPredmetController.Subscribe(this);
            predmetController = new PredmetController();
            Id = id;

            Update();
        }
    
        private void EditOnClick(object sender, RoutedEventArgs e)
        {
            if(profesorDTO.IsValid)
            {
                profesorController.Edit(profesorDTO.ToProfesor());
                Close();
            }
            else
            {
                MessageBox.Show("Izmene ne mogu da se obrade. Nisu sva polja ispravno popunjena.");
            }
        }

        public void Update()
        {
            Predmeti.Clear();
            foreach (ProfesorPredmet profPred in profesorPredmetController.GetAllProfPred())
            {
                if(profPred.ProfesorID == Id)
                {
                    foreach (Subject pred in predmetController.GetAllSubjects())
                    {
                        if (pred.ID == profPred.PredmetID)
                        {
                            Predmeti.Add(new PredmetDTO(pred));
                        }
                    }
                }
            }
        }

        public void AddPredmet(object sender, RoutedEventArgs e)
        {
            AddPredmetToProfesor addpredmet = new AddPredmetToProfesor(Predmeti, profesorPredmetController, Id);
            addpredmet.Show();
        }

        public void RemovePredmet(object sender, RoutedEventArgs e)
        {
            if(SelectedPredmet == null)
            {
                MessageBox.Show("Izaberite predmet.");
            }
            else
            {
                profesorPredmetController.Delete(Id, SelectedPredmet.Id);
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

        private void CloseOnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
