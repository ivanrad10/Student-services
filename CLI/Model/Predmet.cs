using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum enumPredmet
{
    Zimski,
    Letnji
};

namespace CLI.Model
{
    public class Subject : ISerializable
    {
        public int ID { get; set; }

        public string sifra { get; set; }   
        public string Name { get; set; }
        //public int SubjectCode { get; set; }
        public enumPredmet Semestar;
        public int PerformingYear { get; set; }
        public Profesor Profesor { get; set; }
        public int ESPB { get; set; }
        public List<Student> StudentsThatPassed { get; set; }
        public List<Student> StudentsThatFailed { get; set; }

        public Subject()
        {
            StudentsThatFailed = new List<Student>();
            StudentsThatPassed = new List<Student>();

        }

        public Subject(string name, int pYear, int espb) 
        {
            Name = name;
            PerformingYear  = pYear;
            ESPB = espb;
            StudentsThatFailed = new List<Student>();
            StudentsThatPassed = new List<Student>();
        }

        public Subject(int id, string sif, string name, int pYear, int espb, enumPredmet semestar)
        {
            ID = id;
            Name = name;
            sifra = sif;
            Semestar = semestar;
            PerformingYear = pYear;
            ESPB = espb;
            StudentsThatFailed = new List<Student>();
            StudentsThatPassed = new List<Student>();
        }

        public Subject(int id, string sif, string name, int pYear, int espb, enumPredmet semestar, Profesor profesor)
        {
            ID = id;
            Name = name;
            sifra = sif;
            Semestar = semestar;
            PerformingYear = pYear;
            ESPB = espb;
            Profesor = profesor;
            StudentsThatFailed = new List<Student>();
            StudentsThatPassed = new List<Student>();
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                ID.ToString(),
                sifra,
                Name,
                PerformingYear.ToString(),
                ESPB.ToString(),
                Semestar.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] Values)
        {
            ID = int.Parse(Values[0]); 
            sifra = Values[1];
            Name = Values[2];
            PerformingYear = int.Parse(Values[3]);
            ESPB = int.Parse(Values[4]);

            if (Values[5] == "Letnji")
            {
                Semestar = enumPredmet.Letnji;
            }
            else if (Values[5] == "Zimski")
            {
                Semestar = enumPredmet.Zimski;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Ime: {Name}, ");
            sb.Append($"Sifra predmeta: {sifra}, ");
            sb.Append($"Godina izvodjenja: {PerformingYear}, ");
            sb.Append($"ESPB: {ESPB}, ");
            sb.Append($"Semesetar: {Semestar}, ");
            sb.Append($"Profesor koji predaje: {Profesor}, ");

            return sb.ToString();
        }
    }
}
