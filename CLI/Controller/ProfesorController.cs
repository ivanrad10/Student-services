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
    public class ProfesorController
    {
        public ProfesorDAO profesorDAO;

        public ProfesorController()
        {
            profesorDAO = new ProfesorDAO();
        }

        public List<Profesor> GetAllProfesors()
        {
            return profesorDAO.GetAllProfesors();
        }

        public void Add(Profesor profesor)
        {
            profesorDAO.AddProfesor(profesor);
        }

        public void Delete(int profesorID)
        {
            profesorDAO.RemoveProfesor(profesorID);
        }

        public void Edit(Profesor profesor)
        {
            profesorDAO.ViewUpdateProfesor(profesor);
        }

        public Profesor GetProfById(int id)
        {
            return profesorDAO.GetProfByID(id);
        }

        public Profesor GetProfByName(string ime)
        {
            return profesorDAO.GetProfByName(ime);
        }

        public void Subscribe(IObserver observer)
        {
            profesorDAO.profesorSubject.Subsciribe(observer);
        }
    }
}
