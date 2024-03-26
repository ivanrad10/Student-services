using CLI.Controller;
using CLI.Model;
using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
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
using System.Xml.Linq;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for DodajNepolozeniPredmet.xaml
    /// </summary>
    public partial class DodajNepolozeniPredmet : Window
    {
        public ObservableCollection<PredmetDTO> PredmetiNerasporedjeni { get; set; }
        public PredmetController predmetController { get; set; }
        public StudentController StudentController { get; set; }
        public StudentPredmetController studentPredmetController { get; set; }
        //public PredmetDTO? SelectedPredmet { get; set; }
        public MainWindow MainWindow { get; set; }

        public List<Subject> subjects = new List<Subject>();
        private int Id;
        public DodajNepolozeniPredmet(StudentPredmetController studentPredmetController, int id)
        {
            InitializeComponent();
            DataContext = this;
            this.studentPredmetController = studentPredmetController;

            predmetController = new PredmetController();

            PredmetiNerasporedjeni = new ObservableCollection<PredmetDTO>();

            subjects = predmetController.GetAllSubjects();
            Id = id;


            List<int> ints = new List<int>();   //predmeti koje student vec ima

            foreach(Subject subject in subjects)
            {
                foreach(StudentPredmet sp in studentPredmetController.getAllStudentPredmet())
                {
                    if (sp.StudentId != Id)
                    {
                        continue;
                    }
                    else
                    {
                        ints.Add(sp.SubjectId);
                    }
                }
            }

            foreach(Subject subject1 in subjects)
            {
                if(ints.Contains(subject1.ID))
                {
                    continue;
                }
                else
                {
                    ListBoxPredmeti.Items.Add(subject1.sifra + " - " + subject1.Name);

                    PredmetiNerasporedjeni.Add(PredmetDTO.ToDTO(subject1));
                }
            }

        }

        public void PotvrdiOnCLick(object sender, RoutedEventArgs e)
        {
            if (ListBoxPredmeti.SelectedItem == null)
            {
                MessageBox.Show("Izaberite predmet.");
                return;
            }
            else
            {

                PredmetDTO pred = PredmetiNerasporedjeni[ListBoxPredmeti.SelectedIndex];
                studentPredmetController.Add(new StudentPredmet(Id, pred.Id, "Nepolozeno", 5));

                Close();
            }
        }

        public void OdustaniOnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
