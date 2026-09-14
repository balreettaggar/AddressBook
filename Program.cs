// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using AddressBookApp.Model;
using AddressBookApp.Validation;
using AddressBookApp.Exceptions;
using System.Text;

Contact contact1 = new Contact("John", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
//Console.WriteLine(contact1.ToString());

Contact contact2 = new Contact("Jo", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");

ContactValidator validator = new ContactValidator();
try
{
    validator.Validate(contact2);
} catch(InvalidContactException e)
{
    Console.WriteLine(e.Message);
}
