using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.GoToHomePage();

            // Подготовка
            if (!app.Contacts.IsContactPresent()) // Если контактов нет - создаем новый
            {
                app.Contacts.CreateContact();
            }

            // Действие
            app.Contacts
                .SelectContact(0)
                .RemoveContact();
            app.Navigator.GoToHomePage();
        }
    }
}
