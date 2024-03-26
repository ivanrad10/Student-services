using CLI.Controller;
using CLI.Model;
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
    /// Interaction logic for StudentiKatedra.xaml
    /// </summary>
    public partial class StudentiKatedra : Window
    {
        public ProfesorController ProfesorController { get; set; }
        public StudentController StudentController { get; set; }
        public PredmetController PredmetController { get; set; }
        public KatedraController KatedraController { get; set; }
        public ProfesorPredmetController ProfesorPredmetController { get; set; }
        public StudentPredmetController StudentPredmetController { get; set; }
        public KatedraProfesorController KatedraProfesorController { get; set; }
        public StudentiKatedra(int katedraID)
        {
            InitializeComponent();
            DataContext = this;

            ProfesorController = new ProfesorController();
            StudentController = new StudentController();
            PredmetController = new PredmetController();
            KatedraController = new KatedraController();
            ProfesorPredmetController = new ProfesorPredmetController();
            StudentPredmetController = new StudentPredmetController();
            KatedraProfesorController = new KatedraProfesorController();

            List<int> idProfesoraSaKatedre = new List<int>();

            foreach (KatedraProfesor kp in KatedraProfesorController.GetAllKatProf())
            {
                if (kp.KatedraID == katedraID)
                {
                    idProfesoraSaKatedre.Add(kp.ProfesorID);
                }
            }

            List<int> idPredmetaOdProfesora = new List<int>();

            foreach(int i in idProfesoraSaKatedre)
            {
                foreach(ProfesorPredmet pp in ProfesorPredmetController.GetAllProfPred())
                {
                    if(pp.ProfesorID == i)
                    {
                        idPredmetaOdProfesora.Add(pp.PredmetID);
                    }
                }
            }

            idPredmetaOdProfesora = idPredmetaOdProfesora.Distinct().ToList();

            List<int> sviStudenti = new List<int>();

            foreach(int i in idPredmetaOdProfesora)
            {
                foreach(StudentPredmet sp in StudentPredmetController.getAllStudentPredmet())
                {
                    if(i == sp.SubjectId)
                    {
                        sviStudenti.Add(sp.StudentId);
                    }
                }
            }

            sviStudenti = sviStudenti.Distinct().ToList();

            foreach (int i in sviStudenti)
            {
                MessageBox.Show(i.ToString());
                ListBoxStudenti.Items.Add(StudentController.GetStudById(i).FirstName + " " + StudentController.GetStudById(i).LastName);
            }

        }
        public void ZatvoriOnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
