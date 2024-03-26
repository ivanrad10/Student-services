using CLI.Controller;
using GUI.DTO;
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
    /// Interaction logic for AddPredmet.xaml
    /// </summary>
    public partial class AddPredmet : Window
    {
        public PredmetDTO predmetDTO {  get; set; }
        private PredmetController predmetController;
        public AddPredmet(PredmetController predmetController)
        {
            InitializeComponent();
            DataContext = this;
            predmetDTO = new PredmetDTO();
            this.predmetController = predmetController;
        }

        private void AddOnClick(object sender, RoutedEventArgs e)
        {
            predmetController.Add(predmetDTO.ToSubject());
            Close();
        }

        private void CloseOnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
