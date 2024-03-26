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
    public class KatedraProfesorConsole
    {
        public static void ShowuMenu()
        {
            System.Console.WriteLine("\nIzaberite opciju za katedre: ");
            System.Console.WriteLine("1: Dodajte profesora na katedru");
            System.Console.WriteLine("2: Izbrisite profesora sa katedre");
            System.Console.WriteLine("3: Nazad");
            System.Console.WriteLine("0: Kraj programa\n");
        }
        public static void KatProfList()
        {
            ShowuMenu();

            KatedraDAO katedraDAO = new KatedraDAO();
            ProfesorDAO profesorDAO = new ProfesorDAO();
            KatedraProfesorDAO katprofDAO = new KatedraProfesorDAO();

            List<Katedra> katedre = katedraDAO.GetAllKatedra();
            List<Profesor> profesori = profesorDAO.GetAllProfesors();

            string n = System.Console.ReadLine();

            switch (n)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    //dodavanje profesora

                    System.Console.WriteLine("\nUnesite ID katedre za koju zelite da dodate profesora:\n");
                    string idkat = System.Console.ReadLine();
                    System.Console.WriteLine("\nUnesite ID profesora kojeg zelite da dodate na katedru broj" + idkat + ":\n");
                    string idprof = System.Console.ReadLine();

                    KatedraProfesor katedraProfesor = new KatedraProfesor(int.Parse(idkat), int.Parse(idprof));
                    katprofDAO.DodajKatProf(katedraProfesor);

                    
                    foreach (KatedraProfesor kp in katprofDAO.katprofLista)
                    {
                        Katedra kat1 = katedre.Find(s => s.ID == kp.KatedraID);
                        Profesor prof1 = profesori.Find(s => s.ID == kp.ProfesorID);

                        kat1.Profesori.Add(prof1);
                    }

                    KatProfList();
                    break;

                case "2":
                    //brisanje profesora

                    System.Console.WriteLine("\nUnesite ID katedre sa koje zelite da obrisete profesora:\n");
                    string idkat1 = System.Console.ReadLine();
                    System.Console.WriteLine("\nUnesite ID profesora kojeg zelite da obrisete sa katedre broj" + idkat1 + ":\n");
                    string idprof1 = System.Console.ReadLine();

                    katprofDAO.IzbrisiKatProf(int.Parse(idkat1), int.Parse(idprof1));

                    foreach(KatedraProfesor kp in katprofDAO.katprofLista)
                    {
                        Katedra kat1 = katedre.Find(s=>s.ID == kp.KatedraID);
                        Profesor prof1 = profesori.Find(s=>s.Equals(kp.ProfesorID));

                        kat1.Profesori.Remove(prof1);
                    }

                    KatProfList();
                    break;
                case "3":
                    break;
                default:
                    System.Console.WriteLine("Uneli ste neprihvatljivu vrednost!\n");
                    System.Console.WriteLine("Unesite broj od 0 do 3:");
                    KatProfList();
                    break;
            }

        }
    }
}
