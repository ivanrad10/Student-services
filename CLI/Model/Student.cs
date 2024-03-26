using CLI.Model;
using System.Text;
using System.Xml.Linq;


public class Student : ISerializable
{
    enum Status
    {
        B,  //budzet
        S   //samofinansiranje
    }
    public string LastName { get; set; }
    public string FirstName { get; set;}
    public DateOnly BirthDate { get; set;}
    public string Adress { get; set;}
    public string PhoneNumber { get; set;}  
    public string Email { get; set;}
    public int ID { get; set;}
    public int YearOfStudy { get; set;}
    public double AvgGrade { get; set;}
    public List <Subject> PassedExams { get; set;}
    public List <Subject> FailedExams { get;set; }
    public Student()
    {
        PassedExams = new List<Subject>();
        FailedExams = new List<Subject>();
    }

    public Student(int id, string ime, string prezime)
    {
        ID = id;
        FirstName = ime;
        LastName = prezime;
        PassedExams = new List<Subject>();
        FailedExams = new List<Subject>();
    }

    public Student(string firstName, string lastName, DateOnly birthDate, string adress, string phoneNumber, string email, int yearsOfStudy, double avgGrade)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Adress = adress;
        PhoneNumber = phoneNumber;
        Email = email;
        YearOfStudy = yearsOfStudy;
        AvgGrade = avgGrade;
        PassedExams = new List<Subject>();
        FailedExams = new List<Subject>();
    }

    public Student(string firstName, string lastName, DateOnly birthDate, string adress, string phoneNumber, string email, int yearsOfStudy)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Adress = adress;
        PhoneNumber = phoneNumber;
        Email = email;
        YearOfStudy = yearsOfStudy;
        PassedExams = new List<Subject>();
        FailedExams = new List<Subject>();
    }

    public Student(int id,string firstName, string lastName, DateOnly birthDate, string adress, string phoneNumber, string email, int yearsOfStudy)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Adress = adress;
        PhoneNumber = phoneNumber;
        Email = email;
        YearOfStudy = yearsOfStudy;
        PassedExams = new List<Subject>();
        FailedExams = new List<Subject>();
    }
    public string[] ToCSV()
    {
        string[] csvValues =
        {
            ID.ToString(),
            LastName,
            FirstName,
            BirthDate.ToString(),
            Adress,
            PhoneNumber,
            Email,
            YearOfStudy.ToString(),
            AvgGrade.ToString()
        };
        return csvValues;
    }

    public void FromCSV(string[] Values)
    {
        ID = int.Parse(Values[0]);
        LastName = Values[1];   
        FirstName = Values[2];
        BirthDate = DateOnly.Parse(Values[3]);
        Adress = Values[4];
        PhoneNumber = Values[5];
        Email = Values[6];
        YearOfStudy = int.Parse(Values[7]);
        AvgGrade = double.Parse(Values[8]);
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Ime: {FirstName}, ");
        sb.Append($"Prezime: {LastName}, ");
        sb.Append($"Godina studiranja: {YearOfStudy} ");

        //fale metode za ispis polozenih i nepolozenih predmeta, bice kad se napravi klasa subjects
        return sb.ToString();
    }

}