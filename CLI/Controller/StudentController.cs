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
    public class StudentController
    {
        private readonly StudentDAO studentDAO;

        public StudentController ()
        {
            studentDAO = new StudentDAO ();
        }

        public List<Student> getAllStudents()
        {
            return studentDAO.getAllStudents();
        }

        public void Add(Student student)
        {

            studentDAO.addStudnet(student);
        }

        public void Delete (int studentID)
        {
            studentDAO.removeStudent(studentID);
        }

        public void Edit(Student student)
        {
            studentDAO.ViewStudentUpdate(student); 
        }

        public Student GetStudById(int id)
        {
            return studentDAO.getStudentByID(id);
        }
        public void  Subscribe(IObserver observer)
        {
            studentDAO.studentSubject.Subsciribe(observer);
        }
    }
}
