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
            GroupData group = GroupData.GetAll()[0]; //Выбираем группу
            List<ContactData> oldList = group.GetContacts(); //Запоминаем старый список контактов
            ContactData contact = ContactData.GetAll().Except(oldList).First(); //Убираем контакты из заданной группы и берем первый. Этот контакт будем добавлять в группу

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts(); //Получаем новый список контактов
            oldList.Add(contact); //В старый список добавляем контакт
            newList.Sort(); //Сортируем
            oldList.Sort(); //Сортируем

            ClassicAssert.AreEqual(oldList, newList); //Сравниваем
        }
    }
}
