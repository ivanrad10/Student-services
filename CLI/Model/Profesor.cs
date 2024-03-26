using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model
{
    public class Profesor : ISerializable
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateOnly DatumRodjenja { get; set; }
        public Adresa Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Zvanje { get; set; }
        public string GodineStaza { get; set; }
        public string BrLicneKarte {  get; set; }

        public List<Subject> Predmeti { get; set; }

        public Profesor()
        {
            Predmeti = new List<Subject>();
        }

        public Profesor(string firstName, string lastName, DateOnly birthDate, Adresa adress, string phoneNumber, string email, string title, string yearsOfWork, string brLicneKarte)
        {
            Ime = firstName;
            Prezime = lastName;
            DatumRodjenja = birthDate;
            Adresa = adress;
            BrojTelefona = phoneNumber;
            Email = email;
            Zvanje = title;
            GodineStaza = yearsOfWork;
            Predmeti = new List<Subject>();
            BrLicneKarte = brLicneKarte;
        }

        public Profesor(int iD, string ime, string prezime, DateOnly datumRodjenja, Adresa adresa, string brojTelefona, string email, string zvanje, string godineStaza, string brLicneKarte)
        {
            ID = iD;
            Ime = ime;
            Prezime = prezime;
            DatumRodjenja = datumRodjenja;
            Adresa = adresa;
            BrojTelefona = brojTelefona;
            Email = email;
            Zvanje = zvanje;
            GodineStaza = godineStaza;
            BrLicneKarte = brLicneKarte;
            Predmeti = new List<Subject>();
        }


        public string[] ToCSV()
        {
            string[] csvValues =
            {
                ID.ToString(),
                Ime,
                Prezime,
                DatumRodjenja.ToString(),
                Adresa.ToString(),
                BrojTelefona,
                Email,
                Zvanje,
                GodineStaza,
                BrLicneKarte
            };
            return csvValues;
        }

        public void FromCSV(string[] Values)
        {
            ID = int.Parse(Values[0]);
            Ime = Values[1];
            Prezime = Values[2];
            DatumRodjenja = DateOnly.Parse(Values[3]);
            Adresa adresa1 = new Adresa();
            adresa1.Parse(Values[4]);
            Adresa = adresa1;
            BrojTelefona = Values[5];
            Email = Values[6];
            Zvanje = Values[7];
            GodineStaza = Values[8];
            BrLicneKarte = Values[9];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\nID: {ID}, \n");
            sb.Append($"IME: {Prezime}, \n");
            sb.Append($"PREZIME: {Ime}, \n");
            sb.Append($"DATUM RODJENJA: {DatumRodjenja}, \n");
            sb.Append($"ADRESA: {Adresa}, \n");
            sb.Append($"BROJ TELEFONA: {BrojTelefona}, \n");
            sb.Append($"EMAIL: {Email}, \n");
            sb.Append($"GODINA STUDIRANJA: {GodineStaza}, \n");
            sb.Append($"ZVANJE: {Zvanje}, \n");
            sb.Append($"BROJ LICNE KARTE: {BrLicneKarte}, \n");
            sb.Append($"PREDMETI:");

            return sb.ToString();
        }
    }
}
