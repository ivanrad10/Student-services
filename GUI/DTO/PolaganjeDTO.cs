using CLI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
    public class PolaganjeDTO: INotifyPropertyChanged
    {

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

        public PolaganjeDTO()
        {

        }

        public static PolaganjeDTO ToDTO()
        {
            return new PolaganjeDTO();
        }
        public StudentPredmet ToStudentPredmet()
        {
            return new StudentPredmet();      
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
