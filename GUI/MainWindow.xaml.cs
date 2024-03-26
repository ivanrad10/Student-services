using CLI.Controller;
using CLI.Model;
using CLI.Observer;
using GUI.DTO;
using GUI.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
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
using System.Windows.Navigation;
using System.IO;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Text.RegularExpressions;
using CLI.DAO;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IObserver, INotifyPropertyChanged
    {
        private App app;
        private const string SRB = "sr-RS";
        private const string ENG = "en-US";
        //---------------------------------------------------
        public ObservableCollection<ProfesorDTO> Profesori { get; set; }
        public ProfesorDTO? SelectedProfesor { get; set; }
        private ProfesorController profesorController {  get; set; }

        // -----------------------------------------------------------------
        public ObservableCollection<StudentDTO> Studenti { get; set; }
        public static StudentDTO? SelectedStudent { get; set; }
        private StudentController studentController { get; set; }

        // -----------------------------------------------------------------

        public ObservableCollection<PredmetDTO> Predmeti { get; set; }
        public PredmetDTO? SelectedPredmet { get; set; }
        private PredmetController predmetController { get; set; }

        //------------------------------------------------------------------

        private string statusBarName = "Profesor";

        public static int selectedItemID;

        public string StatusBarName
        {
            get { return statusBarName; }
            set
            {
                if (value != statusBarName)
                {
                    statusBarName = value;
                    OnPropertyChanged();
                }
            }
        }
   
        private Boolean profFlag = true;
        private Boolean studFlag = false;
        private Boolean predFlag = false;
        public MainWindow()
        { 

            InitializeComponent();
            DataContext = this;

            app = (App)Application.Current;
            app.ChangeLanguage(SRB);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(UpdateTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            Profesori = new ObservableCollection<ProfesorDTO>();
            profesorController = new ProfesorController();
            profesorController.Subscribe(this);
            
            Studenti = new ObservableCollection<StudentDTO>();
            studentController = new StudentController();
            studentController.Subscribe(this);

            Predmeti = new ObservableCollection<PredmetDTO>();
            predmetController = new PredmetController();
            predmetController.Subscribe(this);

            string imagePathAdd = "." + System.IO.Path.DirectorySeparatorChar + "Resources" + System.IO.Path.DirectorySeparatorChar + "icons8-add-30.bmp";
            addImage.Source = new BitmapImage(new Uri(imagePathAdd, UriKind.Relative));
            
            string imagePathDelete = "." + System.IO.Path.DirectorySeparatorChar + "Resources" + System.IO.Path.DirectorySeparatorChar + "icons8-delete-30.bmp";
            deleteImage.Source = new BitmapImage(new Uri(imagePathDelete, UriKind.Relative));
            
            string imagePathEdit = "." + System.IO.Path.DirectorySeparatorChar + "Resources" + System.IO.Path.DirectorySeparatorChar + "icons8-edit-profile-24.bmp";
            editUserImage.Source = new BitmapImage(new Uri(imagePathEdit, UriKind.Relative));

            string imagePathSearch = "." + System.IO.Path.DirectorySeparatorChar + "Resources" + System.IO.Path.DirectorySeparatorChar + "search.bmp";
            searchImage.Source = new BitmapImage(new Uri(imagePathSearch, UriKind.Relative));
            
            Update();
        }

        public void Search(object sender, RoutedEventArgs e)
        {
            string text = pretraga.GetLineText(0);

            const string pattern1 = @"(?<Prezime>.+),(?<Ime>.+)";
            const string pattern2 = @"(?<Prezime>.+)";
            string prazan = "";
            Match match1 = Regex.Match(text, pattern1);
            Match match2 = Regex.Match(text, pattern2);
            Match match3 = Regex.Match(text, prazan);
            if (match1.Success)
            {
                string prezime = match1.Groups["Prezime"].Value.ToLower();
                string ime = match1.Groups["Ime"].Value.ToLower();

                Profesori.Clear();

                foreach (Profesor prof in profesorController.GetAllProfesors())
                {
                    if (prof.Prezime.ToLower().Contains(prezime) && prof.Ime.ToLower().Contains(ime))
                    {
                        Profesori.Add(new ProfesorDTO(prof));
                    }
                }
            }
            else if (match2.Success)
            {
                string prezime = match2.Groups["Prezime"].Value.ToLower();

                Profesori.Clear();

                foreach (Profesor prof in profesorController.GetAllProfesors())
                {
                    if (prof.Prezime.ToLower().Contains(prezime))
                    {
                        Profesori.Add(new ProfesorDTO(prof));
                    }
                }
            }
            else if (match3.Success)
            {
                Profesori.Clear();
                foreach (Profesor prof in profesorController.GetAllProfesors())
                {
                    Profesori.Add(new ProfesorDTO(prof));
                }
            }
            else
            {
                MessageBox.Show("Nije dobro uneta pretraga.\nPokusajte sledeci unos: prezime, ime\n gde je 'ime' opciono.");
            }
        }

        private void openProfesor(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void openStudent(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void openPredmet(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            DisplayDate.Text = DateTime.Now.ToString();
        }
        public void Update()
        {
            Profesori.Clear();
            foreach(Profesor prof in profesorController.GetAllProfesors())
            {
                Profesori.Add(new ProfesorDTO(prof));
            }

            Studenti.Clear();
            foreach(Student student in studentController.getAllStudents())
            {
                Studenti.Add(new StudentDTO(student));
            }

            Predmeti.Clear();
            foreach(Subject s in predmetController.GetAllSubjects())
            {
                Predmeti.Add(new PredmetDTO(s));
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {

            if (profFlag == true)
            {
                AddProfesor addProfesor = new AddProfesor(profesorController);
                addProfesor.Show();
            }
            else if (studFlag == true)
            {
                AddStudent addStudent = new AddStudent(studentController);
                addStudent.Show();
            }
            else
            {
                AddPredmet addPredmet = new AddPredmet(predmetController);
                addPredmet.Show();
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
        
            if (profFlag == true)
            {
                if (SelectedProfesor != null)
                {
                    profesorController.Delete(SelectedProfesor.Id);
                }
                else
                {
                    MessageBox.Show("Izaberite nekog od profesora.");
                }
            }
            else if(studFlag == true)
            {
                if (SelectedStudent != null)
                {
                    studentController.Delete(SelectedStudent.Id);
                }
                else
                {
                    MessageBox.Show("Izaberite nekog od studenata.");
                }
            }
            else
            {
                if(SelectedPredmet != null)
                {
                    predmetController.Delete(SelectedPredmet.Id);
                }
                else
                {
                    MessageBox.Show("Izaberite neki predmet.");
                }
            }

        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (profFlag == true)
            {
                if(SelectedProfesor == null)
                {
                    MessageBox.Show("Izaberite nekog od profesora.");
                }
                else
                {
                    EditProfesor editProfesor = new EditProfesor(profesorController, SelectedProfesor.Id);
                    editProfesor.Show();
                }
            }
            else if(studFlag == true)
            {
                if(SelectedStudent == null)
                {
                    MessageBox.Show("Izaberite nekog od studenata.");
                }
                else
                {
                    EditStudent editStudent = new EditStudent(studentController, SelectedStudent.Id);
                    //selectedItemID = SelectedStudent.Id;
                    editStudent.Show();
                }
            }
            else
            {
                if(SelectedPredmet == null)
                {
                    MessageBox.Show("Izaberite neki predmet.");
                }
                else
                {
                    EditPredmet editPredmet = new EditPredmet(predmetController, SelectedPredmet.Id);
                    editPredmet.Show();
                }
            }
        }

        private void openKatedra(object sender, RoutedEventArgs e)
        {
            KatedraView katedraView = new KatedraView();
            katedraView.Show();
        }

        private void About(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Promene sacuvane.");
        }

        private void IsOnProf( object sender, RoutedEventArgs e)
        {
            StatusBarName = "Profesor";
            profFlag = true;
            studFlag = false;
            predFlag = false;
        }

        private void IsOnStud(object sender, RoutedEventArgs e)
        {
            StatusBarName = "Student ";
            profFlag = false;
            studFlag = true;
            predFlag = false;
        }

        public void IsOnPred( object sender, RoutedEventArgs e)
        {
            StatusBarName = "Predmet";
            profFlag = false;
            studFlag = false;
            predFlag = true;
        }

        private void MenuItem_Click_Serbian(object sender, RoutedEventArgs e)
        {
            app.ChangeLanguage(SRB);
        }

        private void MenuItem_Click_English(object sender, RoutedEventArgs e)
        {
            app.ChangeLanguage(ENG);
        }

        
        public void SviStudentiZaSvePredmete(object sender, RoutedEventArgs e)
        {
            if(SelectedProfesor == null)
            {
                MessageBox.Show("Izaberite nekog profesora!");
                return;
            }
            SviStudentiZaSvePredmeteProfesora sviStudentiZaSvePredmeteProfesora = new SviStudentiZaSvePredmeteProfesora(SelectedProfesor.Id);

            sviStudentiZaSvePredmeteProfesora.Show();

        }

        public void SviProfesoriZaStudenta(object sender, RoutedEventArgs e)
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("Izaberite nekog studenta!");
                return;
            }
            SviProfesoriKodJednogStudenta sviProfesoriKodJednogStudenta = new SviProfesoriKodJednogStudenta(SelectedStudent.Id);

            sviProfesoriKodJednogStudenta.Show();
        }

        public void ZadovoljenoSLusanjePredmeta(object sender, RoutedEventArgs e)
        {
            if (SelectedPredmet == null)
            {
                MessageBox.Show("Izaberite neki predmet!");
                return;
            }
            ZadovoljenoSlusanje zadovoljenoSLusanje = new ZadovoljenoSlusanje(SelectedPredmet.Id);

            zadovoljenoSLusanje.Show();
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
