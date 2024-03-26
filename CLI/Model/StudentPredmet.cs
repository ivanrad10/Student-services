using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model
{
    public class StudentPredmet : ISerializable
    {
        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public string polozio { get; set; } 
        public  int ocena { get; set; }
        public StudentPredmet()
        {
        }

        public StudentPredmet(int studentId, int subjectId, string p, int o)
        {
            StudentId = studentId;
            SubjectId = subjectId;
            polozio = p;
            ocena = o;
        }

        public StudentPredmet(int studentId, int subjectId, int o)
        {
            StudentId = studentId;
            SubjectId = subjectId;
            ocena = o;
        }
        public void FromCSV(string[] values)
        {
            //if za proveru praznog fajla da ne bi pucao program TREBA U SVAKOM FROM CSV!!!!!!!!!!!!!!!!!!!
            StudentId = int.Parse(values[0]);       //!!!!!!!!
            SubjectId = int.Parse(values[1]);
            polozio = values[2];
            ocena = int.Parse(values[3]);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
            StudentId.ToString(),
            SubjectId.ToString(),
            polozio,
            ocena.ToString()
            };
            return csvValues;
        }
    }
}
