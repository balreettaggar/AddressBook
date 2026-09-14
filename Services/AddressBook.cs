using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookApp.Model;
using AddressBookApp.Validation;

namespace AddressBookApp.Services
{

    public class AddressBook
    {
        public List<Contact> contacts;

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

        public void EditContact(string firstname, string lastname, string city)
        {
            Contact? contact = contacts.FirstOrDefault(c => c.FirstName==firstname && c.LastName==lastname);
            if (contact == null) 
            {
                Console.WriteLine("Contact not found");
                return;
            }

            if(!string.IsNullOrEmpty(city))
            {
                ContactValidator cv = new ContactValidator();
                if (cv.IsValidAddressPart(city))
                {
                    contact.City = city;
                }
            }
        }

        public void DeleteContact(string firstname, string lastname)
        {
            Contact? contact = contacts.FirstOrDefault(c=>c.FirstName==firstname &&c.LastName==lastname);
            if(contact == null)
            {
                Console.WriteLine("Contact not found!");
                return;
            }
            contacts.Remove(contact);
        }
    }
}
