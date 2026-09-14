using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookApp.Model;

namespace AddressBookApp.Services
{
    public class AddressBook
    {
        private List<Contact> contacts;

        public AddressBook()
        {
            contacts = new List<Contact>();
        }

        public void AddContact(Contact c)
        {
            contacts.Add(c);
        }

        public void PrintAll()
        {
            foreach (Contact c in contacts)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }

}
