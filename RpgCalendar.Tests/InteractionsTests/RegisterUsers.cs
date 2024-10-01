using Microsoft.IdentityModel.JsonWebTokens;
using RestSharp.Authenticators;
using RpgCalendar.ApiClients.InternalApi;
using RpgCalendar.Utilities;
using RpgCalendar.WebService;

namespace RpgCalendar.Tests.InteractionsTests;

public class RegisterUsers : TestTemplate
{

    private User user;


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
            user = User.Prepare(Rnd.String()).Create();
            
            AssertAll.Succeed(
                () => Assert.That(() => user.WithToken(Rnd.String()).CreateInternal(), Throws.Exception.InstanceOf<InternalApiClient.InternalAPIException>())
                );
        }
        
        [Test]
        public void RegisterWithExpiredToken()
        {
            user = User.Prepare(Rnd.String()).Create();           
            
            AssertAll.Succeed(
                () => Assert.That(() => user.WithToken(UtillitiesTools.GenerateJwtToken(Rnd.NumbersToString(8), DateTime.Now.AddDays(-1))).CreateInternal(), Throws.Exception)
            );
        }

        [Test]
        public void RegisterUserWithEmptyToken()
        {
            user = User.Prepare(Rnd.String()).Create();
            
            AssertAll.Succeed(
                () => Assert.That( () => user.WithToken(string.Empty).CreateInternal(), Throws.Exception)
                );
        }

        [Test]
        public void RegisterWithInvalidTokenContent()
        {
            user = User.Prepare(Rnd.String());

            AssertAll.Succeed(
                ( )=> Assert.That(() => user.WithToken(UtillitiesTools.GenerateJwtToken(Rnd.String())).Create(), Throws.Exception)
            );
        }

        [Test]
        public void GetUserDataAfterRegistrationWithoutToken()
        {
            const string username = "majtek";
            user = User.Prepare(username).Create();
            user.WithToken("");
            
            AssertAll.Succeed(() => Assert.That(() => user.GetMe(), Throws.Exception));
        }
        
        [Test]
        public void GetUserDataAfterRegistration()
        {
            var username = Rnd.String();
            user = User.Prepare(username).Create();
            var us = user.GetMe();
            
            AssertAll.Succeed(
                () => Assert.That(us.DisplayName, Is.EqualTo(username)),
                () => Assert.That(us.PrivateCode, Is.EqualTo(user.PrivateCode)),
                () => Assert.That(us.UserId, Is.Not.EqualTo(Guid.Empty))
                
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

    
}