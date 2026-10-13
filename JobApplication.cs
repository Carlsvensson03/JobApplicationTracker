using System;
using System.Net;
public enum Status 
{
    //Utanför, lättare att nå/återanvända
    Applied,
    Interview,
    Offer,
    Rejected,
}
public class JobApplication
{
    //Atributer
    public string CompanyName;
    public string PositionTitle;
    public Status Status;
    public DateTime Applicationdate = DateTime.Now; // sätter dagens datum direkt
    public DateTime? Responsedate; // Kan sakna värde
    public int SalaryExpectation;

    public int GetDaysSinceApplied()
    {
        return (DateTime.Now - Applicationdate).Days; // .Days så jag bara få antal dagar
    }
    public string GetSummary()
    {
        return $"{CompanyName} - {PositionTitle} - {Status}. Sickad: {Applicationdate.ToShortDateString()}"; //ToShortDateString() så man bara få datumet
    }


}
