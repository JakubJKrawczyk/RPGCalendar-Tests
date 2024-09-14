using RpgCalendar.Utilities;
using RpgCalendar.Utilities.Tools;
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
    
        [Test]
        public void RegisterUser()
        {
            string name = Rnd.String();

            user = User.Prepare(name).Create();
        
            AssertAll.Succeed(
                () => Assert.That(user.DisplayName, Is.EqualTo(name))
            );
        }
        
        [Test]
        public void RegisterUser_WithEmptyName_ShouldFail()
        {
            string emptyname = string.Empty;

            user = User.Prepare(emptyname);

            AssertAll.Succeed(
                () => Assert.That(()=>user.Create(), Throws.Exception.InstanceOf<Exception>()));
        }
        
    #endregion
    
}