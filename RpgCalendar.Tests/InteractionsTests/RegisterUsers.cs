using RpgCalendar.Utilities;
using RpgCalendar.WebService;

namespace RpgCalendar.Tests.InteractionsTests;

public class RegisterUsers : TestTemplate
{
    
    private User user;
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        //user.Delete();
        
        //TODO: Zaimplementowac kody bledow
    }
    
    #region Add
    
        [Test]
        public void RegisterValidUser()
        {
            string name = Rnd.String();

            user = User.Prepare(name).Create();
        
            AssertAll.Succeed(
                () => Assert.That(user.DisplayName, Is.EqualTo(name))
            );
        }
        
        [TestCaseSource(nameof(GenerateInvalidUsernames))]
        [Description("Check if user exists")]
        public void RegisterInvalidUser(string username)
        {
            user = User.Prepare(username);
            
            AssertAll.Succeed(
                () => Assert.That(()=>user.Create(), Throws.Exception)
                );
        }
    
    #endregion
    #region TestCases

        private static List<string> GenerateInvalidUsernames =
        [
            Rnd.String(65),
            string.Join("", Enumerable.Repeat(" ", 16)),
            "!@#$%^&*()_+{}|{}|",
            " d u p a ",
            "@koza XD ",
            "\ud83d\udc58\n\ud83d\uddfb\n\ud83d\uddfc\n\ud83c\udf8b",
            "PAL GUME-",
            "\u2702\ufe0f 🤨\ud83c\udf4f"
        ];

    #endregion

    private class InternalAPIException : Exception
    {
        public InternalAPIException()
        {
            
        }
    }
}