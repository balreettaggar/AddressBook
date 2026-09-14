using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookApp.Services
{
    public class AddressBookMain
    {
        public List<AddressBook> books;

        public AddressBookMain()
        {
            books = new List<AddressBook>();
        }

        public void AddAddressBook(AddressBook address)
        {
            books.Add(address);
        }

        public int CountContacts()
        {

            int count = books.Sum(b => b.contacts.Count);
            return count;
        }
    }
}
