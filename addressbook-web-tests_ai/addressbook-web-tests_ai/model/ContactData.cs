using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmail;
        private string allNames;

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
            return Firstname == other.Firstname
                && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode()
                & Lastname.GetHashCode();
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
                return Lastname.CompareTo(other.Lastname);
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
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)).Trim(); //Метод Trim() в C# используется для удаления пробельных символов с начала и конца строки
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmail = value;
            }
        }

        public string AllNames
        {
            get
            {
                if (allNames != null)
                {
                    return allNames;
                }
                else
                {
                    return (Firstname + Lastname);
                }
            }
            set
            {
                allNames = value;
            }
        }

        public string FirstAndLastNames { get; set; }

        //Чистим от ненужных символов:
        private string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "") //если какой-то телефон отсутствует, то не уподет
            {
                return "";
            }
            //return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            //или так:
            return Regex.Replace(phone, "[ \\-()]", "") + "\r\n"; //регулярное выражение
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }
    }
}
