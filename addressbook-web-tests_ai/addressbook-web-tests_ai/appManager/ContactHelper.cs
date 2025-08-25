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


        public ContactHelper FillAddressForm(ContactData address)
        {
            Type(By.Name("firstname"), address.Firstname);
            Type(By.Name("lastname"), address.Lastname);
            return this;
        }

        public ContactHelper SubmitAddressCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper UpdateContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public bool IsContactPresent()
        {
            return IsElementPresent(By.Name("entry"));
        }

        public ContactHelper CreateContact()
        {
            manager.Navigator.GoToAddNewPage();
            FillAddressForm(new ContactData("Игорь", "Тарантинович"));
            SubmitAddressCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper EditContact(int line)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[ " + (line+2) + " ]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper SelectContact(int line)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[ " + (line+2) + " ]/td/input")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public List<ContactData> GetGroupList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr.entry"));
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.Text));
            }
            return contacts;
        }
    }
}
