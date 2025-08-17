using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddAddressTests : AuthTestBase
    {
        [Test]
        public void AddAddressTest()
        {
            app.Navigator.GoToAddNewPage();
            app.Contacts
                .FillAddressForm(new AddressData("Игорь", "Тарантинович"))
                .SubmitAddressCreation();
            app.Navigator.GoToHomePage();
        }
    }
}
