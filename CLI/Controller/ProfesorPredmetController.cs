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
    public class ProfesorPredmetController
    {
        public ProfesorPredmetDAO profesorPredmetDAO;

        public ProfesorPredmetController()
        {
            profesorPredmetDAO = new ProfesorPredmetDAO();
        }

        public List<ProfesorPredmet> GetAllProfPred()
        {
            return profesorPredmetDAO.GetAllProfPredList();
        }

        public void Add(ProfesorPredmet profPred)
        {
            profesorPredmetDAO.DodajProfPred(profPred);
        }

        public void Delete(int profesorID, int predmetID)
        {
            profesorPredmetDAO.IzbrisiProfPred(profesorID, predmetID);
        }
        /*
        public void Edit(Profesor profesor)
        {
            profesorDAO.ViewUpdateProfesor(profesor);
        }

        public Profesor GetProfById(int id)
        {
            return profesorDAO.GetProfByID(id);
        }
        */
        public List<ProfesorPredmet>? getProfesorPredmetByProfesorID(int idProfesora)
        {
            return profesorPredmetDAO.getProfesorPredmetByProfesorID(idProfesora);
        }

        public List<ProfesorPredmet>? getProfesorPredmetByPredmetID(int idPredmeta)
        {
            return profesorPredmetDAO.getProfesorPredmetByProfesorID(idPredmeta);
        }
        public void Subscribe(IObserver observer)
        {
            profesorPredmetDAO.profPredSubj.Subsciribe(observer);
        }
    }
}
