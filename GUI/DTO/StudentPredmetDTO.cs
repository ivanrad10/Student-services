using CLI.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GUI.DTO
{
    public class StudentPredmetDTO : INotifyPropertyChanged
    {

        public int IdStudent { get; set; }
        public int IdPredmet { get; set; }

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

        public StudentPredmet ToStudentPredmet()
        {
            return new StudentPredmet(IdStudent, IdPredmet, ocena);
        }

        public StudentPredmetDTO()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
