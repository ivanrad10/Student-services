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
    public class PredmetConsole
    {
        private static void ShowMenu()
        {
            System.Console.WriteLine("\nChoose an option: ");
            System.Console.WriteLine("1: Prikazi sve predmete");
            System.Console.WriteLine("2: Dodaj predmet");
            System.Console.WriteLine("3: Obrisi predmet");
            System.Console.WriteLine("4: Azuriraj predmet");
            System.Console.WriteLine("5: Dodeli ili obrisi predmet profesoru");
            System.Console.WriteLine("6: Nazad");
            System.Console.WriteLine("0: Zatvori");
        }

        public static void HandleMenu()
        {
            ProfesorDAO profesorDAO = new ProfesorDAO();
            PredmetDAO predmetDAO = new PredmetDAO();
            ProfesorPredmetDAO profpredDAO = new ProfesorPredmetDAO();

            ShowMenu();

            string n = System.Console.ReadLine();


            switch (n)
            {
                case "1":
                    //ispis predmeta

                    List<ProfesorPredmet> listaProfPred = profpredDAO.GetAllProfPredList();
                    List<Subject> listaPredmeta = predmetDAO.GetAllSubjects();

                    foreach (Subject p in listaPredmeta) ///////////////////////////////////ne radi ispis dobro, ispraviti
                    {
                        if (p.Profesor!=null)
                        {
                            foreach (ProfesorPredmet pp in listaProfPred)
                            {
                                Subject pred = predmetDAO.GetSubjByID(pp.PredmetID);
                                Profesor prof = profesorDAO.GetProfByID(pp.ProfesorID);
                                string ime_profe = prof.ID.ToString() + " " + prof.Ime + " " + prof.Prezime;
                                System.Console.WriteLine($"ID: {pred.ID,5} | IME: {pred.Name,10} | PROFESOR: {ime_profe,30} |");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine($"ID: {p.ID,5} | IME: {p.Name,10} | PROFESOR: nema");
                        }
                    }
                        
                    HandleMenu();
                    break;

                case "2":

                    //impementacija dodavanja novog predmeta

                    System.Console.WriteLine("\nUnesite ime predmeta: \n");
                    string ime = System.Console.ReadLine() ?? string.Empty;

                    System.Console.WriteLine("\nUnesite godinu izvodjenja: \n");          
                    int god = int.Parse(System.Console.ReadLine());

                    System.Console.WriteLine("\nUnesite broj ESPB bodova: \n");
                    int espb = int.Parse(System.Console.ReadLine());

                    Subject novi = new Subject(ime, god, espb);

                    predmetDAO.AddSbujects(novi);

                    System.Console.WriteLine("\nDodali ste novi predmet!\n");
                    HandleMenu();
                    break;

                case "3":

                    //implementacija brisanja predmeta

                    System.Console.WriteLine("\nUnesite ID predmeta kog zelite da obrisete: \n");
                    int kodPredmeta = int.Parse(System.Console.ReadLine());

                    predmetDAO.RemoveSubject(kodPredmeta);

                    System.Console.WriteLine("\nObrisali ste predmet!\n");
                    HandleMenu();
                    break;

                case "4":
                    //azuriranje predmeta
                    PredmetDAO predmetDAO1 = new PredmetDAO();
                    System.Console.WriteLine("Unesite sifru predmeta koji zelite da azurirate: ");

                    int id2;
                    do
                    {
                        id2 = int.Parse(System.Console.ReadLine());

                        if (predmetDAO1.GetSubjByID(id2) == null)
                        {
                            System.Console.WriteLine("Uneli ste nepostojecu sifru predmeta!");
                        }
                    } while (predmetDAO1.GetSubjByID(id2) == null);

                    predmetDAO1.UpdateSubject(predmetDAO1.GetSubjByID(id2));

                    HandleMenu();
                    break;

                case "5":
                    ProfesorPredmetConsole.ProfPredList();
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
                    System.Console.WriteLine("Unesite broj izmedju 0 i 5:\n");

                    HandleMenu();
                    break;
            }

        }

        private static void IspisiPredmete(List<Subject> predmeti)
        {
            System.Console.WriteLine("Predmeti: ");
            
            foreach (Subject s in predmeti)
            {
                System.Console.WriteLine(s);
            }
        }
    }
}
