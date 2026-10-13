using System;
using System.Net;
using System.Linq;

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
    public void ShowByStatus()
    {
        //LINQ som skapa lista för dem som ha intervju, skriver sen ut dem med färg
        // Application.Where kolla i huvud listan efter dem med en viss status
        var interviews = Applications.Where(application => application.Status == Status.Interview).ToList();
        if (interviews.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("--- Intervjuer ---");
            foreach(var application in interviews)
            {
                System.Console.WriteLine($"{application.CompanyName} - {application.PositionTitle}");
            }
            Console.ResetColor();
        }
        var Offer = Applications.Where(application => application.Status == Status.Offer).ToList();
        if (Offer.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("--- Erbjudanden ---");
            foreach(var application in Offer)
            {
                System.Console.WriteLine($"{application.CompanyName} - {application.PositionTitle}");
            }
            Console.ResetColor();
        }
        var Applied = Applications.Where(application => application.Status == Status.Applied).ToList();
        if (Applied.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("--- Sökt ---");
            foreach(var application in Applied)
            {
                System.Console.WriteLine($"{application.CompanyName} - {application.PositionTitle}");
            }
            Console.ResetColor();
        }
        var Rejected = Applications.Where(application => application.Status == Status.Rejected).ToList();
        if (Rejected.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("--- Avslag ---");
            foreach(var application in Rejected)
            {
                System.Console.WriteLine($"{application.CompanyName} - {application.PositionTitle}");
            }
            Console.ResetColor();
        }
        
    }
    public void OrederbyDate()
    {
        var ordered = Applications.OrderBy(application => application.Applicationdate);
        foreach(var application in ordered)
        {
            System.Console.WriteLine($"{application.CompanyName}, {application.PositionTitle}, {application.Applicationdate}");
        }
    }
    public void ShowStatistc()
    {
        int Antal = Applications.Count();
        System.Console.WriteLine($"Totalt: {Antal} Ansökningar");
        
        //LINQ som kollar i varje obejekt i huvudlistan efter hur många som har en viss Status.
        var antalinterviews = Applications.Count(application => application.Status == Status.Interview);
        var antalOffer = Applications.Count(application => application.Status == Status.Offer);
        var antalRejected = Applications.Count(application => application.Status == Status.Rejected);
        var antalApplied = Applications.Count(application => application.Status == Status.Applied);

        System.Console.WriteLine($"Intervjuer: {antalinterviews}");
        System.Console.WriteLine($"Erbjudanden: {antalOffer}");
        System.Console.WriteLine($"Avslag: {antalRejected}");
        System.Console.WriteLine($"Sökta: {antalApplied}");


        //Skapa ny lista, gå igenom den gammla kolla så obejektet ha fåt nåt svar
        var applicationanswer = Applications.Where(application => application.Responsedate != null).ToList();

        if (applicationanswer.Count > 0)
        {
            //Gå igenom applicationanswer, kolla varje application svarsdatum - ansökningsdatum, totaldays för få dagar
            var averageResponseTime = applicationanswer.Average(a => (a.Responsedate - a.Applicationdate)?.TotalDays);
            System.Console.WriteLine($"Genomsnittlig svarstid: {averageResponseTime} dagar");
        }
        else
        {
            System.Console.WriteLine("Det finns inga svar regristrerade");
        }







    }

}