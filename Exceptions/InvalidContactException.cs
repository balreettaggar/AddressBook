using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookApp.Exceptions
{
    public class InvalidContactException : Exception
    {
        public InvalidContactException(string message) : base(message) { }
    }
}
