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
        public void SetupTest() // Метод инициализации
        {
            app = new ApplicationManager();
        }

        [TearDown]
        public void TeardownTest() // Метод останавливает драйвер в концу
        {
            app.Stop();
        }
    }
}

