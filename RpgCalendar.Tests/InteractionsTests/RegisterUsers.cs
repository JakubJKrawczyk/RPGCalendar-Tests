using Microsoft.IdentityModel.JsonWebTokens;
using RestSharp.Authenticators;
using RpgCalendar.Utilities;
using RpgCalendar.WebService;

namespace RpgCalendar.Tests.InteractionsTests;

public class RegisterUsers : TestTemplate
{

    private User user;

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        user.Delete();

        //TODO: Zaimplementowac kody bledow
    }

    #region Add

        //TODO: zamiast sprawdzania Exception powinnismy sprawdzac errorCode
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
        [Description("Test for creating user with invalid usernames")]
        public void RegisterInvalidUser(string username)
        {
            user = User.Prepare(username);

            AssertAll.Succeed(
                () => Assert.That(() => user.Create(), Throws.Exception)
            );
        }

        [Test]
        public void RegisterWithInvalidToken()
        {
            var user = User.Prepare(Rnd.String()).WithToken(Rnd.String());
            
            AssertAll.Succeed(
                () => Assert.That(() => user.Create(), Throws.Exception)
                );
        }
        
        [Test]
        public void RegisterWithExpiredToken()
        {
            var user = User.Prepare(Rnd.String()).WithToken(UtillitiesTools.GenerateJwtToken(Rnd.String(), DateTime.Now.AddDays(-1)));
            
            AssertAll.Succeed(
                () => Assert.That(() => user.Create(), Throws.Exception)
            );
        }

        [Test]
        public void RegisterUserWithEmptyToken()
        {
            var user = User.Prepare(Rnd.String()).WithToken("");
            
            AssertAll.Succeed(
                () => Assert.That( () => user.Create(), Throws.Exception)
                );
        }

        [Test]
        public void RegisterWithInvalidTokenContent()
        {
            var user = User.Prepare(Rnd.String()).WithToken(UtillitiesTools.GenerateJwtToken(Rnd.String()));

            AssertAll.Succeed(
                ( )=> Assert.That(() => user.Create(), Throws.Exception)
            );
        }

        [Test]
        public void GetUserDataAfterRegistrationWithoutToken()
        {
            var user = User.Prepare(Rnd.String()).Create();
            user.WithToken("");
            
            AssertAll.Succeed(() => Assert.That(() => user.GetMe(), Throws.Exception));
        }
        
        [Test]
        public void GetUserDataAfterRegistration()
        {
            user = User.Prepare(Rnd.String()).Create();
            var tempName = user.DisplayName;
            var us = user.GetMe();
            
            AssertAll.Succeed(() => Assert.That(us.DisplayName, Is.EqualTo(tempName)));
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

    
}