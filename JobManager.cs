using System;
using System.Net;


/* 🔹 Klass: JobManager

Attributer :
Applications | List<JobApplication> - Samling av alla ansökningar

Metoder:
AddJob() – lägger till en ny ansökan
UpdateStatus() – ändrar status på en befintlig ansökan
ShowAll() – visar alla ansökningar
ShowByStatus() – filtrerar med LINQ efter status (VG del)
ShowStatistics() – visar statistik med LINQ (Count, Average, OrderBy, Where) (VG del)
 */

public class JobManager
{
    public List<JobApplication> Applications = new List<JobApplication>();

    public void AddJob()
    {
        JobApplication application = new JobApplication(); //Skapa nytt obejekt

        System.Console.WriteLine("Ange Företaget");
        application.CompanyName = Console.ReadLine()!;

        System.Console.WriteLine("Vilken position?");
        application.PositionTitle = Console.ReadLine()!;

        System.Console.WriteLine("Önskade lönen? Ange endast siffror");
        string Salary = Console.ReadLine()!;
        application.SalaryExpectation = int.Parse(Salary); // Gör om string till int

        application.Status = Status.Applied; 
        Applications.Add(application); 
        System.Console.WriteLine("Ansökan har lagts till");
    }
    public void ShowAll()
    {
        //Ifall inga finns
        if (Applications.Count == 0)
        {
            System.Console.WriteLine("Det finns inga ansökningar Regristerade");
            return;
        }
        //Använder LINQ och Getsummary metoden från andra klassen för att skriva ut alla
        Applications.ForEach(application => Console.WriteLine(application.GetSummary()));
    }
    public void UpdateStatus()
    {
        if(Applications.Count == 0)
        {
            System.Console.WriteLine("Det finns inga ansökningar");
            return;
        }

        for (int i = 0; i < Applications.Count; i ++)
        {
            //[i] så man vet var i listan den ska kolla, skriver ut alla med index nummret.
            System.Console.WriteLine($"{i}. {Applications[i].CompanyName} - {Applications[i].PositionTitle} - {Applications[i].Status} ");
        }

        System.Console.WriteLine("Vilken ansökan vill du ändra Status på. Ange Siffran!!"); 
        int index = int.Parse(Console.ReadLine()!); //Få fram index postion man vill ändra status på

        System.Console.WriteLine("Vilken status vill sätta?");
        System.Console.WriteLine("1. Interview");
        System.Console.WriteLine("2. Offer");
        System.Console.WriteLine("3. Rejected");
        string val = Console.ReadLine()!;

        if (val == "1")
        {
            Applications[index].Status = Status.Interview;
            System.Console.WriteLine("Ändrade status till interview");
        }
        else if(val == "2")
        {
            Applications[index].Status = Status.Offer;
            System.Console.WriteLine("Ändrade status till Offer");
        }
        else if(val == "3")
        {
            Applications[index].Status = Status.Rejected;
            System.Console.WriteLine("Ändrade status till rejected :(");
        }
        else
        {
            System.Console.WriteLine("Ogiltigt val");
            return;
        }
    }
    public void DeleteApplication()
    {
        //Använder samma princip som Uppdatestatus metoden
        if(Applications.Count == 0)
        {
            System.Console.WriteLine("Det finns inga ansökningar");
            return;
        }
        
        for (int i = 0; i < Applications.Count; i ++)
        {
            System.Console.WriteLine($"{i}. {Applications[i].CompanyName} - {Applications[i].PositionTitle} - {Applications[i].Status} ");
        }
        System.Console.WriteLine("Vilken ansökan vill du ta bort? Ange siffran!!"); 
        int index = int.Parse(Console.ReadLine()!); //Få fram index postion 

        Applications.RemoveAt(index);
        System.Console.WriteLine("Ansökan togs bort");
    }


}