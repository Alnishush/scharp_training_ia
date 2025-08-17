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
            app.Groups
                .SelectGroup(1)
                .InitEditGroupModification()
                .FillGroupForm(new GroupData("z", "zx", "zxc"))
                .UpdateGroupModificationn()
                .ReternToGroupsPage();
        }
    }
}
