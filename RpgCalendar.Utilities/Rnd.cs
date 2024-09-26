namespace RpgCalendar.Utilities;

public class Rnd
{
    public static string String(int length = 10)
    {
        var random = Random.Shared;
        
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        
    }

    public static string NumbersToString(int length = 10)
    {
        var random = Random.Shared;
        
        const string chars = "1234567890";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());

    }
}