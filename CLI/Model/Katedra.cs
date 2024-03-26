using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model
{
    public class Katedra : ISerializable
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Sef { get; set; }
        public List<Profesor> Profesori { get; set; }

        public Katedra()
        { 
            Profesori = new List<Profesor>();
        }

        public Katedra(string ime, string sef)
        {
            Ime = ime;
            Sef = sef;
            Profesori = new List<Profesor>();
        }

        public Katedra(int id, string ime, string sef)
        {
            ID= id;
            Ime = ime;
            Sef = sef;
            Profesori = new List<Profesor>();
        }

        public string[] ToCSV()
        {
            
        string[] csvValues =
            {
                ID.ToString(),
                Ime,
                Sef
                
            };
            return csvValues;
        }

    public void FromCSV(string[] Values)
        {
            ID = int.Parse(Values[0]);
            Ime = Values[1];
            Sef = Values[2];
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"ID: {ID}, \n");
            sb.Append($"IME: {Ime}, \n");
            sb.Append($"SEF: {Sef}, \n");
            sb.Append($"PROFESORI:");

            return sb.ToString();
        }
    }
}
