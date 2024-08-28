using RpgCalendar.Utilities;
using RpgCalendar.Utilities.Tools;

namespace RpgCalendar.Tests.InteractionsTests;

public class RegisterUser : TestTemplate
{
    [Test]
    public void Register()
    {
        string name = Rnd.String();
        
        Factory.PrepareUser(out var user, name);
        
        AssertAll.Succeed(
            () => Assert.That(user.DisplayName, Is.EqualTo(name))
        );
    }
}