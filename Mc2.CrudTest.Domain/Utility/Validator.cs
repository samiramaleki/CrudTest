using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Utility
{
    public static class Validator
    {

        static Regex ValidEmailRegex = CreateValidEmailRegex();
        static PhoneNumberUtil _phoneNumberUtile;

        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        internal static bool EmailIsValid(string emailAddress)
        {
            bool isValid = ValidEmailRegex.IsMatch(emailAddress);

            return isValid;
        }

        public static bool PhoneNumberIsValid(string phoneNumber)
        {
            _phoneNumberUtile = PhoneNumberUtil.GetInstance();
           var phone = _phoneNumberUtile.Parse($"+{phoneNumber}",null );
            
            if (!_phoneNumberUtile.IsValidNumber(phone))
                return false;
            else return true;
        }

        public static bool BankAccountNumberIsValid(string bankAccountNumber)
        {
            if (bankAccountNumber.Length != 16)
                return false;
            else return true;
        }
    }  
}
