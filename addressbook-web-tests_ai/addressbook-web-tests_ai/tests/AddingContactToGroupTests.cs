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
            // 1. Проверяем что есть группы, если нет - создаем
            List<GroupData> allGroups = GroupData.GetAll();
            if (allGroups.Count == 0)
            {
                GroupData newGroup = new GroupData("TestGroup");
                app.Groups.Create(newGroup);
                allGroups = GroupData.GetAll();
            }

            // 2. Проверяем что есть контакты, если нет - создаем
            List<ContactData> allContacts = ContactData.GetAll();
            if (allContacts.Count == 0)
            {
                ContactData newContact = new ContactData("Test", "Contact");
                app.Contacts.Create(newContact);
                allContacts = ContactData.GetAll();
            }

            // 3. Ищем пару (группа, контакт) где контакт не в группе
            GroupData targetGroup = null;
            ContactData targetContact = null;

            foreach (GroupData group in allGroups)
            {
                List<ContactData> contactsInGroup = group.GetContacts();
                List<ContactData> contactsNotInGroup = allContacts.Except(contactsInGroup).ToList();

                if (contactsNotInGroup.Count > 0)
                {
                    targetGroup = group;
                    targetContact = contactsNotInGroup.First();
                    break;
                }
            }

            // 4. Если все контакты уже во всех группах - создаем новую группу
            if (targetGroup == null)
            {
                GroupData newGroup = new GroupData("NewGroupForTest");
                app.Groups.Create(newGroup);
                targetGroup = GroupData.GetAll().First(g => g.Name == newGroup.Name);
                targetContact = allContacts.First();
            }

            //GroupData group = GroupData.GetAll()[0];            // Берет первую группу из базы данных

            // 5. Получаем старый список контактов в группе
            List<ContactData> oldList = targetGroup.GetContacts();    // Получает список контактов, которые уже находятся в этой группе

            // 6. Добавляем контакт в группу
            app.Contacts.AddContactToGroup(targetContact, targetGroup); // Выполняет само добавление через пользовательский интерфейс

            // 7. Сравнивает ожидаемый и фактический списки контактов:
            List<ContactData> newList = targetGroup.GetContacts();    //Получаем новый список контактов
            oldList.Add(targetContact);                               //В старый список добавляем контакт
            oldList.Sort();                                     //Сортируем
            newList.Sort();                                     //Сортируем
            ClassicAssert.AreEqual(oldList, newList);           //Сравниваем
        }
    }
}
