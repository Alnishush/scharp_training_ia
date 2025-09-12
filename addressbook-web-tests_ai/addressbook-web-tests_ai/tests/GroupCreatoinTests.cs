using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RndomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(10))
                {
                    Header = GenerateRandomString(10),
                    Footer = GenerateRandomString(10)
                });
            }

            return groups;
        }

        [Test, TestCaseSource("RndomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //получаем список групп до
            
            app.Groups.Create(group); // Для public GroupHelper CreateGroup(GroupData group) из GroupHelper

            ClassicAssert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount()); // Проверяем колчичество групп

            List<GroupData> newGroups = app.Groups.GetGroupList(); //получаем список групп после
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            ClassicAssert.AreEqual(oldGroups, newGroups); //Проверяем, что список групп увелисился на 1
        }
    }
}
