using CLI.DAO;
using CLI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Console
{
    public  class ProfesorConsole
    {
        private static void ShowMenu()
        {
            System.Console.WriteLine("\nIzaberite opciju: ");
            System.Console.WriteLine("1: Prikazi sve profesore");
            System.Console.WriteLine("2: Dodaj profesora");
            System.Console.WriteLine("3: Obrisi profesora");
            System.Console.WriteLine("4: Izmeni informacije o profesoru");
            System.Console.WriteLine("5: Detalji o profesoru");
            System.Console.WriteLine("6: Dodelite ili izbrisite predmet profesoru");
            System.Console.WriteLine("7: Nazad");
            System.Console.WriteLine("0: Close\n");
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
                case "0":
                    System.Environment.Exit(0);
                    break;
                case "1":
                    //lista profesora

                    System.Console.WriteLine("\nLista profesora: ");
                    string kolone = $"ID {"",6} | Ime {"",21} | Prezime {"",21} |";
                    System.Console.WriteLine(kolone);
                    List<Profesor> profesori = profesorDAO.GetAllProfesors();
                    foreach(Profesor p in profesori)
                    {
                        System.Console.WriteLine($"ID: {p.ID,5} | IME: {p.Ime, 20} | PREZIME: {p.Prezime,20} | BROJ TELEFONA: {p.BrojTelefona,10} |");
                    }
                    HandleMenu();
                    break;
                case "2":
                    //dodavanje

                    System.Console.WriteLine("Unesite ime: ");
                    string ime1 = System.Console.ReadLine();

                    System.Console.WriteLine("Unesite prezime: ");
                    string prezime1 = System.Console.ReadLine();

                    System.Console.WriteLine("Unesite datum rodjenja (01/01/1900): ");
                    string dr1 = System.Console.ReadLine();

                    System.Console.WriteLine("Unesite adresu (Pravilo unosa: ulica, broj, grad, drzava): ");
                    string adresa1 = System.Console.ReadLine();
                    Adresa adresa3 = new Adresa();
                    adresa3.Parse(adresa1);

                    System.Console.WriteLine("Unesite broj telefona: ");
                    string br1 = System.Console.ReadLine();

                    System.Console.WriteLine("Unesite email: ");
                    string email1 = System.Console.ReadLine();

                    System.Console.WriteLine("Unesite zvanje: ");
                    string zvanje1 = System.Console.ReadLine();

                    System.Console.WriteLine("Unesite broj godina staza: ");
                    string staz1 = System.Console.ReadLine();

                    System.Console.WriteLine("Unesite broj licne karte: ");
                    string licna1 = System.Console.ReadLine();

                    Profesor profesor = new Profesor(ime1, prezime1, DateOnly.Parse(dr1), adresa3, br1, email1, zvanje1, staz1, licna1);

                    profesorDAO.AddProfesor(profesor);
                    System.Console.WriteLine("Profesor dodat.");
                    HandleMenu();
                    break;
                case "3":
                    //delete
                    System.Console.WriteLine("Unesite ID profesora: ");
                    string id1 = System.Console.ReadLine();
                    Profesor izbrisani = profesorDAO.RemoveProfesor(int.Parse(id1));
                    if(izbrisani is null)
                    {
                        System.Console.WriteLine("Profesor sa prosledjenim ID-jem ne postoji.\n");
                        break;
                    }
                    System.Console.WriteLine("\nProfesor obrisan.\n");
                    HandleMenu();
                    break;
                case "4":
                    //update
                    System.Console.WriteLine("Unesite ID profesora kojeg zelite da izmenite: ");
                    string id = System.Console.ReadLine();

                    ProfesorDAO profesorDAO1 = new ProfesorDAO();
                    profesorDAO1.UpdateProfesor(profesorDAO1.GetProfByID(int.Parse(id)));

                    System.Console.WriteLine("\nProfesor izmenjen.\n");
                    HandleMenu();
                    break;
                case "5":
                    //detaljii
                    System.Console.WriteLine("Unesite ID profesora za kojeg zelite detalje: ");
                    string id3 = System.Console.ReadLine();
                    Profesor profesor1 = profesorDAO.GetProfByID(int.Parse(id3));
                    System.Console.WriteLine(profesor1.ToString());
                    
                    List<ProfesorPredmet> listaProfPred = profpredDAO.GetAllProfPredList();

                    foreach(ProfesorPredmet pp in listaProfPred)
                    {
                        if(pp.ProfesorID == int.Parse(id3))
                        {
                            Subject p = predmetDAO.GetSubjByID(pp.PredmetID);
                            System.Console.WriteLine(p.ID + " | " + p.Name);
                        }
                    }

                    break;
                case "6":
                    ProfesorPredmetConsole.ProfPredList();
                    break;
                case "7":
                    break;
                default:
                    System.Console.WriteLine("Uneli ste neprihvatljivu vrednost!\n");
                    System.Console.WriteLine("Unesite broj od 0 do 6:");
                    HandleMenu();
                    break;

            }
        }
    }
}
