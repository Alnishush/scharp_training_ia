using System;
using System.Xml.Linq;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public bool Equals(ContactData other) //Реализует сравнения
        {
            if (Object.ReferenceEquals(other, null)) //Если тот объект с которым сравниваем это null
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other)) //Если объект один и тот же
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() & Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname=" + Firstname + ", lastname=" + Lastname;

        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            // Сначала сравниваем по фамилии
            int LastnameCompare = Lastname.CompareTo(other.Lastname);
            if (LastnameCompare != 0)
            {
                return LastnameCompare;
            }
            // Если фамилии одинаковые, сравниваем по имени
            return Firstname.CompareTo(other.Firstname);
        }

        public ContactData(string firstname)
        {
            Firstname = firstname;
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
