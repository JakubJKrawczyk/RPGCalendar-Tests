using RpgCalendar.Utilities;
using RpgCalendar.WebService;

namespace RpgCalendar.Tests;

public class TestFactory
{
    public TestFactory()
    {
    }

    public User User { get; private set; }

    public TestFactory PrepareUser(out User user, string? name = null)
    {
        name ??= Rnd.String();

        user = User.Prepare(name).Create();
        User = user;
        return this;
    }
}