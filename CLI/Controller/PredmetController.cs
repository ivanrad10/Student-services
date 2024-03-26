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
    public class PredmetController
    {
        private readonly PredmetDAO predmetDAO;

        public PredmetController()
        {
            predmetDAO = new PredmetDAO();
        }

        public List<Subject> GetAllSubjects()
        {
            return predmetDAO.GetAllSubjects();
        }

        public Subject GetPredById(int id)
        {
            return predmetDAO.GetSubjByID(id);
        }

        public Subject GetPredByName(string name)
        {
            return predmetDAO.GetSubjByName(name);
        }
        public void Add(Subject s)
        {
            predmetDAO.AddSbujects(s);
        }

        public void Delete(int predmetID)
        {
            predmetDAO.RemoveSubject(predmetID);
        }

        public void Edit(Subject s)
        {
            predmetDAO.ViewUpdatePredmet(s);
        }

        public void Subscribe(IObserver observer)
        {
            predmetDAO.predmetSubject.Subsciribe(observer);
        }
    }
}
