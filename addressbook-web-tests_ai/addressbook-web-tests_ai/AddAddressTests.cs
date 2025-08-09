using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddAddressTests : TestBase
    {
        [Test]
        public void AddAddressTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddNewPage();
            FillAddressForm(new AddressData("Игорь", "Тарантинович"));
            SubmitAddressCreation();
            GoToHomePage();
            Logout();
        }
    }
}
