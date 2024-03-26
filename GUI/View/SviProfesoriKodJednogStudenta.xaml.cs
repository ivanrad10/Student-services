using CLI.Controller;
using CLI.Model;
using System;
using System.Collections;
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
    /// Interaction logic for SviProfesoriKodJednogStudenta.xaml
    /// </summary>
    public partial class SviProfesoriKodJednogStudenta : Window
    {
        public ProfesorController ProfesorController { get; set; }
        public StudentController StudentController { get; set; }
        public PredmetController PredmetController { get; set; }
        public ProfesorPredmetController ProfesorPredmetController { get; set; }
        public StudentPredmetController StudentPredmetController { get; set; }
        public SviProfesoriKodJednogStudenta(int studentID)
        {
            InitializeComponent();
            DataContext = this;

            ProfesorController = new ProfesorController();
            StudentController = new StudentController();
            PredmetController = new PredmetController();
            ProfesorPredmetController = new ProfesorPredmetController();
            StudentPredmetController = new StudentPredmetController();

            List<int> nizPredmetID = new List<int>();
            List<int> nizPredmetaProfesora = new List<int>();
            List<int> nizProfesorID = new List<int>();

            foreach (StudentPredmet studentPredmet in StudentPredmetController.getAllStudentPredmet())
            {
                if (studentID == studentPredmet.StudentId)
                {
                    nizPredmetID.Add(studentPredmet.SubjectId);
                }
            }

            nizPredmetID.Sort();

            foreach (int i in nizPredmetID)
            {
                List<ProfesorPredmet> profesorPredmets = new List<ProfesorPredmet>();
                profesorPredmets = ProfesorPredmetController.getProfesorPredmetByPredmetID(i);

                foreach(ProfesorPredmet profesorPredmet in profesorPredmets)
                {
                    nizProfesorID.Add(profesorPredmet.ProfesorID);
                }
            }

            nizProfesorID = nizProfesorID.Distinct().ToList();

            foreach(int i in nizProfesorID)
            {
                ListBoxProfesori.Items.Add(ProfesorController.GetProfById(i).Ime + " " + ProfesorController.GetProfById(i).Prezime);
            }
        }
        public void ZatvoriOnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
