using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();
            app.Logins.Login(new AccountData("admin", "secret"));
            /*app = new ApplicationManager(); // Инициализация

            app.Navigator.OpenHomePage();
            app.Logins.Login(new AccountData("admin", "secret"));*/
        }

        /*[TearDown]
        public void TeardownTest()
        {
            app.Logins.Logout();
            app.Stop(); // Останавливает драйвер
        }*/
    }
}

