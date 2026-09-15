// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using AddressBookApp.Model;
using AddressBookApp.Validation;
using AddressBookApp.Exceptions;
using AddressBookApp.Services;
using System.Text;

Contact contact1 = new Contact("John", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
//Console.WriteLine(contact1.ToString());

Contact contact2 = new Contact("Joe", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
Contact contact3 = new Contact("Balreet", "Singh", "Dharmgarh", "Sunam", "Punjab", "148028", "7888802771", "balreetttaggar@mail.com");

Contact contact4 = new Contact("Harshdeep", "Singh", "House No. 426", "Ambala", "Haryana", "134003", "9729031829", "harshdeepsingh10d@mail.com");

Contact contact5 = new Contact("Vishvas", "Vaglay", "House no. 2", "Yamunanagar", "Haryana", "135001", "9991377488", "vishvayvaglay@gmail.com");


//ContactValidator validator = new ContactValidator();
//try
//{
//    validator.Validate(contact2);
//} catch(InvalidContactException e)
//{
//    Console.WriteLine(e.Message);
//}

//AddressBook ab = new AddressBook();
//ab.AddContact(contact1);
//ab.AddContact(contact2);
//ab.PrintAll();
//Console.WriteLine("Enter your first name");
//string firstname = Console.ReadLine();
//Console.WriteLine("Enter your last name");
//string lastname = Console.ReadLine();
//Console.WriteLine("Enter your updated city : ");
//string city = Console.ReadLine();
//ab.EditContact(firstname, lastname, city);

//ab.DeleteContact(firstname, lastname);
//ab.PrintAll();

//AddressBook ab = new AddressBook();
//ab.AddContact(contact1);
//ab.AddContact(contact2);

//AddressBook ab1 = new AddressBook();
//ab1.AddContact(contact3);
//ab1.AddContact(contact4);

//AddressBook ab2 = new AddressBook();
//ab2.AddContact(contact5);

//AddressBookMain abm = new AddressBookMain();
//abm.AddAddressBook(ab);
//abm.AddAddressBook(ab1);
//abm.AddAddressBook(ab2);
//Console.WriteLine("The number of total contacts across different address books " + abm.CountContacts());

//AddressBook ab = new AddressBook();
//ab.AddContact(contact1);
//ab.AddContact(contact2);
//ab.PrintAll();

AddressBook ab = new AddressBook();
ab.AddContact(contact1);
ab.AddContact(contact2);
AddressBook ab1 = new AddressBook();
ab1.AddContact(contact3);
AddressBook ab2 = new AddressBook();
ab2.AddContact(contact4);
ab2.AddContact(contact5);

AddressBookMain abm = new AddressBookMain();
abm.AddAddressBook(ab);
abm.AddAddressBook(ab1);
abm.AddAddressBook(ab2);

abm.SearchByCity("Pune");