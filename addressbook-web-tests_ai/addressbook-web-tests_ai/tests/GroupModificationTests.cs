using NUnit.Framework;

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
                app.Groups.CreateGroup();
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
            CollectionAssert.AreEqual(oldGroups, newGroups); //Проверяем, что список групп увелисился на 1
        }
    }
}
