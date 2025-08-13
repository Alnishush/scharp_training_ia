using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected IWebDriver driver; // Ссылка на драйвер
        protected string baseURL = "";
        protected bool acceptNextAlert;

        public HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}