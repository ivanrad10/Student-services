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
using System.Xml.Linq;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for SviStudentiZaSvePredmeteProfesora.xaml
    /// </summary>
    public partial class SviStudentiZaSvePredmeteProfesora : Window
    {
        public ProfesorController ProfesorController { get; set; }
        public StudentController StudentController { get; set; }
        public PredmetController PredmetController { get; set; }
        public ProfesorPredmetController ProfesorPredmetController { get; set; }
        public StudentPredmetController StudentPredmetController { get; set; }
        public SviStudentiZaSvePredmeteProfesora(int profesorID)
        {
            InitializeComponent();
            DataContext = this;

            ProfesorController = new ProfesorController();
            StudentController = new StudentController();
            PredmetController = new PredmetController();
            ProfesorPredmetController = new ProfesorPredmetController();
            StudentPredmetController = new StudentPredmetController();

            List<int> nizPredmetID = new List<int>();
            List<int> nizPredmetaStudenata = new List<int>();
            List<int> nizStudetID = new List<int>();

            foreach(ProfesorPredmet profesorPredmet in ProfesorPredmetController.GetAllProfPred())
            {
                if (profesorID == profesorPredmet.ProfesorID)
                {
                    nizPredmetID.Add(profesorPredmet.PredmetID);
                }
            }
            nizPredmetID.Sort();

            nizPredmetID = nizPredmetID.Distinct().ToList();

            foreach (Student student in StudentController.getAllStudents())
            {
                foreach(StudentPredmet? studentPredmet in StudentPredmetController.getStudentPredmetByStudentID(student.ID))
                {
                    nizPredmetaStudenata.Add(studentPredmet.SubjectId);
                }

                nizPredmetaStudenata.Sort();
                nizPredmetaStudenata = nizPredmetaStudenata.Distinct().ToList();

                bool sadrzi = nizPredmetID.All(item => nizPredmetaStudenata .Contains(item));
                if (sadrzi)
                {
                    ListBoxStudenti.Items.Add(student.FirstName + " " + student.LastName);
                }
            }
        }
        public void ZatvoriOnClick(object sender, RoutedEventArgs e)
        {
            Close();   
        }
    }
}
