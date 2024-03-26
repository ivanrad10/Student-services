using CLI.DAO;
using CLI.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLI.Model;
namespace CLI.Console
{
    public class StudentConsole
    {
        StudentPredmetDAO studentPredmetDAO = new StudentPredmetDAO();

        private static void ShowMenu()
        {
            System.Console.WriteLine("\nChoose an option: ");
            System.Console.WriteLine("1: Prikazi sve studente");
            System.Console.WriteLine("2: Prikazi detalje pojedinacnog studenta");
            System.Console.WriteLine("3: Dodaj studenta");
            System.Console.WriteLine("4: Obrisi studenta");
            System.Console.WriteLine("5: Azuriraj studenta");
            System.Console.WriteLine("6: Nazad");
            System.Console.WriteLine("0: Zatvori");
        }

        public static void HandleMenu()
        {
            StudentDAO studentDAO = new StudentDAO();

            ShowMenu();

            string n = System.Console.ReadLine();

            switch (n)
            {
                case "1":

                    IspisiStudente(studentDAO.getAllStudents());
                    HandleMenu();
                    break;

                case "2":
                    //detaljno student
                    System.Console.WriteLine("Unesite ID zeljenog studenta: ");
                    
                    StudentDAO studentDAO1 = new StudentDAO();

                    int id;
                    do
                    {
                        id = int.Parse(System.Console.ReadLine());

                        if (studentDAO1.getStudentByID(id) == null)
                        {
                            System.Console.WriteLine("Uneli ste nepostojeci ID!");
                        }
                    } while (studentDAO1.getStudentByID(id) == null);

                    DetaljnoIspisivanjeStudenta(id);
                    HandleMenu();
                    break;

                case "3":

                    //impementacija dodavanja novog studenta

                    System.Console.WriteLine("\nUnesite ime studenta: \n");
                    string ime = System.Console.ReadLine() ?? string.Empty;


                    System.Console.WriteLine("\nUnesite prezime studenta: \n");
                    string prezime = System.Console.ReadLine() ?? string.Empty;

                    System.Console.WriteLine("\nUnesite datum rodjenja studenta: \n");
                    DateOnly datum = DateOnly.Parse(System.Console.ReadLine());

                    System.Console.WriteLine("\nUnesite adresu studenta: \n");          ////treba uvezati sa objekom adresa, implemetnirano kod profesora, bice zamnejeno ovde
                    string adresa = System.Console.ReadLine() ?? string.Empty;

                    System.Console.WriteLine("\nUnesite broj telefona studenta: \n");
                    string brTel = System.Console.ReadLine() ?? string.Empty;

                    System.Console.WriteLine("\nUnesite email studenta: \n");
                    string email = System.Console.ReadLine() ?? string.Empty;

                    System.Console.WriteLine("\nUnesite godinu studiranja studenta: \n");
                    int godStudija = int.Parse(System.Console.ReadLine());

                    System.Console.WriteLine("\nUnesite prosecnu ocenu studenta: \n");      ////treba uvezati sa ocenama
                    int prosecnaOc = int.Parse(System.Console.ReadLine());

                    Student novi = new Student(ime, prezime, datum, adresa, brTel, email, godStudija, prosecnaOc);

                    studentDAO.addStudnet(novi);

                    System.Console.WriteLine("\nDodali ste novog studenta!\n");
                    HandleMenu();
                    break;

                case "4":

                    //implementacija brisanja studenta

                    System.Console.WriteLine("\nUnesite ID studenta kog zelite da obrisete: \n");
                    int id1 = int.Parse(System.Console.ReadLine());

                    studentDAO.removeStudent(id1);

                    System.Console.WriteLine("\nObrisali ste studenta!\n");
                    HandleMenu();
                    break;

                case "5":
                    //azuriranje studenta

                    StudentDAO studentDAO2 = new StudentDAO();
                    System.Console.WriteLine("Unesite ID studenta kog zelite da azurirate: ");

                    int id2;
                    do
                    {
                        id2 = int.Parse(System.Console.ReadLine());

                        if (studentDAO2.getStudentByID(id2) == null)
                        {
                            System.Console.WriteLine("Uneli ste nepostojeci ID!");
                        }
                    } while (studentDAO2.getStudentByID(id2) == null);

                    studentDAO2.updateStudent(studentDAO2.getStudentByID(id2)); 
                    HandleMenu();
                    break;

                case "6":
                    System.Console.WriteLine("Vratili ste se nazad!\n");
                    break;

                case "0":
                    System.Console.WriteLine("Izasli ste\n");
                    System.Environment.Exit(0);
                    break;

                default:
                    System.Console.WriteLine("Uneli ste neprihvatljivu vrednost!\n");
                    System.Console.WriteLine("Unesite broj izmedju 0 i 4:\n");

                    HandleMenu();
                    break;
            }

        }
        private static void IspisiStudente(List<Student> studenti)
        {
            System.Console.WriteLine("Studenti: ");
            foreach (Student s in studenti)
            {
                System.Console.WriteLine(s);
            }
        }

        private static void DetaljnoIspisivanjeStudenta(int id)
        {
            System.Console.WriteLine("Detaljan prikaz studenta sa ID-jem " + id + " :");

            Student student = new Student();
            Subject subject = new Subject();

            StudentDAO studentDAO = new StudentDAO();
            PredmetDAO predmetDAO = new PredmetDAO();
            StudentPredmetDAO studentPredmetDAO = new StudentPredmetDAO();
            student = studentDAO.getStudentByID(id);

            System.Console.WriteLine("\nID: " + student.ID);
            System.Console.WriteLine("\nIme: " + student.LastName);
            System.Console.WriteLine("\nPrezime: " + student.FirstName);
            System.Console.WriteLine("\nDatum rodjenja: " + student.BirthDate);
            System.Console.WriteLine("\nAdresa: " + student.Adress);
            System.Console.WriteLine("\nBroj telefona: " + student.PhoneNumber);
            System.Console.WriteLine("\nEmail: " + student.Email);
            System.Console.WriteLine("\nGodina studiranja: " + student.YearOfStudy);

            double brojOcena = 0;
            double sumaOcena = 0;
            double prosek = 0;
            foreach (var studentpredmet in studentPredmetDAO.studentPredmet)
            {
                if (studentpredmet.StudentId == id)
                {
                    if (studentpredmet.polozio == "Polozeno")
                    {
                        sumaOcena += studentpredmet.ocena;
                        brojOcena++;
                    }   
                }
            }

            prosek = sumaOcena / brojOcena;
            System.Console.WriteLine("\nProsecna ocena: " + prosek);

            student.AvgGrade = prosek;

            System.Console.WriteLine("\nPolozeni predmeti: " );


            foreach (var studentpredmet in studentPredmetDAO.studentPredmet)
            {
                if(id == studentpredmet.StudentId)
                {
                    if (studentpredmet.polozio == "Polozeno")
                    {
                        subject = predmetDAO.GetSubjByID(studentpredmet.SubjectId);

                        System.Console.WriteLine(subject.Name);
                    }
                }   
            }

            System.Console.WriteLine("\nNepolozeni predmeti: ");

            foreach (var studentpredmet in studentPredmetDAO.studentPredmet)
            {
                if (id == studentpredmet.StudentId)
                {
                    if (studentpredmet.polozio == "Nepolozeno")
                    {
                        subject = predmetDAO.GetSubjByID(studentpredmet.SubjectId);

                        System.Console.WriteLine(subject.Name);
                    }
                }
            }
        }
    }
}
