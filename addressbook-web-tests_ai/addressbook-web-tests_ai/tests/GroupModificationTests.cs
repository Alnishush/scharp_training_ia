using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

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
                .SelectGroup(1)
                .InitEditGroupModification()
                .FillGroupForm(new GroupData("z", "zx", "zxc"))
                .UpdateGroupModificationn()
                .ReternToGroupsPage();
        }
    }
}
