using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model
{
    public class ProfesorPredmet : ISerializable
    {
        public int ProfesorID { get; set; }

        public int PredmetID { get; set; }

        public ProfesorPredmet()
        {
        }

        public ProfesorPredmet(int profesorid, int predmetid)
        {
            ProfesorID = profesorid;
            PredmetID = predmetid;
        }

        public void FromCSV(string[] values)
        {
            ProfesorID = int.Parse(values[0]);
            PredmetID = int.Parse(values[1]);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
            ProfesorID.ToString(),
            PredmetID.ToString()
        };
            return csvValues;
        }
    }
}
