﻿using RpgCalendar.Utilities;
using RpgCalendar.Utilities.Tools;
using RpgCalendar.WebService;

namespace RpgCalendar.Tests.InteractionsTests;

public class RegisterUsers : TestTemplate

{
    
    #region Add
    
        [Test]
        public void RegisterUser()
        {
            string name = Rnd.String();

            var user = User.Prepare(name).Create();
        
            AssertAll.Succeed(
                () => Assert.That(user.DisplayName, Is.EqualTo(name))
            );
        }
        
        [Test]
        public void RegisterUser_WithEmptyName_ShouldFail()
        {
            string emptyname = string.Empty;

            var user = User.Prepare(emptyname).Create();

            AssertAll.Succeed(
                () => Assert.That(user.DisplayName, Is.EqualTo("User name cannot be empty")));
        }
        
    #endregion
    
}