using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CLI.Model
{
    public class Adresa
    {
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }

        public Adresa()
        {

        }

        public Adresa(string ulica, string broj, string grad, string drzava)
        {
            Ulica = ulica;
            Broj = broj;
            Grad = grad;
            Drzava = drzava;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Ulica,
                Broj,
                Grad,
                Drzava
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Ulica = values[0];
            Broj = values[1];
            Grad = values[2];
            Drzava = values[3];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Ulica},{Broj},{Grad},{Drzava}");

            //fale metode za ispis polozenih i nepolozenih predmeta, bice kad se napravi klasa subjects
            return sb.ToString();
        }

        public Adresa Parse(string text)
        {
            const string pattern = @"(?<Ulica>.+),(?<Broj>.+),(?<Grad>.+),(?<Drzava>.+)";
            Match match = Regex.Match(text, pattern);
            if (match.Success)
            {
                Ulica = match.Groups["Ulica"].Value;
                Broj = match.Groups["Broj"].Value;
                Grad = match.Groups["Grad"].Value;
                Drzava = match.Groups["Drzava"].Value;
                return new Adresa(Ulica, Broj, Grad, Drzava);
            }
            else
            {
                System.Console.WriteLine("\nNije uneta dobra adresa!\n");
                return new Adresa();
            }
        }
    }
}
