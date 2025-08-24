using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            // Подготовка
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //получаем список групп до

            // Подготовка
            if (!app.Groups.IsGroupPresent()) // Если групп нет - создаем новую
            {
                app.Groups.CreateGroup();
            }

            // Действие
            app.Navigator.GoToGroupsPage();
            app.Groups
                .SelectGroup(0)
                .RemoveGroup()
                .ReternToGroupsPage();

            // Проверка
            List<GroupData> newGroups = app.Groups.GetGroupList(); //получаем список групп после

            oldGroups.RemoveAt(0); //Удаленный элемент из списка до
            Assert.AreEqual(oldGroups, newGroups); //Сравнение списков
        }
    }
}
