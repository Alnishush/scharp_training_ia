using NUnit.Framework;

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
                app.Groups.CreateGroup();
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList(); //получаем список групп до

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList(); //получаем список групп после

            oldGroups.RemoveAt(0); //Удаленный элемент из списка до
            CollectionAssert.AreEqual(oldGroups, newGroups); //Сравнение списков*/
        }
    }
}
