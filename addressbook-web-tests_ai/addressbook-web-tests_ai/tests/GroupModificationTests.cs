using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Navigator.GoToGroupsPage();
            app.Groups.SelectGroup(1);
            app.Groups.InitEditGroupModification();
            app.Groups.FillGroupForm(new GroupData("z", "zx", "zxc"));
            app.Groups.UpdateGroupModificationn();
            app.Groups.ReternToGroupsPage();
        }
    }
}
