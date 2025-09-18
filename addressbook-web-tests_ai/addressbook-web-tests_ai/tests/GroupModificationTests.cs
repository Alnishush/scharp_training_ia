using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (!app.Groups.IsGroupPresent()) // Если групп нет - создаем новую
            {
                GroupData group = new GroupData("Test Group");
                app.Groups.Create(group);
            }

            GroupData newData = new GroupData("z");
            newData.Header = "zx";
            newData.Footer = "zxc";

            List<GroupData> oldGroups = app.Groups.GetGroupList(); //получаем список групп до
            GroupData oldData = oldGroups[0]; // Сохраняем строку по id

            app.Groups.Modify(0, newData);

            ClassicAssert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); // Проверяем колчичество групп

            List<GroupData> newGroups = app.Groups.GetGroupList(); //получаем список групп после
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            ClassicAssert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                ClassicAssert.AreEqual(newData.Name, group.Name); // Изменилась именно этот строка по id
                }
            }
        }
    }
}
