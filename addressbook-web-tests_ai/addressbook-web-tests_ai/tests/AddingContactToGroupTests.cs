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
            List<GroupData> allGroups = GroupData.GetAll();         // получает все группы из базы данных и сохраняет их в список
            if (allGroups.Count == 0)                               // Проверяет, пустой ли список групп
            {
                GroupData newGroup = new GroupData("TestGroup");    // Создает новый объект группы
                app.Groups.Create(newGroup);                        // Создает группу
                allGroups = GroupData.GetAll();                     // Обновляет список групп из базы данных
            }

            // 2. Проверяем что есть контакты, если нет - создаем
            List<ContactData> allContacts = ContactData.GetAll();               // получает все контакты из базы данных и сохраняет их в список  
            if (allContacts.Count == 0)                                         // Проверяет, пустой ли список контактов
            {
                ContactData newContact = new ContactData("Test", "Contact");    // Создает новый объект контакта
                app.Contacts.Create(newContact);                                // Создает контакт
                allContacts = ContactData.GetAll();                             // Обновляет список контактов из базы данных
            }

            // 3. Ищем пару (группа, контакт) где контакт не в группе
            GroupData targetGroup = null;                                   // создает переменную для хранения найденной группы
            ContactData targetContact = null;                               // создает переменную для хранения найденного контакта

            foreach (GroupData group in allGroups)                          // Перебирает все группы из списка allGroups
            {
                List<ContactData> contactsInGroup = group.GetContacts();    // Получает список контактов, которые УЖЕ находятся в текущей группе
                // Поиск контактов НЕ в группе
                List<ContactData> contactsNotInGroup = allContacts          // все контакты в системе
                    .Except(contactsInGroup)                                // исключает контакты, которые уже в группе
                    .ToList();

                if (contactsNotInGroup.Count > 0)                           // Если есть хотя бы один контакт, которого нет в текущей группе
                {
                    // Сохраняем группу и первый подходящий контакт
                    targetGroup = group;
                    targetContact = contactsNotInGroup.First();
                    break;
                }
            }

            // 4. Если все контакты уже во всех группах - создаем новую группу
            if (targetGroup == null)                                                    // Если все контакты уже находятся во всех группах
            {
                GroupData newGroup = new GroupData("NewGroupForTest");
                app.Groups.Create(newGroup);
                targetGroup = GroupData.GetAll().First(g => g.Name == newGroup.Name);   // Получение созданной группы из БД
                targetContact = allContacts.First();                                    // Берем первый контакт
            }

            // 5. Получаем старый список контактов в группе
            List<ContactData> oldList = targetGroup.GetContacts();

            // 6. Добавляем контакт в группу
            app.Contacts.AddContactToGroup(targetContact, targetGroup);

            // 7. Сравнивает ожидаемый и фактический списки контактов
            List<ContactData> newList = targetGroup.GetContacts();      //Получаем новый список контактов
            oldList.Add(targetContact);                                 //В старый список добавляем контакт
            oldList.Sort();                                             //Сортируем
            newList.Sort();                                             //Сортируем
            ClassicAssert.AreEqual(oldList, newList);                   //Сравниваем
        }
    }
}
