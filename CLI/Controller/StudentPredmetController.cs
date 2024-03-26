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
    public class StudentPredmetController
    {
        private readonly StudentPredmetDAO studentPredmetDAO;

        public StudentPredmetController()
        {
            studentPredmetDAO = new StudentPredmetDAO();
        }

        public List<StudentPredmet> getAllStudentPredmet()
        {
            return studentPredmetDAO.getAll();
        }

        public void Add(StudentPredmet sp)
        {

            studentPredmetDAO.addStudnetPredmet(sp);
        }

        public void Delete(int id, int id1)
        {
            studentPredmetDAO.removeStudentPredmet(id, id1);
        }

        public StudentPredmet? getStudentPredmetByID(int idStudenta, int idPredmeta)
        {
            return studentPredmetDAO.getStudentPredmetByID(idStudenta, idPredmeta);
        }

        public List<StudentPredmet>? getStudentPredmetByStudentID(int idStudenta)
        {
            return studentPredmetDAO.getStudentPredmetByStudentID(idStudenta);
        }
        public void Subscribe(IObserver observer)
        {
            studentPredmetDAO.studentPredmetSubject.Subsciribe(observer);
        }
    }
}
