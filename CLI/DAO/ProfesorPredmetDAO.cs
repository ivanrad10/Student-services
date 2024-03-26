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
    public class ProfesorPredmetDAO
    {
        public List<ProfesorPredmet> profpedLista;
        private readonly Storage<ProfesorPredmet> storage;

        public SubjectObs profPredSubj;

        public ProfesorPredmetDAO()
        {
            storage = new Storage<ProfesorPredmet>("profesorPredmet.txt");
            profpedLista = storage.Load();
            profPredSubj = new SubjectObs();
        }

        public ProfesorPredmet? DodajProfPred(ProfesorPredmet pp)
        {
            if (profpedLista.Any(s => s.ProfesorID == pp.ProfesorID && s.PredmetID == pp.PredmetID))
            {
                System.Console.WriteLine("\nVec je dodat.");
                return null;
            }

            System.Console.WriteLine("\nUspesno ste dodali predmet za profesora.");
            profpedLista.Add(pp);
            storage.Save(profpedLista);
            profPredSubj.NotifyObserver();
            return pp;
        }

        public ProfesorPredmet? IzbrisiProfPred(int profid, int predid)
        {
            ProfesorPredmet profpred = GetProfPredByID(profid, predid);
            if (profpred == null)
            {
                System.Console.WriteLine("\nProfesor ne predaje zadati predmet.");
                return null;
            }

            System.Console.WriteLine("\nUspesno ste izbrisali predmet kod profesora.");
            profpedLista.Remove(profpred);
            storage.Save(profpedLista);
            profPredSubj.NotifyObserver();

            return profpred;
        }

        public ProfesorPredmet? GetProfPredByID(int profid, int predid)
        {
            return profpedLista.Find(s => s.ProfesorID == profid && s.PredmetID == predid);
        }

        public List<ProfesorPredmet>? getProfesorPredmetByProfesorID(int idProfesora)
        {
            List<ProfesorPredmet> list = GetAllProfPredList();
            List<ProfesorPredmet> retVal = new List<ProfesorPredmet>();

            foreach (ProfesorPredmet pp in list)
            {
                if (idProfesora == pp.ProfesorID)
                {
                    retVal.Add(pp);
                }
            }

            return retVal;
        }

        public List<ProfesorPredmet>? getProfesorPredmetByPredmetID(int idPredmeta)
        {
            List<ProfesorPredmet> list = GetAllProfPredList();
            List<ProfesorPredmet> retVal = new List<ProfesorPredmet>();

            foreach (ProfesorPredmet pp in list)
            {
                if (idPredmeta == pp.PredmetID)
                {
                    retVal.Add(pp);
                }
            }

            return retVal;
        }
        public List<ProfesorPredmet> GetAllProfPredList()
        {
            return profpedLista;
        }
    }
}
