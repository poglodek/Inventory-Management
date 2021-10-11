namespace Inventory_Management.Services
{
    public interface IValidationServices
    {
        bool IsEmailValid(string email);
        bool IsPhoneNumberValid(int phoneNumber);
        bool IsNIPValid(int nip);
    }
}