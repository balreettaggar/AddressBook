using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookApp.Services
{
    public class AddressBookMain
    {
        public List<AddressBook> books = new List<AddressBook>();

        public void AddAddressBook(AddressBook addressBook)
        {
            books.Add(addressBook);
        }

        public int CountContacts()
        {
            return books.Sum(book => book.Contacts.Count);
        }

        public void SearchByCity(string city)
        {
            var matchedEntries = books
                .SelectMany(book => book.Contacts)
                .Where(contact => contact.City.Equals(city, StringComparison.OrdinalIgnoreCase));

            foreach (var entry in matchedEntries)
            {
                Console.WriteLine(entry.ToString());
            }
        }

        public void SearchByState(string state)
        {
            var matchedEntries = books
                .SelectMany(book => book.Contacts)
                .Where(contact => contact.State.Equals(state, StringComparison.OrdinalIgnoreCase));

            foreach (var entry in matchedEntries)
            {
                Console.WriteLine(entry.ToString());
            }
        }

        public void ViewCityState()
        {
            var contacts = books.SelectMany(book => book.Contacts);

            var groupedCities = contacts.GroupBy(contact => contact.City);

            Console.WriteLine("--Grouped By Cities--");

            foreach (var group in groupedCities)
            {
                Console.WriteLine(group.Key);

                foreach (var contact in group)
                {
                    Console.WriteLine(contact.ToString());
                }
            }

            var groupedStates = contacts.GroupBy(contact => contact.State);

            Console.WriteLine("--Grouped By States--");

            foreach (var group in groupedStates)
            {
                Console.WriteLine(group.Key);

                foreach (var contact in group)
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }

        public void CountCityStates()
        {
            var contacts = books.SelectMany(book => book.Contacts);

            var groupedCities = contacts.GroupBy(contact => contact.City);

            Console.WriteLine("By City");

            foreach (var group in groupedCities)
            {
                Console.WriteLine(group.Key + " = " + group.Count());
            }

            var groupedStates = contacts.GroupBy(contact => contact.State);

            Console.WriteLine("By State");

            foreach (var group in groupedStates)
            {
                Console.WriteLine(group.Key + " = " + group.Count());
            }
        }

        public void SortContactsAlphabetically()
        {
            var sortedContacts = books
                .SelectMany(book => book.Contacts)
                .OrderBy(contact => contact.FirstName)
                .ThenBy(contact => contact.LastName);

            foreach (var contact in sortedContacts)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void SortByCity()
        {
            var sortedCities = books
                .SelectMany(book => book.Contacts)
                .OrderBy(contact => contact.City);

            foreach (var contact in sortedCities)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void SortByState()
        {
            var sortedStates = books
                .SelectMany(book => book.Contacts)
                .OrderBy(contact => contact.State);

            foreach (var contact in sortedStates)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void SortByZip()
        {
            var sortedZip = books
                .SelectMany(book => book.Contacts)
                .OrderBy(contact => contact.Zip);

            foreach (var contact in sortedZip)
            {
                Console.WriteLine(contact.ToString());
            }
        }
    }
}