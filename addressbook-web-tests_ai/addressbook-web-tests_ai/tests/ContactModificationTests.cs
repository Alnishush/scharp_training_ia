using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (!app.Contacts.IsContactPresent()) // Если контактов нет - создаем новый
            {
                ContactData contact = new ContactData("Test Contact");
                app.Contacts.Create(contact);
            }

            ContactData newData = new ContactData("Петр");
            newData.LastName = "Апдейтович";
 
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0]; // Сохраняем строку по id

            app.Contacts.Modify(0, newData);

            // Вручную обновляем старый список
            //oldContacts.Remove(oldData);
            //oldContacts.Add(newData); // ← Теперь списки синхронизированы

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            ClassicAssert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    ClassicAssert.AreEqual(newData.FirstName, contact.FirstName); // Изменилась именно этот строка по id
                }
            }
        }
    }
}
