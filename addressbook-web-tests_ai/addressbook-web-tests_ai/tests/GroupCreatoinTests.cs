using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToGroupsPage();
            app.Groups // Так можно сделать из-за вызова самого себя GroupHelper
                .InitNewGroupCreation()
                .FillGroupForm(new GroupData("q", "qw", "qwe"))
                .SubmitGroupCreation()
                .ReternToGroupsPage();
            //app.Groups.CreateGroup(group); // Для public GroupHelper CreateGroup(GroupData group) из GroupHelper
        }
    }
}
