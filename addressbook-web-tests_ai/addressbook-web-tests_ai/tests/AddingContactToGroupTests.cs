using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];            // Берет первую группу из базы данных
            List<ContactData> oldList = group.GetContacts();    // Получает список контактов, которые уже находятся в этой группе
            // Находит контакт, которого еще нет в группе:
            ContactData contact = ContactData.GetAll()          // все контакты из базы данных
                .Except(oldList)                                // исключает контакты, которые уже есть в группе
                .First();                                       // берет первый контакт из оставшихся

            app.Contacts.AddContactToGroup(contact, group);     // Выполняет само добавление через пользовательский интерфейс

            // Сравнивает ожидаемый и фактический списки контактов:
            List<ContactData> newList = group.GetContacts();    //Получаем новый список контактов
            oldList.Add(contact);                               //В старый список добавляем контакт
            newList.Sort();                                     //Сортируем
            oldList.Sort();                                     //Сортируем
            ClassicAssert.AreEqual(oldList, newList);           //Сравниваем
        }
    }
}
