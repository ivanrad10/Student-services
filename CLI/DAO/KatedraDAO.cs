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
    public class KatedraDAO
    {
        private readonly List<Katedra> katedre;
        private readonly Storage<Katedra> storage;
        public SubjectObs katedraSubject;

        public KatedraDAO()
        {
            storage = new Storage<Katedra>("katedra.txt");
            katedre = storage.Load();
            katedraSubject = new SubjectObs();
        }

        private int GenerateID()
        {
            if (katedre.Count == 0) return 0;
            return katedre[^1].ID + 1;
        }

        public Katedra AddKatedra(Katedra kat)
        {
            kat.ID = GenerateID();
            katedre.Add(kat);
            storage.Save(katedre);
            katedraSubject.NotifyObserver();
            return kat;
        }

        public Katedra? UpdateKatedra(Katedra kat)
        {
            if (kat == null) return null;

            System.Console.WriteLine("Unesite ime: ");
            kat.Ime = System.Console.ReadLine();
            System.Console.WriteLine("Unesite sefa: ");
            kat.Sef = System.Console.ReadLine();

            storage.Save(katedre);
            katedraSubject.NotifyObserver();

            return kat;
        }
        public Katedra? RemoveKatedra(int id)
        {
            Katedra kat = GetKatByID(id);
            if (kat == null) return null;

            katedre.Remove(kat);
            storage.Save(katedre);
            katedraSubject.NotifyObserver();
            return kat;
        }

        public Katedra? GetKatByID(int id)
        {
            return katedre.Find(v => v.ID == id);
        }

        public List<Katedra> GetAllKatedra()
        {
            return katedre;
        }
    }
}
