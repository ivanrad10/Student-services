using CLI.Controller;
using CLI.Model;
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
    /// Interaction logic for UpisOcene.xaml
    /// </summary>
    public partial class UpisOcene : Window
    {
        public StudentPredmetController studentPredmetController { get; set; }
        public ObservableCollection<PredmetDTO> PredmetiNepolozeni {  get; set; }
        public PolaganjeDTO polaganjeDTO { get; set; }
        public PredmetController predmetController { get; set; }
        public MainWindow MainWindow { get; set; }
        public bool Potvrda;
        public int Id;
        public UpisOcene(StudentPredmetController studentPredmetController, PolaganjeDTO polaganjeDTO, ObservableCollection<PredmetDTO> PredmetiNepolozeni, bool potvrda, int id)
        {
            InitializeComponent();
            DataContext = this;
            this.studentPredmetController = studentPredmetController;
            predmetController = new PredmetController();
            this.polaganjeDTO = polaganjeDTO;
            this.PredmetiNepolozeni = PredmetiNepolozeni;
            Potvrda = potvrda;
            Id = id;
        }

        public void PotvrdiOnCLick(object sender, RoutedEventArgs e)
        {
            studentPredmetController.Delete(Id, predmetController.GetPredByName(polaganjeDTO.Ime).ID);

            studentPredmetController.Add(new StudentPredmet(Id, predmetController.GetPredByName(polaganjeDTO.Ime).ID, "Polozeno", polaganjeDTO.Ocena));
            Close();
        }
        public void OdustaniOnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
