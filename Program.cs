using System;


/* Programmet ska innehålla minst följande alternativ:
➕ Lägg till ny ansökan
📋 Visa alla ansökningar
🔍 Filtrera ansökningar efter status (LINQ) (VG del)
📅 Sortera ansökningar efter datum (OrderBy) (VG del)
📊 Visa statistik:
Totalt antal ansökningar
Antal per status (VG del)
Genomsnittlig svarstid (VG del)

✏️ Uppdatera status på en ansökan
🗑️ Ta bort en ansökan
💾 Avsluta programmet */

class program
{
    static void Main(string[] args)
    {
        JobManager manager = new JobManager(); // skapa obejektet av JobManeger
        bool run = true;
        while (run)
        {
            System.Console.WriteLine("1. Lägg till ansökan");
            System.Console.WriteLine("2. Visa alla ansökningar");
            System.Console.WriteLine("3. Filtrera ansökningar efter status");
            System.Console.WriteLine("4. Sotera ansökningar efter datum");
            System.Console.WriteLine("5. Visa statistik");
            System.Console.WriteLine("6. Uppdatera status på en ansökan");
            System.Console.WriteLine("7. Ta bort en ansökan");
            System.Console.WriteLine("8. Avsluta programmet");

            string val = Console.ReadLine()!;

            switch(val)
            {
                case "1":
                    manager.AddJob();
                break;

                case "2":
                    manager.ShowAll();
                break;

                case "3":
                break;

                case "4":
                break;

                case "5":
                break;

                case "6":
                    manager.UpdateStatus();
                break;

                case "7":
                break;

                case "8":
                    System.Console.WriteLine("Programmet avslutas");
                    run = false; // när jag sätter false avlsutas allt
                break;
                default: 
                    System.Console.WriteLine("Ogiltigt val, Testa igen");
                    break;
            }
        }
    }

}
