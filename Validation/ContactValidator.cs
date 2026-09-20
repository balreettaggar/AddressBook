using System.Text.RegularExpressions;
using AddressBookApp.Exceptions;
using AddressBookApp.Model;

namespace AddressBookApp.Validation
{
    public class ContactValidator
    {
        public bool IsValidName(string name)
        {
            string pattern = "^[A-Z][a-zA-Z]{2,}$";
            return Regex.IsMatch(name, pattern);
        }

        public bool IsValidAddressPart(string value)
        {
            string pattern = "^.{4,}$";
            return Regex.IsMatch(value, pattern);
        }

        public bool IsValidZip(string zip)
        {
            string pattern = "^[0-9]{6}$";
            return Regex.IsMatch(zip, pattern);
        }

        public bool IsValidPhone(string phone)
        {
            string pattern = "^[0-9]{10}$";
            return Regex.IsMatch(phone, pattern);
        }

        public bool IsValidEmail(string email)
        {
            string pattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        public void Validate(Contact contact)
        {
            if (!IsValidName(contact.FirstName))
            {
                throw new InvalidContactException(
                    "First name must start with a capital letter and be at least 3 characters.");
            }

            if (!IsValidName(contact.LastName))
            {
                throw new InvalidContactException(
                    "Last name must start with a capital letter and be at least 3 characters.");
            }

            if (!IsValidAddressPart(contact.Address))
            {
                throw new InvalidContactException(
                    "Address must be at least 4 characters.");
            }

            if (!IsValidAddressPart(contact.City))
            {
                throw new InvalidContactException(
                    "City must be at least 4 characters.");
            }

            if (!IsValidAddressPart(contact.State))
            {
                throw new InvalidContactException(
                    "State must be at least 4 characters.");
            }

            if (!IsValidZip(contact.Zip))
            {
                throw new InvalidContactException(
                    "Zip must contain exactly 6 digits.");
            }

            if (!IsValidPhone(contact.PhoneNumber))
            {
                throw new InvalidContactException(
                    "Phone number must contain exactly 10 digits.");
            }

            if (!IsValidEmail(contact.Email))
            {
                throw new InvalidContactException(
                    "Email must be in a valid email format.");
            }
        }
    }
}
