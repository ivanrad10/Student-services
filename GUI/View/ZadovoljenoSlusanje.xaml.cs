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
    /// Interaction logic for ZadovoljenoSlusanje.xaml
    /// </summary>
    public partial class ZadovoljenoSlusanje : Window
    {
        public StudentController StudentController { get; set; }
        public PredmetController PredmetController { get; set; }
        public StudentPredmetController StudentPredmetController { get; set; }

        int prviPredmet;
        public ZadovoljenoSlusanje(int predmetID)
        {
            InitializeComponent();
            DataContext = this;

            prviPredmet = predmetID;

            StudentController = new StudentController();
            PredmetController = new PredmetController();
            StudentPredmetController = new StudentPredmetController();
            
            List<Subject> predmeti = new List<Subject>();

            predmeti = PredmetController.GetAllSubjects();

            foreach(Subject subject in predmeti)
            {
                if(subject.ID != predmetID)
                {
                    ListBoxPredmeti.Items.Add(subject.Name);
                }
            }
        }

        public void IzaberiDrugiOnClick(object sender, RoutedEventArgs e)
        {
            if(ListBoxPredmeti.SelectedItem == null)
            {
                MessageBox.Show("Izaberite drugi predmet!");
                return;
            }

            BiranjeDrugogPredmeta biranjeDrugogPredmeta = new BiranjeDrugogPredmeta(prviPredmet, PredmetController.GetPredByName(ListBoxPredmeti.SelectedItem.ToString()).ID);

            biranjeDrugogPredmeta.Show();
        }
    }
}
