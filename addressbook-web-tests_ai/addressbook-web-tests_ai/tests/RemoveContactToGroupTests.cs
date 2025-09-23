using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];            // Берет первую группу из базы данных
            List<ContactData> oldList = group.GetContacts();    // Получает список контактов, которые уже находятся в этой группе
            ContactData contact = oldList[0];                   // Берем первый контакт из группы для удаления

            app.Contacts.RemoveContactFromGroup(contact, group); // Выполняет удаление через пользовательский интерфейс

            // Сравнивает ожидаемый и фактический списки контактов:
            List<ContactData> newList = group.GetContacts();    // Получаем новый список контактов
            oldList.Remove(contact);                            // Из старого списка удаляем контакт
            newList.Sort();                                     // Сортируем
            oldList.Sort();                                     // Сортируем
            ClassicAssert.AreEqual(oldList, newList);           // Сравниваем
        }
    }
}