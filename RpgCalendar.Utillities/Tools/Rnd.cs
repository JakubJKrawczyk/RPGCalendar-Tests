namespace RpgCalendar.Utillities;

public class Rnd
{
    public static string String(int letters = 10)
    {
        var random = Random.Shared;
        
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, letters)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        
    }
}