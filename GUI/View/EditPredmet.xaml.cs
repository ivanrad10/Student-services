using CLI.Controller;
using CLI.DAO;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for EditPredmet.xaml
    /// </summary>
    public partial class EditPredmet : Window, IObserver
    {
        //-------------------------------------------------------------
        public PredmetDTO predmetDTO { get; set; }

        private ProfesorController profesorController;
        private PredmetController predmetController;

        private ProfesorPredmetController profesorPredmetController;

        public ObservableCollection<ProfesorDTO> Profesori { get; set; }
        private int Id;
        private bool apdejt = true;
        public EditPredmet(PredmetController predmetController, int id)
        {
            InitializeComponent();
            DataContext = this;
            predmetDTO = PredmetDTO.ToDTO(predmetController.GetPredById(id));
            this.predmetController = predmetController;

            profesorPredmetController = new ProfesorPredmetController();
            profesorPredmetController.Subscribe(this);
            profesorController = new ProfesorController();
            Profesori = new ObservableCollection<ProfesorDTO>();
            Id = id;

            Update();
        }

        public void Update()
        {
            Profesori.Clear();
            ListBoxProfesori.DataContext = null;
            ListBoxProfesori.Items.Clear();
            foreach (ProfesorPredmet profPred in profesorPredmetController.GetAllProfPred())
            {
                if (profPred.PredmetID == Id)
                {
                    foreach (Profesor prof in profesorController.GetAllProfesors())
                    {
                        if (prof.ID == profPred.ProfesorID)
                        {
                            Profesori.Add(new ProfesorDTO(prof));
                            ListBoxProfesori.Items.Add(prof.Ime + " " + prof.Prezime);
                        }
                    }
                }
            }
        }

        private void EditOnClick(object sender, RoutedEventArgs e)
        {
            predmetController.Edit(predmetDTO.ToSubject());
            Close();
        }

        private void CloseOnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajProfesora(object sender, RoutedEventArgs e)
        {
            AddProfesorToPredmet addprof = new AddProfesorToPredmet(Profesori, profesorPredmetController, Id);
            addprof.Show();
        }

        private void UkloniProfesora(object sender, RoutedEventArgs e)
        {
            if (ListBoxProfesori.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Izaberite predmet.");
            }
            else
            {   
                string str = ListBoxProfesori.SelectedItem.ToString();
                int index = str.IndexOf(' ');
                string result = str.Substring(0, index);
                Profesor prof = profesorController.GetProfByName(result);
                profesorPredmetController.Delete(ProfesorDTO.ToDTO(prof).Id, Id);
                ListBoxProfesori.SelectedItems.Remove(ListBoxProfesori.SelectedIndex);
                Update();
            }
        }
    }
}
