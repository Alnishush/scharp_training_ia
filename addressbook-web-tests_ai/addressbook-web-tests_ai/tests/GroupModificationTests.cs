using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
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

            app.Groups.Modify(0, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList(); //получаем список групп после
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            ClassicAssert.AreEqual(oldGroups, newGroups); //Проверяем, что список групп увелисился на 1
        }
    }
}
