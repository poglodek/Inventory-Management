using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Inventory_Management.Services
{
    public class ValidationServices : IValidationServices
    {
        public bool IsEmailValid(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return mail.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public bool IsPhoneNumberValid(int phoneNumber)
        {
            var regex = new Regex(@"[0-9]{9}$");
            if(regex.IsMatch(phoneNumber.ToString())) return true;
            return false;
        }
    }
}
