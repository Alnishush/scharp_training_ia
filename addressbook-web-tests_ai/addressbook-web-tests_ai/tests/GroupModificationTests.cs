using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Navigator.GoToGroupsPage();
           
            // Подготовка
            if (!app.Groups.IsGroupPresent()) // Если групп нет - создаем новую
            {
                app.Groups.CreateGroup();
            }

            // Действие
            app.Groups
                .SelectGroup(0)
                .InitEditGroupModification()
                .FillGroupForm(new GroupData("z", "zx", "zxc"))
                .UpdateGroupModificationn()
                .ReternToGroupsPage();
        }
    }
}
