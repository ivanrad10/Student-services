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
    public class KatedraDTO : INotifyPropertyChanged
    {
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

        private string sef;
        public string Sef
        {
            get { return sef; }
            set
            {
                if (value != sef)
                {
                    sef = value;
                    OnPropertyChanged();
                }
            }
        }

        public Katedra ToKatedra()
        {
            return new Katedra(Id, Ime, Sef);
        }

        public KatedraDTO()
        {
        }

        public KatedraDTO(Katedra kat)
        {
            Id = kat.ID;
            ime = kat.Ime;
            sef = kat.Sef;

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
