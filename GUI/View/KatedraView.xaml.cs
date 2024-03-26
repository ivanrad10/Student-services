using CLI.Controller;
using CLI.Model;
using CLI.Observer;
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
    /// Interaction logic for KatedraView.xaml
    /// </summary>
    public partial class KatedraView : Window, IObserver
    {
        public ObservableCollection<KatedraDTO> Katedre { get; set; }
        public KatedraDTO? SelectedKatedra { get; set; }
        private KatedraController katedraController { get; set; }
        public KatedraView()
        {
            InitializeComponent();
            DataContext = this;

            Katedre = new ObservableCollection<KatedraDTO>();
            katedraController = new KatedraController();
            katedraController.Subscribe(this);

            Update();
        }

        public void Update()
        {
            Katedre.Clear();
            foreach(Katedra kat in katedraController.GetAllKatedras())
            {
                Katedre.Add(new KatedraDTO(kat));
            }
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            /*
            if (profFlag == true)
            {
                AddProfesor addProfesor = new AddProfesor(profesorController);
                addProfesor.Show();
            }
            */
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            /*
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
            */
        }
        private void Edit(object sender, RoutedEventArgs e)
        {
            if (SelectedKatedra == null)
            {
                MessageBox.Show("Izaberite neku katedru.");
            }
            else
            {
                EditKatedra editKat = new EditKatedra(katedraController, SelectedKatedra.Id);
                editKat.Show();
            }
        }

        public void studentiNaKatedri(object sender, RoutedEventArgs e)
        {
            if (SelectedKatedra == null)
            {
                MessageBox.Show("Izaberite neku katedru.");
                return;
            }

            StudentiKatedra studentiKatedra = new StudentiKatedra(SelectedKatedra.Id);

            studentiKatedra.Show();
        }
    }
}
