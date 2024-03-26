using CLI.DAO;
using CLI.Model;
using CLI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Console
{
    public class StudentPredmetConsole
    {

            public static List<Student> StudentExample()
            {

                System.Console.WriteLine("1. Student polozio predmet");
                System.Console.WriteLine("2. Student pao predmet");
                int n = int.Parse(System.Console.ReadLine());

                StudentDAO studentDAO = new StudentDAO();
                PredmetDAO predmetDAO = new PredmetDAO();

                List<Student> studentPolozeni = studentDAO.getAllStudents();
                List<Subject> predmetPolozeni = predmetDAO.GetAllSubjects();

                System.Console.WriteLine("Unesite id studenta kog zelite da uparite");
                int idStudenta = int.Parse(System.Console.ReadLine());

                System.Console.WriteLine("Unesite id predmeta kog zelite da uparite");
                int idPredmeta = int.Parse(System.Console.ReadLine());

                int ocena;


                if (n == 1)
                {
                    System.Console.WriteLine("Unesite ocenu kojom je student polozio predmet: ");
                    ocena = int.Parse(System.Console.ReadLine());
                }
                else
                {
                    ocena = 5;
                }

                StudentPredmet studentPredmet1 = new StudentPredmet(idStudenta, idPredmeta, "", ocena);

                if (n == 1)
                {
                    studentPredmet1.polozio = "Polozeno";
                }
                else
                {
                    studentPredmet1.polozio = "Nepolozeno";
                }
                StudentPredmetDAO studpredDAO = new StudentPredmetDAO();        //pravi problem kad je prazan fajl
                studpredDAO.addStudnetPredmet(studentPredmet1);
              
                foreach (StudentPredmet studentPredmet in studpredDAO.studentPredmet)
                {
                    Student student = studentPolozeni.Find(s => s.ID == studentPredmet.StudentId);
                    Subject subject = predmetPolozeni.Find(s => s.ID == studentPredmet.SubjectId);

                    if (n == 1)
                    {
                        student.PassedExams.Add(subject);
                        subject.StudentsThatPassed.Add(student);
                    }
                    else
                    {
                        student.FailedExams.Add(subject);
                        subject.StudentsThatFailed.Add(student);
                    }

                }

                return studentPolozeni;
            }
    }
}
