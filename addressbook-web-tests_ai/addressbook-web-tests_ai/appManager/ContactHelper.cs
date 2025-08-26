using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager) { }

        public ContactHelper Create(ContactData contact) // Для app.Groups.CreateGroup(group) из GroupCreationTests
        {
            manager.Navigator.GoToAddNewPage();
            FillAddressForm(contact);
            SubmitAddressCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Modify(int index, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            EditContact(index);
            FillAddressForm(newData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper FillAddressForm(ContactData address)
        {
            Type(By.Name("firstname"), address.Firstname);
            Type(By.Name("lastname"), address.Lastname);
            return this;
        }

        public ContactHelper SubmitAddressCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null; // Чистим кеш
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null; // Чистим кеш
            return this;
        }

        public bool IsContactPresent()
        {
            return IsElementPresent(By.Name("entry"));
        }

        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[ " + (index+2) + " ]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[ " + (index+2) + " ]/td/input")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null; // Чистим кеш
            return this;
        }

        private List<ContactData> contactCache = null; // Тут хранится сохраненный список (кеш списка) (для ускорения тестов)

        public List<ContactData> GetContactList()
        {
            if (contactCache == null) // При первом обращении сохраняем список в кеш
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();

                // Находим все строки групп
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                
                foreach (IWebElement element in elements)
                {
                    // Находим все колонки в строке
                    IList<IWebElement> column = element.FindElements(By.TagName("td"));

                    // Извлекаем фамилию (2я колонка) и имя (3я колонка)
                    string lastname = column[1].Text;
                    string firstname = column[2].Text;

                    contactCache.Add(new ContactData(firstname, lastname));
                }
            }
            return new List<ContactData>(contactCache); // Возвращаем копию

            /*
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            
            // Находим все строки контактов
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
            
            foreach (IWebElement element in elements)
            {
                // Находим все колонки в строке
                IList<IWebElement> column = element.FindElements(By.TagName("td"));

                // Извлекаем фамилию (2я колонка) и имя (3я колонка)
                string lastname = column[1].Text;
                string firstname = column[2].Text;

                contacts.Add(new ContactData(firstname, lastname));
            }
            return contacts;
            */
        }
    }
}
