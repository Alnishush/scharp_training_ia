using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Logins.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitNewGroupCreation();
            app.Groups.FillGroupForm(new GroupData("q", "qw", "qwe"));
            app.Groups.SubmitGroupCreation();
            app.Groups.ReternToGroupsPage();
            app.Logins.Logout();
        }
    }
}
