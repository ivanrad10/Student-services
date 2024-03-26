using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CLI.Model;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace GUI.DTO
{
    public class ProfesorDTO : INotifyPropertyChanged, IDataErrorInfo
    {
        public int Id { get; set; }

        private string ime;
        public string Ime
        {
            get { return ime; }
            set
            {
                if (value != ime)
                {
                    ime = value;
                    OnPropertyChanged();
                }
            }
        }

        private string prezime;
        public string Prezime
        {
            get { return prezime; }
            set
            {
                if (value != prezime)
                {
                    prezime = value;
                    OnPropertyChanged();
                }
            }
        }

        private string datum;
        public string Datum
        {
            get { return datum; }
            set
            {
                if (value != datum)
                {

                    datum = value;
                    OnPropertyChanged();
                }
            }
        }

        private string adresa;
        public string Adresa
        {
            get { return adresa; }
            set
            {
                if (value != adresa)
                {
                    adresa = value;
                    OnPropertyChanged();
                }
            }
        }

        private string brTel;
        public string BrTel
        {
            get { return brTel; }
            set
            {
                if (value != brTel)
                {
                    brTel = value;
                    OnPropertyChanged();
                }
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                if (value != email)
                {
                    email = value;
                    OnPropertyChanged();
                }
            }
        }

        private string zvanje;
        public string Zvanje
        {
            get { return zvanje; }
            set
            {
                if (value != zvanje)
                {
                    zvanje = value;
                    OnPropertyChanged();
                }
            }
        }

        private string godStaz;
        public string GodStaz
        {
            get { return godStaz; }
            set
            {
                if (value != godStaz)
                {
                    godStaz = value;
                    OnPropertyChanged();
                }
            }
        }

        private string brLicne;
        public string BrLicne
        {
            get { return brLicne; }
            set
            {
                if (value != brLicne)
                {
                    brLicne = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Error => null;

        private Regex _ImeRegex = new Regex("[A-Za-z-]+");
        private Regex _DatumRegex = new Regex(@"^\d{1,2}/\d{1,2}/\d{4}$");
        private Regex _AdresaRegex = new Regex(@"^(\s*\w+\s*)+,\s*\w+\s*,(\s*\w+\s*)+,(\s*\w+\s*)+$"); //4 reci sa opcionim space-om
        private Regex _BrTelRegex = new Regex(@"^06\d{5,}$");
        private Regex _EmailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        private Regex _GodStazRegex = new Regex("[0-9]+");
        private Regex _BrLicneRegex = new Regex(@"^\d{3,}$");
        public string this[string columnName]
        {
            get
            {
                if (columnName == "Ime")
                {
                    if (string.IsNullOrEmpty(Ime))
                        return "Potrebno upisati ime.";

                    Match match = _ImeRegex.Match(Ime);
                    if (!match.Success)
                        return "Neispravan format, pokusajte ponovo";

                }
                else if (columnName == "Prezime")
                {
                    if (string.IsNullOrEmpty(Ime))
                        return "Potrebno upisati prezime.";

                    Match match = _ImeRegex.Match(Ime);
                    if (!match.Success)
                        return "Neispravan format, pokusajte ponovo";

                }
                else if (columnName == "Datum")
                {
                    if (string.IsNullOrEmpty(Datum))
                        return "Potrebno upisati datum.";

                    Match match = _DatumRegex.Match(Datum);
                    if (!match.Success)
                        return "Ispravan format: (mm/dd/YYYY)";

                }
                else if (columnName == "Adresa")
                {
                    if (string.IsNullOrEmpty(Adresa))
                        return "Potrebno upisati adresu.";

                    Match match = _AdresaRegex.Match(Adresa);
                    if (!match.Success)
                        return "Ispravan format: (ulica, broj, grad, drzava)";

                }
                else if (columnName == "BrTel")
                {
                    if (string.IsNullOrEmpty(BrTel))
                        return "Potrebno upisati broj telefona.";

                    Match match = _BrTelRegex.Match(BrTel);
                    if (!match.Success)
                        return "Neispravan format, pokusajte ponovo";

                }
                else if (columnName == "Email")
                {
                    if (string.IsNullOrEmpty(Email))
                        return "Potrebno upisati email.";

                    Match match = _EmailRegex.Match(Email);
                    if (!match.Success)
                        return "Neispravan format, pokusajte ponovo";

                }
                else if (columnName == "Zvanje")
                {
                    if (string.IsNullOrEmpty(Zvanje))
                        return "Potrebno upisati zvanje.";

                    Match match = _ImeRegex.Match(Zvanje);
                    if (!match.Success)
                        return "Neispravan format, pokusajte ponovo";

                }
                else if (columnName == "GodStaz")
                {
                    if (string.IsNullOrEmpty(GodStaz))
                        return "Potrebno upisati broj godina staza.";

                    Match match = _GodStazRegex.Match(GodStaz);
                    if (!match.Success)
                        return "Neispravan format, pokusajte ponovo";

                }
                else if (columnName == "BrLicne")
                {
                    if (string.IsNullOrEmpty(BrLicne))
                        return "Potrebno upisati broj licne karte.";

                    Match match = _BrLicneRegex.Match(BrLicne);
                    if (!match.Success)
                        return "Neispravan format, pokusajte ponovo";

                }
                return null;
            }
        }

        private readonly string[] _validatedProperties = { "Ime", "Prezime", "Datum", "Adresa", "BrTel", "Email", "Zvanje", "BrLicne" };

        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (this[property] != null)
                        return false;
                }

                return true;
            }
        }

        Adresa adresa1 = new Adresa();
        public Profesor ToProfesor()
        {
            return new Profesor(Id, Ime, Prezime, DateOnly.Parse(Datum), adresa1.Parse(Adresa), BrTel, Email, Zvanje, GodStaz, BrLicne);
        }

        public static ProfesorDTO ToDTO(Profesor prof)
        {
            return new ProfesorDTO(prof);
        }

        public ProfesorDTO() 
        { 
        }

        public ProfesorDTO(Profesor prof)
        {
            Id = prof.ID;
            ime = prof.Ime;
            prezime = prof.Prezime;
            datum = prof.DatumRodjenja.ToString();
            adresa = prof.Adresa.ToString();
            brTel = prof.BrojTelefona;
            email = prof.Email;
            zvanje = prof.Zvanje;
            godStaz = prof.GodineStaza;
            brLicne = prof.BrLicneKarte;

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
