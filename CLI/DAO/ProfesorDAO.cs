using CLI.Model;
using CLI.Storage;
using CLI.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.DAO
{
    public class ProfesorDAO
    {
        private readonly List<Profesor> profesors;
        private readonly Storage<Profesor> storage;
        public SubjectObs profesorSubject;

        public ProfesorDAO()
        {
            storage = new Storage<Profesor>("profesor.txt");
            profesors = storage.Load();
            profesorSubject = new SubjectObs();
        }

        private int GenerateID()
        {
            if(profesors.Count == 0) return 0;
            return profesors[^1].ID + 1;
        }

        public Profesor AddProfesor(Profesor prof)
        {
            prof.ID = GenerateID();
            profesors.Add(prof);
            storage.Save(profesors);
            profesorSubject.NotifyObserver();
            return prof;
        }

        public Profesor? UpdateProfesor(Profesor prof)
        {
            if (prof == null) return null;

            System.Console.WriteLine("Unesite ime: ");
            prof.Ime = System.Console.ReadLine();

            System.Console.WriteLine("Unesite prezime: ");
            prof.Prezime = System.Console.ReadLine();

            System.Console.WriteLine("Unesite email: ");
            prof.Email = System.Console.ReadLine();

            System.Console.WriteLine("Unesite adresu (Pravilo unosa: ulica,broj,grad,drzava): ");
            string adresa = System.Console.ReadLine();
            Adresa adresa1 = new Adresa();
            adresa1.Parse(adresa);
            prof.Adresa = adresa1;

            System.Console.WriteLine("Unesite broj telefona: ");
            prof.BrojTelefona = System.Console.ReadLine();

            System.Console.WriteLine("Unesite zvanje: ");
            prof.Zvanje = System.Console.ReadLine();

            System.Console.WriteLine("Unesite datum rodjenja (01/01/2000): ");
            string datum = System.Console.ReadLine();
            prof.DatumRodjenja = DateOnly.Parse(datum);

            System.Console.WriteLine("Unesite godine staza: ");
            prof.GodineStaza = System.Console.ReadLine();

            System.Console.WriteLine("Unesite broj licne karte: ");
            prof.BrLicneKarte = System.Console.ReadLine();

            storage.Save(profesors);
            profesorSubject.NotifyObserver();

            return prof;
        }

        public Profesor? ViewUpdateProfesor(Profesor noviProf)
        {
            Profesor? stariProf = GetProfByID(noviProf.ID);
            if(stariProf == null)
            {
                return null;
            }

            stariProf.Adresa = noviProf.Adresa;
            stariProf.BrLicneKarte = noviProf.BrLicneKarte;
            stariProf.DatumRodjenja = noviProf.DatumRodjenja;
            stariProf.BrojTelefona = noviProf.BrojTelefona;
            stariProf.Prezime = noviProf.Prezime;
            stariProf.Email = noviProf.Email;
            stariProf.Ime = noviProf.Ime;
            stariProf.GodineStaza = noviProf.GodineStaza;

            storage.Save(profesors);
            profesorSubject.NotifyObserver();
            return stariProf;
        }

        public Profesor? RemoveProfesor(int id)
        {
            Profesor prof = GetProfByID(id);
            if (prof == null) return null;

            profesors.Remove(prof);
            storage.Save(profesors);
            profesorSubject.NotifyObserver();
            return prof;
        }

        public Profesor? GetProfByID(int id)
        {
           return  profesors.Find(v => v.ID == id);
        }

        public Profesor? GetProfByName(string ime)
        {
            return profesors.Find(v => v.Ime == ime);
        }

        public List<Profesor> GetAllProfesors()
        {
            return profesors;
        }
    }
}
