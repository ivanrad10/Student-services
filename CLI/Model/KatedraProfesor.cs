using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model
{
    public class KatedraProfesor : ISerializable
    {
        public int KatedraID { get; set; }

        public int ProfesorID { get; set; }

        public KatedraProfesor()
        {
        }

        public KatedraProfesor(int katedraid, int profesorid)
        {
            KatedraID = katedraid;
            ProfesorID = profesorid;
        }

        public void FromCSV(string[] values)
        {
            KatedraID = int.Parse(values[0]);
            ProfesorID = int.Parse(values[1]);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
            KatedraID.ToString(),
            ProfesorID.ToString()
        };
            return csvValues;
        }
    }
}
