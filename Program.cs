using AddressBookApp.Model;
using AddressBookApp.Validation;
using AddressBookApp.Exceptions;
using AddressBookApp.Services;

AddressBook addressBook = new AddressBook();
AddressBookMain addressBookMain = new AddressBookMain();
addressBookMain.AddAddressBook(addressBook);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("===== ADDRESS BOOK MENU =====");
    Console.WriteLine("1. Add Contact");
    Console.WriteLine("2. Edit Contact");
    Console.WriteLine("3. Delete Contact");
    Console.WriteLine("4. Show All Contacts");
    Console.WriteLine("5. Total Contact Count");
    Console.WriteLine("6. Search by City");
    Console.WriteLine("7. Search by State");
    Console.WriteLine("8. View by City/State");
    Console.WriteLine("9. Count by City/State");
    Console.WriteLine("10. Sort by Name");
    Console.WriteLine("11. Sort by City / State / Zip");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your choice: ");

    var choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Write("Enter first name: ");
        var firstName = Console.ReadLine();

        Console.Write("Enter last name: ");
        var lastName = Console.ReadLine();

        Console.Write("Enter address: ");
        var address = Console.ReadLine();

        Console.Write("Enter city: ");
        var city = Console.ReadLine();

        Console.Write("Enter state: ");
        var state = Console.ReadLine();

        Console.Write("Enter zip: ");
        var zip = Console.ReadLine();

        Console.Write("Enter phone number: ");
        var phoneNumber = Console.ReadLine();

        Console.Write("Enter email: ");
        var email = Console.ReadLine();

        Contact contact = new Contact(
            firstName,
            lastName,
            address,
            city,
            state,
            zip,
            phoneNumber,
            email);

        try
        {
            ContactValidator validator = new ContactValidator();
            validator.Validate(contact);

            bool contactExists = addressBook.contacts.Any(existingContact =>
                existingContact.FirstName == contact.FirstName &&
                existingContact.LastName == contact.LastName);

            if (contactExists)
            {
                Console.WriteLine("Contact already exists. Duplicate not added.");
            }
            else
            {
                addressBook.AddContact(contact);
                Console.WriteLine("Contact added successfully.");
            }
        }
        catch (InvalidContactException exception)
        {
            Console.WriteLine("Error: " + exception.Message);
        }
    }
    else if (choice == "2")
    {
        Console.Write("Enter first name to edit: ");
        var firstName = Console.ReadLine();

        Console.Write("Enter last name to edit: ");
        var lastName = Console.ReadLine();

        Console.Write("Enter new city (or press Enter to keep): ");
        var city = Console.ReadLine();

        addressBook.EditContact(firstName, lastName, city);
        Console.WriteLine("Contact updated.");
    }
    else if (choice == "3")
    {
        Console.Write("Enter first name to delete: ");
        var firstName = Console.ReadLine();

        Console.Write("Enter last name to delete: ");
        var lastName = Console.ReadLine();

        addressBook.DeleteContact(firstName, lastName);
    }
    else if (choice == "4")
    {
        addressBook.PrintAll();
    }
    else if (choice == "5")
    {
        Console.WriteLine("Total contacts: " + addressBookMain.CountContacts());
    }
    else if (choice == "6")
    {
        Console.Write("Enter city to search: ");
        var city = Console.ReadLine();
        addressBookMain.SearchByCity(city);
    }
    else if (choice == "7")
    {
        Console.Write("Enter state to search: ");
        var state = Console.ReadLine();

        var contacts = addressBookMain.books
            .SelectMany(book => book.contacts)
            .Where(contact => contact.State.Equals(state, StringComparison.OrdinalIgnoreCase));

        foreach (Contact contact in contacts)
        {
            Console.WriteLine(contact.ToString());
        }
    }
    else if (choice == "8")
    {
        addressBookMain.ViewCityState();
    }
    else if (choice == "9")
    {
        addressBookMain.CountCityStates();
    }
    else if (choice == "10")
    {
        addressBookMain.SortContactsAlphabetically();
    }
    else if (choice == "11")
    {
        Console.WriteLine("1. Sort by City");
        Console.WriteLine("2. Sort by State");
        Console.WriteLine("3. Sort by Zip");
        Console.Write("Enter your choice: ");

        var sortChoice = Console.ReadLine();

        if (sortChoice == "1")
        {
            addressBookMain.SortByCity();
        }
        else if (sortChoice == "2")
        {
            addressBookMain.SortByState();
        }
        else if (sortChoice == "3")
        {
            addressBookMain.SortByZip();
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }
    else if (choice == "0")
    {
        Console.WriteLine("Thank you for using Address Book.");
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice. Please try again.");
    }
}