using System;
using CLI.Model;

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CLI.Controller;

namespace GUI.DTO
{
    public class PredmetDTO : INotifyPropertyChanged
    {
        public MainWindow MainWindow { get; set; }
        public StudentPredmetController? StudentPredmetController { get; set; }
        public int Id { get; set; }

        private string ime;
        public string Ime
        {
            get { return ime; }
            set
            {
                if (value != ime)
                {
                    ime = value;
                    OnPropertyChanged();
                }
            }
        }

        private string sifra;
        public string Sifra
        {
            get { return sifra; }
            set
            {
                if (value != sifra)
                {
                    sifra = value;
                    OnPropertyChanged();
                }
            }
        }

        private string godinaIzvodjenja;
        public string GodinaIzvodjenja
        {
            get { return godinaIzvodjenja; }
            set
            {
                if (value != godinaIzvodjenja)
                {
                    godinaIzvodjenja = value;
                    OnPropertyChanged();
                }
            }
        }

        private string espb;
        public string Espb
        {
            get { return espb; }
            set
            {
                if (value != espb)
                {
                    espb = value;
                    OnPropertyChanged();
                }
            }
        }

        private int ocena;
        public int Ocena
        {
            get { return ocena; }
            set
            {
                if (value != ocena)
                {
                    ocena = value;
                    OnPropertyChanged();
                }
            }
        }

        private enumPredmet semestar;
        public enumPredmet Semestar
        {
            get { return semestar; }
            set
            {
                if (value != semestar)
                {
                    semestar = value;
                    OnPropertyChanged();
                }
            }
        }

        public PredmetDTO()
        {
            
        }

        public PredmetDTO(Subject s)
        {
            StudentPredmetController = new StudentPredmetController();
            ime = s.Name;
            sifra = s.sifra;
            Id = s.ID;
            semestar = s.Semestar;
            godinaIzvodjenja = s.PerformingYear.ToString();
            espb = s.ESPB.ToString();
            
        }

        public PredmetDTO(Subject s, int ocena)
        {
            StudentPredmetController = new StudentPredmetController();
            ime = s.Name;
            sifra = s.sifra;
            Id = s.ID;
            semestar = s.Semestar;
            godinaIzvodjenja = s.PerformingYear.ToString();
            espb = s.ESPB.ToString();
            Ocena = ocena;

        }

        public static PredmetDTO ToDTO(Subject pred)
        {
            return new PredmetDTO(pred);
        }
        public Subject ToSubject()
        {
            return new Subject(Id, sifra, ime, int.Parse(godinaIzvodjenja), int.Parse(espb), semestar);      //treba videti sta cemo s subjectCode int.Parse(kod),
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
