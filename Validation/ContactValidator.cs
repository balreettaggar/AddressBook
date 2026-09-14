using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AddressBookApp.Model;
using AddressBookApp.Exceptions;

namespace AddressBookApp.Validation
{
    public class ContactValidator
    {
        public bool IsValidName(string name)
        {
            string pattern = "^[A-Z][a-z]{2,}$";
            bool result = Regex.IsMatch(name, pattern);
            return result;
        }

        public bool IsValidAddressPart(string email)
        {
            return Regex.IsMatch(email, "^.{4,}");
        }

        public bool isValidZip(string zip)
        {
            return Regex.IsMatch(zip, "^[0-9]{6}");
        }

        public bool isValidPhone(string phone)
        {
            return Regex.IsMatch(phone, "[0-9]{10}");
        }
        public bool IsValidEmail(string email)
        {
            string pattern = "^[A-Za-z0-9._+-%]+@[A-Za-z0-9.-]";
            return true;
        }

        public void Validate(Contact c)
        {
            if(!IsValidName(c.FirstName))
            {
                throw new InvalidContactException($"Full name must start with a capital letter and be at least 3 characters");
            }

            if (!IsValidAddressPart(c.Address))
            {
                throw new InvalidContactException($"Address must be atleast 4 characters");
            }

            if (!IsValidName(c.Zip))
            {
                throw new InvalidContactException($"Zip must be atleast 6 digits");
            }

            if (!IsValidName(c.PhoneNumber))
            {
                throw new InvalidContactException($"Phone Number must be atleast 10 digits");
            }

            if (!IsValidName(c.Email))
            {
                throw new InvalidContactException($"Email must contain only uppercases, lowercases, digits, special symbols" +
                    $"like +, -, _, %, .");
            }
        }

    }
}
