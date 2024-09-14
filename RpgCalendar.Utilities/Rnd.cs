namespace RpgCalendar.Utilities;

public class Rnd
{
    public static string String(int letters = 10)
    {
        var random = Random.Shared;
        
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, letters)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        
    }
}