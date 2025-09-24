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

            // 3. Ищем пару (группа, контакт) где контакт уже в группе
            GroupData targetGroup = null;
            ContactData targetContact = null;

            foreach (GroupData group in allGroups)
            {
                List<ContactData> contactsInGroup = group.GetContacts();    // Для каждой группы получает список контактов
                if (contactsInGroup.Count > 0)                              // группа не пустая
                {
                    targetGroup = group;                                    // Сохраняет текущую группу
                    targetContact = contactsInGroup.First();                // Берет первый контакт из этой группы
                    break;
                }
            }

            // 4. Если нет групп с контактами - добавляем контакт в группу
            if (targetGroup == null)
            {
                targetGroup = allGroups.First();                            // Берем первую группу
                targetContact = allContacts.First();                        // Берем первый контакт

                app.Contacts.AddContactToGroup(targetContact, targetGroup); // Выполняет само добавление через пользовательский интерфейс
            }

            // 5. Получаем старый список контактов в группе
            List<ContactData> oldList = targetGroup.GetContacts();

            // 6. Удаляем контакт из группы
            app.Contacts.RemoveContactFromGroup(targetContact, targetGroup);

            // 7. Сравнивает ожидаемый и фактический списки контактов
            List<ContactData> newList = targetGroup.GetContacts();  // Получаем новый список контактов
            oldList.Remove(targetContact);                          // Из старого списка удаляем контакт
            oldList.Sort();                                         // Сортируем
            newList.Sort();                                         // Сортируем
            ClassicAssert.AreEqual(oldList, newList);               // Сравниваем
        }
    }
}