// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using AddressBookApp.Model;
using AddressBookApp.Validation;
using AddressBookApp.Exceptions;
using AddressBookApp.Services;
using System.Text;

Contact contact1 = new Contact("John", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
//Console.WriteLine(contact1.ToString());

Contact contact2 = new Contact("Jo", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");

//ContactValidator validator = new ContactValidator();
//try
//{
//    validator.Validate(contact2);
//} catch(InvalidContactException e)
//{
//    Console.WriteLine(e.Message);
//}

AddressBook ab = new AddressBook();
ab.AddContact(contact1);
ab.AddContact(contact2);
ab.PrintAll();
Console.WriteLine("Enter your first name");
string firstname = Console.ReadLine();
Console.WriteLine("Enter your last name");
string lastname = Console.ReadLine();
//Console.WriteLine("Enter your updated city : ");
//string city = Console.ReadLine();
//ab.EditContact(firstname, lastname, city);

ab.DeleteContact(firstname, lastname);
ab.PrintAll();