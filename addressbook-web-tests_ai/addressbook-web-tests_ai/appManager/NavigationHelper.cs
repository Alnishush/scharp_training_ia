using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "/addressbook")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook");
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook")
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToAddNewPage()
        {
            if (driver.Url == baseURL + "/addressbook/edit.php")
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
