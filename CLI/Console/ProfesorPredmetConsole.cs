using CLI.DAO;
using CLI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Console
{
    internal class ProfesorPredmetConsole
    {
        public static void ShowuMenu()
        {
            System.Console.WriteLine("\nIzaberite opciju za profesora: ");
            System.Console.WriteLine("1: Dodajte predmet profesoru");
            System.Console.WriteLine("2: Izbrisite predmet kod profesora");
            System.Console.WriteLine("3: Nazad");
            System.Console.WriteLine("0: Kraj programa\n");
        }
        public static void ProfPredList()
        {
            ShowuMenu();

            ProfesorDAO profesorDAO = new ProfesorDAO();
            PredmetDAO predmetDAO = new PredmetDAO();
            ProfesorPredmetDAO profpredDAO = new ProfesorPredmetDAO();

            List<Profesor> profesori = profesorDAO.GetAllProfesors();
            List<Subject> predmeti = predmetDAO.GetAllSubjects();

            string n = System.Console.ReadLine();

            switch (n)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    //dodavanje predmeta

                    System.Console.WriteLine("\nUnesite ID profesora kojem zelite da dodelite predmet:\n");
                    string idprof = System.Console.ReadLine();
                    System.Console.WriteLine("\nUnesite ID predmeta koji zelite da dodelite profesoru " + idprof + " :\n");
                    string idpred = System.Console.ReadLine();

                    ProfesorPredmet profesorPredmet = new ProfesorPredmet(int.Parse(idprof), int.Parse(idpred));
                    profpredDAO.DodajProfPred(profesorPredmet);


                    foreach (ProfesorPredmet pp in profpredDAO.profpedLista)
                    {
                        Profesor prof1 = profesori.Find(s => s.ID == pp.ProfesorID);
                        Subject pred1 = predmeti.Find(s => s.ID == pp.PredmetID);

                        prof1.Predmeti.Add(pred1);
                        pred1.Profesor = prof1;
                    }

                    ProfPredList();
                    break;

                case "2":
                    //brisanje predmeta
                    /*
                    System.Console.WriteLine("\nUnesite ID katedre sa koje zelite da obrisete profesora:\n");
                    string idkat1 = System.Console.ReadLine();
                    System.Console.WriteLine("\nUnesite ID profesora kojeg zelite da obrisete sa katedre broj" + idkat1 + ":\n");
                    string idprof1 = System.Console.ReadLine();

                    profpredDAO.IzbrisiKatProf(int.Parse(idkat1), int.Parse(idprof1));

                    foreach (KatedraProfesor kp in profpredDAO.katprofLista)
                    {
                        Katedra kat1 = profesori.Find(s => s.ID == kp.KatedraID);
                        Profesor prof1 = profesori.Find(s => s.Equals(kp.ProfesorID));

                        kat1.Profesori.Remove(prof1);
                    }
                    */
                    ProfPredList();
                    break;
                case "3":
                    break;
                default:
                    System.Console.WriteLine("Uneli ste neprihvatljivu vrednost!\n");
                    System.Console.WriteLine("Unesite broj izmedju 0 i 3:");
                    ProfPredList();
                    break;
            }

        }
    }
}
