namespace WebAddressbookTests
{
    public class AddressData
    {
        private string firstname;
        private string lastname;

        public AddressData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
    }
}
