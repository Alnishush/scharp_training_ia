using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Navigator.GoToHomePage();

            // Подготовка
            if (!app.Contacts.IsContactPresent()) // Если контактов нет - создаем новый
            {
                app.Contacts.CreateContact();
            }

            // Действие
            app.Contacts
                .EditContact(0)
                .FillAddressForm(new ContactData("Петр1", "Первый"))
                .UpdateContactModification();
            app.Navigator.GoToHomePage();
        }
    }
}
