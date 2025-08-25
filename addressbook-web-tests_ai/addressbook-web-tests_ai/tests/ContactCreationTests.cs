using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Security.Cryptography;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void AddAddressTest()
        {
            ContactData contact = new ContactData("Игорь", "Тарантинович");

            List<ContactData> oldContacts = app.Contacts.GetGroupList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetGroupList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            ClassicAssert.AreEqual(oldContacts, newContacts);
        }
    }
}
