using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model
{
    public class Ocene
    {
        public Student StudentPolozio { get; set; }
        public Subject Predmet { get; set; }
        public int Ocena;

        public DateOnly datumPolaganja { get; set; }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                StudentPolozio.ID.ToString(),
                Predmet.ID.ToString(),
                Ocena.ToString(),
                datumPolaganja.ToString(),
            };
            return csvValues;
        }

        public void FromCSV(string[] Values)
        {
            StudentPolozio.ID = int.Parse(Values[0]);
            Predmet.ID = int.Parse(Values[1]);
            Ocena = int.Parse(Values[2]);
            datumPolaganja = DateOnly.Parse(Values[3]);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Student koji je polozio: {StudentPolozio}, ");
            sb.Append($"Predmet: {Predmet}, ");
            sb.Append($"Ocena: {Ocena}, ");

            return sb.ToString();
        }
    }
}
