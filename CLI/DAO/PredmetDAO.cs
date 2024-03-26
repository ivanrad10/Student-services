using CLI.Model;
using CLI.Observer;
using CLI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.DAO
{
    public class PredmetDAO
    {
        private readonly List<Subject> subjects;
        private readonly Storage<Subject> storage;
        public SubjectObs predmetSubject;
        public PredmetDAO()
        {
            storage = new Storage<Subject>("subject.txt");
            subjects = storage.Load();
            predmetSubject = new SubjectObs();
        }

        private int GenerateSubjectCode()
        {
            if (subjects.Count == 0) return 0;
            return subjects[^1].ID + 1;
        }

        public Subject AddSbujects(Subject subject)
        {
            subject.ID = GenerateSubjectCode();
            subjects.Add(subject);
            storage.Save(subjects);
            predmetSubject.NotifyObserver();
            return subject;
        }

        public Subject UpdateSubject(Subject subject)
        {
            System.Console.WriteLine("Unesite novo ime: ");
            string nesto = System.Console.ReadLine();

            subject.Name = nesto;

            System.Console.WriteLine("Unesite novu godinu izvodjenja: ");
            int nesto1 = int.Parse(System.Console.ReadLine());

            subject.PerformingYear = nesto1;

            System.Console.WriteLine("Unesite novi broj ESPB bodova koje predmet nosi: ");
            int nesto3 = int.Parse(System.Console.ReadLine());

            subject.ESPB = nesto3;

            storage.Save(subjects); 
            predmetSubject.NotifyObserver();

            return subject;
        }
        public Subject RemoveSubject(int ID)
        {
            Subject subject = GetSubjByID(ID);
            if (subject == null) return null;

            subjects.Remove(subject);
            storage.Save(subjects);
            predmetSubject.NotifyObserver();

            return subject;
        }

        public Subject? ViewUpdatePredmet(Subject novi)
        {
            Subject? stari = GetSubjByID(novi.ID);
            if (stari == null)
            {
                return null;
            }

            stari.sifra = novi.sifra;
            stari.Name = novi.Name;
            stari.ESPB = novi.ESPB;
            stari.PerformingYear = novi.PerformingYear;
            stari.Semestar = novi.Semestar;
            stari.Profesor = novi.Profesor;

            storage.Save(subjects);
            predmetSubject.NotifyObserver();
            return stari;
        }
        public Subject GetSubjByID(int id)
        {
            return subjects.Find(v => v.ID == id);
        }

        public Subject GetSubjByName(string name)
        {
            return subjects.Find(v => v.Name == name);
        }

        public List<Subject> GetAllSubjects()
        {
            return subjects;
        }
    }
}
