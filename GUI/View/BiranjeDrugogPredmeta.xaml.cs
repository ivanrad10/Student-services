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
using System.Xml.Linq;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for BiranjeDrugogPredmeta.xaml
    /// </summary>
    public partial class BiranjeDrugogPredmeta : Window
    {
        public StudentController StudentController { get; set; }
        public PredmetController PredmetController { get; set; }
        public StudentPredmetController StudentPredmetController { get; set; }
        public BiranjeDrugogPredmeta(int idPrvog, int idDrugog)
        {
            InitializeComponent();
            DataContext = this;

            StudentController = new StudentController();
            PredmetController = new PredmetController();
            StudentPredmetController = new StudentPredmetController();

            Subject predmet1 = new Subject();
            predmet1 = PredmetController.GetPredById(idPrvog);

            Subject predmet2 = new Subject();
            predmet2 = PredmetController.GetPredById(idDrugog);

            List<int> idStudenataZaPredmet1 = new List<int>();
            List<int> idStudenataZaPredmet2 = new List<int>();

            foreach (StudentPredmet sp in StudentPredmetController.getAllStudentPredmet())
            {
                if (sp.SubjectId == idPrvog)
                {
                    idStudenataZaPredmet1.Add(sp.StudentId);
                }
            }

            foreach (StudentPredmet sp in StudentPredmetController.getAllStudentPredmet())
            {
                if (sp.SubjectId == idDrugog)
                {
                    idStudenataZaPredmet2.Add(sp.StudentId);
                }
            }

            List<int> zajednicki = new List<int>();

            zajednicki = idStudenataZaPredmet1.Intersect(idStudenataZaPredmet2).ToList();

            foreach (int i in zajednicki)
            {
                listBox1.Items.Add(StudentController.GetStudById(i).FirstName + " " + StudentController.GetStudById(i).LastName);
            }

            foreach (int i in zajednicki)
            {
                List<StudentPredmet> studentPredmet = new List<StudentPredmet>();

                studentPredmet = StudentPredmetController.getStudentPredmetByStudentID(i);

                if ((studentPredmet[0].polozio == "Polozeno" && studentPredmet[1].polozio == "Nepolozeno") || (studentPredmet[1].polozio == "Polozeno" && studentPredmet[0].polozio == "Nepolozeno"))
                {
                    listBox2.Items.Add(StudentController.GetStudById(i).FirstName + " " + StudentController.GetStudById(i).LastName);
                }
            }
        }
        public void ZatvoriOnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
