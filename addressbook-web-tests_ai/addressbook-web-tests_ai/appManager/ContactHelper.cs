using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager) { }

        public ContactHelper FillAddressForm(AddressData address)
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
            FillAddressForm(new AddressData("Игорь", "Тарантинович"));
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
    }
}
