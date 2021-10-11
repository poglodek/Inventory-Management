using System.Net.Mail;
using System.Text.RegularExpressions;

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
            if (regex.IsMatch(phoneNumber.ToString())) return true;
            return false;
        }

        public bool IsNIPValid(int nip)
        {
            var regex = new Regex(@"^[0-9]{10}$");
            if (regex.IsMatch(nip.ToString())) return true;
            return false;
        }
    }
}
