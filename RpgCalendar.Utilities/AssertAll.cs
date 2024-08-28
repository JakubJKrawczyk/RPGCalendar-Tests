using NUnit.Framework;

namespace RpgCalendar.Utilities;

public static class AssertAll
{

    public static void Succeed(params Action[] asserts)
    {
        foreach (Action assert in asserts)
        {
            try
            {
                assert();
            }
            catch (AssertionException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}