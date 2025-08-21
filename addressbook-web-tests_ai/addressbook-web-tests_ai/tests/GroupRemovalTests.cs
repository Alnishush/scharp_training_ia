using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupsPage();

            // Подготовка
            if (!app.Groups.IsGroupPresent()) // Если групп нет - создаем новую
            {
                app.Groups.CreateGroup();
            }

            // Действие
            app.Navigator.GoToGroupsPage();
            app.Groups
                .SelectGroup(1)
                .RemoveGroup()
                .ReternToGroupsPage();
        }
    }
}
