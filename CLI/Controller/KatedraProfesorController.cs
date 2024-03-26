using CLI.DAO;
using CLI.Model;
using CLI.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Controller
{
    public class KatedraProfesorController
    {
        public KatedraProfesorDAO katedraProfesorDAO;

        public KatedraProfesorController()
        {
            katedraProfesorDAO = new KatedraProfesorDAO();
        }

        public List<KatedraProfesor> GetAllKatProf()
        {
            return katedraProfesorDAO.GetAllKatProfList();
        }

        public void Add(KatedraProfesor katProf)
        {
            katedraProfesorDAO.DodajKatProf(katProf);
        }

        public void Delete(int katedraID, int profesorID)
        {
            katedraProfesorDAO.IzbrisiKatProf(katedraID, profesorID);
        }

        public KatedraProfesor getKatProfByID(int katedraID, int profesorID)
        {
            return katedraProfesorDAO.GetKatProfByID(katedraID, profesorID);
        }
        public void Subscribe(IObserver observer)
        {
            katedraProfesorDAO.katProfSubj.Subsciribe(observer);
        }
    }
}
