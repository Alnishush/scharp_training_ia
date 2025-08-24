using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            // Подготовка
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //получаем список групп до

            // Действие
            app.Navigator.GoToGroupsPage();
            app.Groups // Так можно сделать из-за вызова самого себя GroupHelper
                .InitNewGroupCreation()
                .FillGroupForm(new GroupData("q", "qw", "qwe"))
                .SubmitGroupCreation()
                .ReternToGroupsPage();
            //app.Groups.CreateGroup(group); // Для public GroupHelper CreateGroup(GroupData group) из GroupHelper

            // Проверка
            List<GroupData> newGroups = app.Groups.GetGroupList(); //получаем список групп после
            Assert.AreEqual(oldGroups.Count + 1/*ожидаем*/, newGroups.Count/*получаем*/); //Проверяем, что список групп увелисился на 1
        }
    }
}
