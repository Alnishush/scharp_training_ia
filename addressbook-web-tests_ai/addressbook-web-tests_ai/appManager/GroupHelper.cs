using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager)
            : base(manager) // Ссылка на менеджер
        {
        }

        public GroupHelper Create(GroupData group) // Для app.Groups.CreateGroup(group) из GroupCreationTests
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReternToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            RemoveGroup();
            ReternToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int index, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            InitEditGroupModification();
            FillGroupForm(newData);
            SubmitGroupModificationn();
            ReternToGroupsPage();
            return this;
        }

        public GroupHelper InitNewGroupCreation() // вместо void ставим GroupHelper и добавляем return this; что бы вызывать самого себя. Для уменьшения теста GroupCreationTests
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModificationn()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitEditGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper ReternToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[ " + (index+1) + " ]/input")).Click();
            return this;
        }

        public GroupHelper CreateGroup()
        {
            InitNewGroupCreation();
            FillGroupForm(new GroupData("q", "qw", "qwe"));
            SubmitGroupCreation();
            ReternToGroupsPage();
            return this;
        }

        public bool IsGroupPresent()
        {
            manager.Navigator.GoToGroupsPage();
            return IsElementPresent(By.ClassName("group"));
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>(); //создаем пустой список
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group")); //находим елементы на странице и сохраняем в коллекцию elements
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text)); //получаем текст из веб-элемента (название группы) и устанавливаем его как имя группы
            }
            return groups; //возвращаем список
        }
    }
}
