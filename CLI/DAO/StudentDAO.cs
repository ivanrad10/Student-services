using CLI.Observer;
using CLI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.DAO
{
    public class StudentDAO
    {
        private readonly List<Student> students;
        private readonly Storage<Student> storage;
        public SubjectObs studentSubject;

        public StudentDAO()
        {
            storage = new Storage<Student>("students.txt");
            students = storage.Load();
            studentSubject = new SubjectObs();
        }

        public int generateId()
        {
            if(students.Count == 0) { return 0; }
            return students[^1].ID + 1;
        }
        public Student addStudnet (Student student)
        {
            student.ID = generateId();
            students.Add(student);
            storage.Save(students);
            studentSubject.NotifyObserver();
            return student;
        }
        public Student? updateStudent(Student student)
        {
            System.Console.WriteLine("Unesite novo ime: ");
            string nesto = System.Console.ReadLine();

            student.FirstName = nesto;

            System.Console.WriteLine("Unesite novo prezime: ");
            string nesto1 = System.Console.ReadLine();

            student.LastName = nesto1;

            System.Console.WriteLine("Unesite novi datum rodjenja: ");
            string nesto3 = System.Console.ReadLine();

            student.BirthDate = DateOnly.Parse(nesto3);

            System.Console.WriteLine("Unesite novu adresu: ");
            string nesto4 = System.Console.ReadLine();

            student.Adress = nesto4;

            System.Console.WriteLine("Unesite novi broj telefona: ");
            string nesto5 = System.Console.ReadLine();

            student.PhoneNumber = nesto5;

            System.Console.WriteLine("Unesite novi email: ");
            string nesto6 = System.Console.ReadLine();

            student.Email = nesto6;

            System.Console.WriteLine("Unesite novu godinu sudiranja: ");
            string nesto7 = System.Console.ReadLine();

            student.YearOfStudy = int.Parse(nesto7);
            
            storage.Save(students);
            studentSubject.NotifyObserver();
            return student;
        }

        public Student? ViewStudentUpdate(Student noviStudent)
        {
            Student? stari = getStudentByID(noviStudent.ID);
            if (stari == null)
            {
                return null;
            }

            stari.FirstName = noviStudent.FirstName;
            stari.LastName = noviStudent.LastName;
            stari.Adress = noviStudent.Adress;
            stari.PhoneNumber = noviStudent.PhoneNumber;
            stari.BirthDate = noviStudent.BirthDate;
            stari.Email = noviStudent.Email;
            stari.YearOfStudy = noviStudent.YearOfStudy;

            storage.Save(students);
            studentSubject.NotifyObserver();
            return stari;
        }
        public Student? getStudentByID(int id)
        {
            return students.Find(s => s.ID == id);
        }
        
        public Student? removeStudent(int id)
        {
            Student? student = getStudentByID(id);
            if(id == null) { return null; }

            students.Remove(student);
            storage.Save(students);

            studentSubject.NotifyObserver();
            return student;
        }

        public List<Student> getAllStudents()
        {
            return students;
        }

    }
}
