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
    public class ProfesorPredmetDTO : INotifyPropertyChanged
    {
        private int profesorID;
        private int ProfesorID
        {
            get { return profesorID;  }
            set
            {
                if(value != profesorID)
                {
                    profesorID = value;
                    OnPropertyChanged();
                }
            }
        }

        private int predmetID;
        public int PredmetID
        {
            get { return predmetID; }
            set
            {
                if (value != predmetID)
                {
                    predmetID = value;
                    OnPropertyChanged();
                }
            }
        }

        public ProfesorPredmet ToProfesorPredmet()
        {
            return new ProfesorPredmet(ProfesorID, PredmetID);
        }

        public static ProfesorPredmetDTO ToDTO(ProfesorPredmet profPred)
        {
            return new ProfesorPredmetDTO(profPred);
        }

        public ProfesorPredmetDTO()
        {
        }

        public ProfesorPredmetDTO(ProfesorPredmet profPred)
        {
            profesorID = profPred.ProfesorID;
            predmetID = profPred.PredmetID;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
