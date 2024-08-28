using RpgCalendar.Utilities;
using RpgCalendar.Utilities.Tools;
using RpgCalendar.WebService;

namespace RpgCalendar.Tests.InteractionsTests;

public class RegisterUser : TestTemplate
{
    [Test]
    public void Register()
    {
        string name = Rnd.String();

        var user = User.Prepare(name).Create();
        
        AssertAll.Succeed(
            () => Assert.That(user.DisplayName, Is.EqualTo(name))
        );
    }
}