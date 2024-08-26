using RpgCalendar.Utillities;

namespace RpgCalendar_tests.TestsInteractive;

public class RegisterUser : TestTemplate
{
    [Test]
    public void Register()
    {
        string name = Rnd.String();
        Factory.PrepareUser(name);

        var user = TestFactory.User;

        AssertAll.Succed(
            () => Assert.That(user.DisplayName, Is.EqualTo(name))
        );
    }
}