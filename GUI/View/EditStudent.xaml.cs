using CLI.Controller;
using CLI.DAO;
using CLI.Model;
using CLI.Observer;
using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for EditStudent.xaml
    /// </summary>
    public partial class EditStudent : Window, IObserver, INotifyPropertyChanged
    {
        public ObservableCollection<StudentPredmetDTO> StudentPredmeti { get; set; }
        public ObservableCollection<PredmetDTO> PredmetiPolozeni { get; set; }
        public ObservableCollection<PredmetDTO> PredmetiNepolozeni { get; set; }
        public PredmetDTO? SelectedPredmet { get; set; }
        public StudentDTO? SelectedStudent { get; set; }
        public PredmetController predmetController { get; set; }

        private MainWindow MainWindow { get; set; }
        public StudentDTO studentDTO {  get; set; }
        private StudentController studentController;
        public StudentPredmetController studentPredmetController { get; set; }
        private int Id;
        public PolaganjeDTO polaganjeDTO { get; set; }

        public int ukupnoOcena = 0;
        public float prosek1;
        public int espb1;
        public int ESPB
        {
            get { return espb1; }
            set
            {
                if (value != espb1)
                {
                    espb1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public float Prosek
        {
            get { return prosek1; }
            set
            {
                if (value != prosek1)
                {
                    prosek1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public EditStudent(StudentController studentController, int id)
        {
            InitializeComponent();
            DataContext = this;
            studentDTO = StudentDTO.ToDTO(studentController.GetStudById(id));
            this.studentController = studentController;

            PredmetiPolozeni = new ObservableCollection<PredmetDTO>();
            PredmetiNepolozeni = new ObservableCollection<PredmetDTO>();
            studentPredmetController = new StudentPredmetController();
            studentPredmetController.Subscribe(this);
            predmetController = new PredmetController();
            polaganjeDTO = new PolaganjeDTO();

            Id = id;
            Update();
        }

        public void Update()
        {
            PredmetiPolozeni.Clear();
            PredmetiNepolozeni.Clear();
            foreach (StudentPredmet studPred in studentPredmetController.getAllStudentPredmet())
            {
                if (studPred.StudentId == Id)
                {
                    foreach (Subject pred in predmetController.GetAllSubjects())
                    {
                        if (pred.ID == studPred.SubjectId)
                        {
                            if(studPred.polozio == "Polozeno")
                            {
                                PredmetiPolozeni.Add(new PredmetDTO(pred, studPred.ocena));
                                ukupnoOcena += studPred.ocena;
                                espb1 += pred.ESPB;
                            }
                            else if(studPred.polozio == "Nepolozeno")
                            {
                                PredmetiNepolozeni.Add(new PredmetDTO(pred));
                            }
                        }
                    }
                }
            }
            if(PredmetiPolozeni.Count() != 0)
            {
                prosek1 = ukupnoOcena / PredmetiPolozeni.Count();
            }
        }

        public void ClickPonistiOcenu(object sender, RoutedEventArgs e)
        {
            if(SelectedPredmet == null)
            {
                MessageBox.Show("Izaberite predmet!");
            }
            else
            {
                studentPredmetController.Delete(Id, SelectedPredmet.Id);

                //Update();
            }
        }

        //DodajNepolozeniPredmet DodajNepolozeniPredmet = new DodajNepolozeniPredmet(); //OVDE PUCAAAAAAAAAAAAAAAAAAAAAaa
        public void DodajNepolozeni(object sender, RoutedEventArgs e)
        {
            DodajNepolozeniPredmet dodajNepolozeniPredmet = new DodajNepolozeniPredmet(studentPredmetController, Id);

            dodajNepolozeniPredmet.Show();
            //studentPredmetController.Delete(MainWindow.SelectedStudent.Id, SelectedPredmet.Id);

            //Update(MainWindow.SelectedStudent.Id);
        }

        public void ObrisiNepolozeni(object sender, RoutedEventArgs e)
        {
            if (SelectedPredmet == null)
            {
                MessageBox.Show("Izaberite predmet!");
            }
            else
            {
                studentPredmetController.Delete(Id, SelectedPredmet.Id);

                Update();
            }
        }
        public bool potvrda;
        public void PolaganjePredmeta(object sender, RoutedEventArgs e)
        {
            UpisOcene upisOcene = new UpisOcene(studentPredmetController, polaganjeDTO, PredmetiNepolozeni, potvrda, Id);
            upisOcene.Show();
            //predmetController.GetPredByName(polaganjeDTO.Ime).ID
        }

        public void EditOnClick(object sender, RoutedEventArgs e)
        {
            if (studentDTO.IsValid)
            {
                studentController.Edit(studentDTO.ToStudent());
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

        private void openInformacije(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }
        private void openPolozeni(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void openNepolozeni(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
