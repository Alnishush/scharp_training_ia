using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Navigator.GoToHomePage();
            app.Contacts.EditContact(1);
            app.Contacts.FillAddressForm(new AddressData("Петр", "Первый"));
            app.Contacts.UpdateContactModification();
            app.Navigator.GoToHomePage();
        }
    }
}
