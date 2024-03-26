using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLI.Model
{
    public class Indeks : ISerializable
    {
        public string Smer { get; set; }
        public string Broj { get; set; }
        public string Godina { get; set; }

        public Indeks()
        { 
        }

        public Indeks(string smer, string broj, string godina)
        {
            Smer = smer;
            Broj = broj;
            Godina = godina;
        }
        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Smer,
                Broj.ToString(),
                Godina.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] Values)
        {
            Smer = Values[0];
            Broj = Values[1];
            Godina = Values[2];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Smer: {Smer}, ");
            sb.Append($"Broj Upisa: {Broj}, ");
            sb.Append($"Godina upisa: {Godina}, ");

            return sb.ToString();
        }

        public Indeks Parse(string text)
        {
            const string pattern = @"(?<Smer>.+)/(?<Broj>.+)/(?<Godina>.+)";
            Match match = Regex.Match(text, pattern);
            if (match.Success)
            {
                Smer = match.Groups["Ulica"].Value;
                Broj = match.Groups["Broj"].Value;
                Godina = match.Groups["Godina"].Value;
                return new Indeks(Smer, Broj, Godina);
            }
            else
            {
                System.Console.WriteLine("\nNije unet dobar indeks!\n");
                return new Indeks();
            }
        }
    }
}
