using CLI.DAO;
using CLI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Console
{
    internal class KatedraConsole
    {
        private static void ShowMenu()
        {
            System.Console.WriteLine("\nIzaberite opciju: ");
            System.Console.WriteLine("1: Prikazi sve katedre");
            System.Console.WriteLine("2: Dodaj katedru");
            System.Console.WriteLine("3: Obrisi katedru");
            System.Console.WriteLine("4: Izmeni informacije o katedri");
            System.Console.WriteLine("5: Detalji o katedri");
            System.Console.WriteLine("6: Dodavanje i brisanje profesora na katedrama");
            System.Console.WriteLine("7: Nazad");
            System.Console.WriteLine("0: Close\n");
        }

        public static void HandleMenu()
        {
            KatedraDAO katedreDAO = new KatedraDAO();
            ProfesorDAO profesorDAO = new ProfesorDAO();
            KatedraProfesorDAO katprofDAO = new KatedraProfesorDAO();
            ShowMenu();

            string n = System.Console.ReadLine();

            switch (n)
            {
                case "0":
                    System.Environment.Exit(0);
                    break;
                case "1":
                    //lista katedri
                    System.Console.WriteLine("\nLista katedri: ");
                    string kolone = $"ID {"",6} | Ime {"",21} | Sef {"",21} |";
                    System.Console.WriteLine(kolone);
                    List<Katedra> katedre = katedreDAO.GetAllKatedra();
                    foreach (Katedra k in katedre)
                    {
                        System.Console.WriteLine($"ID: {k.ID,5} | IME: {k.Ime,20} | SEF: {k.Sef,20} |");
                    }
                    HandleMenu();
                    break;
                case "2":
                    //dodaj katedru
                    System.Console.WriteLine("Unesite ime: ");
                    string ime = System.Console.ReadLine();
                    System.Console.WriteLine("Unesite sefa: ");
                    string sef = System.Console.ReadLine();
                    Katedra katedra = new Katedra(ime, sef);

                    katedreDAO.AddKatedra(katedra);
                    System.Console.WriteLine("\nKatedra dodata.");
                    HandleMenu();
                    break;
                case "3":
                    //delete
                    System.Console.WriteLine("Unesite ID katedre: ");
                    string id1 = System.Console.ReadLine();
                    Katedra izbrisane = katedreDAO.RemoveKatedra(int.Parse(id1));
                    if (izbrisane is null)
                    {
                        System.Console.WriteLine("Katedra sa prosledjenim ID-jem ne postoji.\n");
                        break;
                    }
                    System.Console.WriteLine("\nKatedra obrisana.\n");
                    HandleMenu();
                    break;
                case "4":
                    //izmene katedre
                    System.Console.WriteLine("Unesite ID katedre koju zelite da izmenite: ");
                    string id = System.Console.ReadLine();

                    KatedraDAO katedraDAO1 = new KatedraDAO();
                    katedraDAO1.UpdateKatedra(katedraDAO1.GetKatByID(int.Parse(id)));

                    System.Console.WriteLine("\nKatedra izmenjena.\n");
                    HandleMenu();
                    break;
                case "5":
                    //detalji katedre
                    System.Console.WriteLine("\nUnesite ID katedre za koju zelite detalje: ");
                    string id3 = System.Console.ReadLine();
                    Katedra katedra1 = katedreDAO.GetKatByID(int.Parse(id3));
                    System.Console.WriteLine(katedra1.ToString());

                    List<KatedraProfesor> listaKatProf = katprofDAO.GetAllKatProfList();

                    //ispis liste profesora iz katedraprofesor.txt preko katprofDAO
                    foreach (KatedraProfesor kp1 in listaKatProf)
                    {
                        if (kp1.KatedraID == int.Parse(id3))
                        {
                            Profesor p1 = profesorDAO.GetProfByID(kp1.ProfesorID);
                            System.Console.WriteLine(p1.ID + " | " + p1.Ime + " | " + p1.Prezime);
                        }
                    }

                    HandleMenu();
                    break;
                case "6":
                    KatedraProfesorConsole.KatProfList();
                    break;
                case "7":
                    break;
                default:
                    System.Console.WriteLine("Uneli ste neprihvatljivu vrednost!\n");
                    System.Console.WriteLine("Unesite broj izmedju 0 i 6:");
                    HandleMenu();
                    break;
            }
        }
    }
}
