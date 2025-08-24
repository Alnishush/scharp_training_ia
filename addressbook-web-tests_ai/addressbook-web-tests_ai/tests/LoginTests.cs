using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            // Подготовка
            app.Auth.Logout();

            // Действие
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            
            // Проверка
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithinvalidCredentials()
        {
            // Подготовка
            app.Auth.Logout();

            // Действие
            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);

            // Проверка
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
