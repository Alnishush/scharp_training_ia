using System;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData> //Для сравнения
    {
        public bool Equals(GroupData other) //Реализует сравнения
        {
            if (Object.ReferenceEquals(other, null)) //Если тот объект с которым сравниваем это null
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other)) //Если объект один и тот же
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode() // Сравнение элементов через хеш
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name
                + "\nheader=" + Header
                + "\nfooter=" + Footer;
        }

        public int CompareTo(GroupData other)
        {   
            if (Object.ReferenceEquals (other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public GroupData(string name)
        {
            Name = name;
        }

        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }


        public string Name { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public string Id { get; set; }
    }
}
