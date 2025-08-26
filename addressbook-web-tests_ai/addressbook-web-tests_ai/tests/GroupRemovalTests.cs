using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.IsGroupPresent()) // Если групп нет - создаем новую
            {
                GroupData group = new GroupData("Test Group");
                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList(); //получаем список групп до

            app.Groups.Remove(0);

            ClassicAssert.AreEqual(oldGroups.Count-+ 1, app.Groups.GetGroupCount()); // Проверяем колчичество групп

            List<GroupData> newGroups = app.Groups.GetGroupList(); //получаем список групп после
            oldGroups.RemoveAt(0); //Удаленный элемент из списка до
            oldGroups.Sort();
            newGroups.Sort();
            ClassicAssert.AreEqual(oldGroups, newGroups);
        }
    }
}
