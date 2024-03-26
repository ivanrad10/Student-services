using CLI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLI.Model;
using CLI.DAO;
using CLI.Observer;

namespace CLI.DAO
{
    public class StudentPredmetDAO
    {
        public readonly List<StudentPredmet> studentPredmet;
        private readonly Storage<StudentPredmet> storage;
        public SubjectObs studentPredmetSubject;


        public StudentPredmetDAO()
        {
            storage = new Storage<StudentPredmet>("studentSubject.txt");
            studentPredmet = storage.Load();
            studentPredmetSubject = new SubjectObs();
        }

        public StudentPredmet addStudnetPredmet(StudentPredmet sp)
        {
            if(studentPredmet.Any(s=> s.StudentId == sp.StudentId && s.SubjectId == sp.SubjectId)) 
            {
                System.Console.WriteLine("Zadati student je vec dodat za zadati predmet ");
                return null;
            }
            studentPredmet.Add(sp);
            storage.Save(studentPredmet);
            studentPredmetSubject.NotifyObserver();
            return sp;
        }

        public StudentPredmet? removeStudentPredmet(int idStudenta, int idPredmeta)
        {
            StudentPredmet? sp = getStudentPredmetByID(idStudenta, idPredmeta);
            if (idStudenta == null || idPredmeta == null) { return null; }

            studentPredmet.Remove(sp);
            storage.Save(studentPredmet);
            studentPredmetSubject.NotifyObserver();
            return sp;
        }

        public StudentPredmet? getStudentPredmetByID(int idStudenta, int idPredmeta)
        {
            return studentPredmet.Find(s => s.StudentId == idStudenta &&  s.SubjectId == idPredmeta);
        }

        public List<StudentPredmet>? getStudentPredmetByStudentID(int idStudenta)
        {
            List<StudentPredmet> list = getAll();
            List<StudentPredmet> retVal = new List<StudentPredmet>();

            foreach (StudentPredmet sp in list)
            {
                if(idStudenta == sp.StudentId)
                {
                    retVal.Add(sp);
                }
            }

            return retVal;
        }

        public List<StudentPredmet> getAll()
        {
            return studentPredmet;
        }
    }
}
