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
    /// Interaction logic for AddPredmetToProfesor.xaml
    /// </summary>
    public partial class AddPredmetToProfesor : Window
    {
        public ObservableCollection<PredmetDTO> PredmetiPreostali { get; set; }
        public ObservableCollection<PredmetDTO> Predmeti { get; set; }
        private PredmetController predmetController;
        private ProfesorPredmetController profesorPredmetController;
        public int profId;
        public AddPredmetToProfesor(ObservableCollection<PredmetDTO> Predmeti, ProfesorPredmetController profesorPredmetController, int id)
        {
            InitializeComponent();
            DataContext = this;
            this.profesorPredmetController = profesorPredmetController;
            this.Predmeti = Predmeti;

            PredmetiPreostali = new ObservableCollection<PredmetDTO>();
            predmetController = new PredmetController();

            ObservableCollection<int> ids = new ObservableCollection<int>(); 
            foreach(PredmetDTO pred in Predmeti)
            {
                ids.Add(pred.Id);
            }


            foreach (Subject pred in predmetController.GetAllSubjects())
            {
                if(!ids.Contains(pred.ID))
                {

                    ListBoxPredmeti.Items.Add(pred.sifra + " - " + pred.Name);
                    PredmetiPreostali.Add(new PredmetDTO(pred));
                }
            }

            profId = id;
        }

        public void PotvrdiOnCLick(object sender, RoutedEventArgs e)
        {
            if (ListBoxPredmeti.SelectedItem == null)
            {
                MessageBox.Show("Izaberite predmet.");
                return;
            }

            PredmetDTO pred = PredmetiPreostali[ListBoxPredmeti.SelectedIndex];
            profesorPredmetController.Add(new ProfesorPredmet(profId, pred.Id));
            Close();
        }

        public void OdustaniOnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
