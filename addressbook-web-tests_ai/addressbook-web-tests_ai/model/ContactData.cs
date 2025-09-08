using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmail;
        private string allNames;
        private string textInDetails;

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
            return FirstName == other.FirstName
                && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode()
                & LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname=" + FirstName
                + "\nlastname=" + LastName;

        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            // Сначала сравниваем по фамилии
            int LastnameCompare = LastName.CompareTo(other.LastName);
            if (LastnameCompare != 0)
            {
                return LastName.CompareTo(other.LastName);
            }
            // Если фамилии одинаковые, сравниваем по имени
            return FirstName.CompareTo(other.FirstName);
        }

        public ContactData(string firstname)
        {
            FirstName = firstname;
        }

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public ContactData()
        {
        }

        /*public ContactData(string allNames)
        {
            AllNames = allNames;
        }*/

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
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
                    return (FirstName + " " + LastName).Trim();
                }
            }
            set
            {
                allNames = value;
            }
        }

        /*private string CleanUpName(string name)
        {
            if (name == null || name == "")
            {   
                return "";
            }
            return name;
        }*/

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

        public string TextInDetails
        {
            get
            {
                if (textInDetails != null)
                {
                    return textInDetails;
                }
                else
                {
                    return (
                        (CleanUpNameInDetails(FirstName) + " " + CleanUpNameInDetails(LastName)).Trim() + "\r\n"
                        + CleanUpAddressInDetails(Address)
                        //+ CleanUpHomePhoneInDetails(HomePhone)
                        //+ CleanUpMobilePhoneInDetails(MobilePhone)
                        //+ CleanUpWorkPhoneInDetails(WorkPhone)
                        //+ "\r\n"
                        + CleanUpPhoneInDetails(HomePhone, MobilePhone, WorkPhone)
                        + CleanUpTextInDetails(Email)
                        + CleanUpTextInDetails(Email2)
                        + CleanUpTextInDetails(Email3))
                        .Trim();
                }
            }
            set
            {
                textInDetails = value;
            }
        }

        private string CleanUpPhoneInDetails(string homePhone, string mobilePhone, string workPhone)
        {
            // Создаем список для хранения непустых телефонов
            var phones = new List<string>();

            // Проверяем и добавляем домашний телефон
            if (!string.IsNullOrEmpty(homePhone))
            {
                phones.Add("H: " + homePhone);
            }

            // Проверяем и добавляем мобильный телефон
            if (!string.IsNullOrEmpty(mobilePhone))
            {
                phones.Add("M: " + mobilePhone);
            }

            // Проверяем и добавляем рабочий телефон
            if (!string.IsNullOrEmpty(workPhone))
            {
                phones.Add("W: " + workPhone);
            }

            // Если есть телефоны, возвращаем их с переносами строк
            if (phones.Count > 0)
            {
                return string.Join("\r\n", phones) + "\r\n\r\n";
            }

            // Если телефонов нет, возвращаем пустую строку
            return string.Empty;
        }

        private string CleanUpAddressInDetails(string address)
        {
            if (address == null || address == "")
            {
                return "\r\n";
            }
            return address + "\r\n\r\n";
        }

        private string CleanUpNameInDetails(string name)
        {
            if (name == null || name == "")
            {
                return "";
            }
            return name;
        }

        private string CleanUpTextInDetails(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text + "\r\n";
        }

        /*private string CleanUpWorkPhoneInDetails(string workPhone)
        {
            if (workPhone == null || workPhone == "")
            {
                return "";
            }
            return "W: " + workPhone + "\r\n";
        }

        private string CleanUpMobilePhoneInDetails(string mobilePhone)
        {
            if (mobilePhone == null || mobilePhone == "")
            {
                return "";
            }
            return "M: " + mobilePhone + "\r\n";
        }

        private string CleanUpHomePhoneInDetails(string homePhone)
        {
            if (homePhone == null || homePhone == "")
            {
                return "";
            }
            return "H: " + homePhone + "\r\n";
        }*/

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
