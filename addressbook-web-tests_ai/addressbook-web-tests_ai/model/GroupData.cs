﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [LinqToDB.Mapping.Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData> //Для сравнения
    {
        public GroupData() { }

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

        [LinqToDB.Mapping.Column(Name = "group_name")]
        public string Name { get; set; }

        [LinqToDB.Mapping.Column(Name = "group_header")]
        public string Header { get; set; }

        [LinqToDB.Mapping.Column(Name = "group_footer")]
        public string Footer { get; set; }

        [LinqToDB.Mapping.Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll() //метод получения полного списка групп
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }
    
        public List<ContactData> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR/*.Where(p => p.ContactId == Id && p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00")*/
                        select c).Distinct().ToList();
            }
        }
    }
}
