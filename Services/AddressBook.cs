using System;
using System.Collections.Generic;
using System.Linq;
using AddressBookApp.Model;
using AddressBookApp.Validation;

namespace AddressBookApp.Services
{
    public class AddressBook
    {
        public List<Contact> contacts = new List<Contact>();

        public IReadOnlyList<Contact> Contacts => contacts;

        public void AddContact(Contact contact)
        {
            ContactValidator validator = new ContactValidator();
            validator.Validate(contact);

            bool exists = contacts.Any(c =>
                c.FirstName == contact.FirstName &&
                c.LastName == contact.LastName);

            if (exists)
            {
                Console.WriteLine($"Contact {contact.FirstName} {contact.LastName} already exists. Duplicate not added.");
                return;
            }

            contacts.Add(contact);
        }

        public void PrintAll()
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void EditContact(string firstName, string lastName, string city)
        {
            Contact contact = contacts.FirstOrDefault(c =>
                c.FirstName == firstName && c.LastName == lastName);

            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                ContactValidator validator = new ContactValidator();

                if (validator.IsValidAddressPart(city))
                {
                    contact.City = city;
                    Console.WriteLine("Contact updated.");
                }
                else
                {
                    Console.WriteLine("Invalid city.");
                }
            }
        }

        public void DeleteContact(string firstName, string lastName)
        {
            Contact contact = contacts.FirstOrDefault(c =>
                c.FirstName == firstName && c.LastName == lastName);

            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            contacts.Remove(contact);
            Console.WriteLine("Contact deleted.");
        }
    }
}