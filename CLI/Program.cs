using CLI.Model;
using CLI.Console;
class Program
{
    static void Main(string[] args)
    {
        Profesor profesor_1 = new Profesor();
        Student student_1 = new Student();
        Subject predmet_1 = new Subject();


        RunMenu();
    }

    public static void RunMenu()
    {
        while (true)
        {
            ShowMenu();
            
            HandleMenuInput();
        }
    }

    private static void HandleMenuInput()
    {
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Console.WriteLine("\nUsli ste kao profesor.\n");

                ProfesorConsole.HandleMenu();

                break;
            case "2":
                Console.WriteLine("\nUsli ste kao student.\n");

                StudentConsole.HandleMenu();

                break;
            case "3":
                Console.WriteLine("\nIzabrali ste opciju predmet.\n");

                PredmetConsole.HandleMenu();

                break;
            case "4":

                 Console.WriteLine("\nIzabrali ste opciju katedra.\n");
                 KatedraConsole.HandleMenu();

                break;
            case "5":
                Console.WriteLine("\nIzabrali ste opciju dodavanja predmeta studentu.\n");

                StudentPredmetConsole.StudentExample();

                break;

            case "6":
                Console.WriteLine("\nIzabrali ste opciju dodavanja profesora na katedru.\n");

                KatedraProfesorConsole.KatProfList();
                break;

            case "0":
                System.Environment.Exit(0);
                break;
            

            default:
                System.Console.WriteLine("Uneli ste neprihvatljivu vrednost!\n");
                System.Console.WriteLine("Unesite broj od 0 do 6:");
                HandleMenuInput();

                break;
        }
    }


    private static void ShowMenu()
    {
        Console.WriteLine("\nIzaberite opciju:");
        Console.WriteLine("1: Profesor");
        Console.WriteLine("2: Student");
        Console.WriteLine("3: Predmet");
        Console.WriteLine("4: Katedra");
        Console.WriteLine("5: Dodajte studenta na predmet");
        Console.WriteLine("6: Dodajte profesora na katedru");
        Console.WriteLine("0: Kraj programa\n");
    }
}