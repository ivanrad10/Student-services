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
    public class KatedraProfesorDAO
    {
        public List<KatedraProfesor> katprofLista;
        private readonly Storage<KatedraProfesor> storage;
        public SubjectObs katProfSubj;

        public KatedraProfesorDAO()
        {
            storage = new Storage<KatedraProfesor>("katedraProfesor.txt");
            katprofLista = storage.Load();
            katProfSubj = new SubjectObs();
        }

        public KatedraProfesor? DodajKatProf(KatedraProfesor kp)
        {
            if (katprofLista.Any(s=> s.KatedraID==kp.KatedraID && s.ProfesorID==kp.ProfesorID))
            { 
                System.Console.WriteLine("\nVec je dodat.");
                return null;
            }

            System.Console.WriteLine("\nUspesno ste dodali profesora na katedru.");
            katprofLista.Add(kp);
            storage.Save(katprofLista);
            katProfSubj.NotifyObserver();
            return kp;
        }

        public KatedraProfesor? IzbrisiKatProf(int katid, int profid)
        {
            KatedraProfesor katprof = GetKatProfByID(katid, profid);
            if (katprof == null)
            {
                System.Console.WriteLine("\nProfesor nije na zadatoj katedri.");
                return null;
            }

            System.Console.WriteLine("\nUspesno ste izbrisali profesora sa katedre.");
            katprofLista.Remove(katprof);
            storage.Save(katprofLista);
            katProfSubj.NotifyObserver();

            return katprof;
        }

        public KatedraProfesor? GetKatProfByID(int katid, int profid)
        {
            return katprofLista.Find(s => s.KatedraID == katid && s.ProfesorID == profid);
        }

        public List<KatedraProfesor> GetAllKatProfList()
        {
            return katprofLista;
        }
    }
}
