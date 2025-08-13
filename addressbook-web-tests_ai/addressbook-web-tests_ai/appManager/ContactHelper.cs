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
        public ContactHelper(IWebDriver driver)
            : base(driver) { }

        public void FillAddressForm(AddressData address)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(address.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(address.Lastname);
        }

        public void SubmitAddressCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        public void UpdateContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
        }

        public void EditContact(int line)
        {
            line++; //+1 строка, т.к. 1 строка это шапка таблицы
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[ "+ line + " ]/td[8]/a/img")).Click();
        }

        public void SelectContact(int line)
        {
            line++; //+1 строка, т.к. 1 строка это шапка таблицы
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[ "+ line + " ]/td/input")).Click();
        }

        internal void RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        }
    }
}
