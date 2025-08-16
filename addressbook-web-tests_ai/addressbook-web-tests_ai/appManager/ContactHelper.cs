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
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(address.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(address.Lastname);
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

        public ContactHelper EditContact(int line)
        {
            if (HaveContact())
            {
                line++; //+1 строка, т.к. 1 строка это шапка таблицы
                driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[ " + line + " ]/td[8]/a/img")).Click();
            }
            /*else
            {
                manager.Navigator.GoToAddNewPage();
            }*/
            return this;
        }

        public bool HaveContact()
        {
            return IsElementPresent(By.Name("entry"));
        }

        public ContactHelper SelectContact(int line)
        {
            line++; //+1 строка, т.к. 1 строка это шапка таблицы
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[ " + line + " ]/td/input")).Click();
            return this;
        }

        internal ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
    }
}
