using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using PhoneBook.Model;
using PhoneBook.Service;
using PhoneBook.Util;

namespace PhoneBook;

public class Program
{
    public static async Task Main()
    {
        var db = new PhoneBookContext();
        var phoneBookService = new PhoneBookService(db);

        bool exit = false;
        while (!exit)
        {
            Menu.PrintMainMenu();
            int opt = Input.GetIntegerInput("Opt?");

            switch (opt)
            {
                case 1:
                    await ListContacts(phoneBookService);
                    break;
                case 2:
                    await AddContact(phoneBookService);
                    break;
                case 3:
                    await UpdateContact(phoneBookService);
                    break;
                case 4:
                    await DeleteContact(phoneBookService);
                    break;
                case 0:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again");
                    break;
            }
        }
    }

    public static async Task ListContacts(PhoneBookService phoneBookService)
    {
        var contacts = await phoneBookService.GetAllContacts();
        foreach (var registry in contacts)
            Console.WriteLine(registry);
    }

    public static async Task AddContact(PhoneBookService phoneBookService)
    {
        var contact = CreateContact();
        await phoneBookService.AddContact(contact);
    }

    public static Contact CreateContact()
    {
        string name = Input.GetUserInput("Name?");
        string email = Input.GetEmailInput("Email? (example@mail.com)");
        string phoneNumber = Input.GetPhoneInput("Phone Number? (+506 XXXX-XXXX)");

        return new Contact
        {
            Name = name,
            Email = email,
            PhoneNumber = phoneNumber
        };
    }

    public static async Task UpdateContact(PhoneBookService phoneBookService)
    {
        await ListContacts(phoneBookService);
        int id = Input.GetIntegerInput("Contact Id?");

        var updatedContact = CreateContact();
        await phoneBookService.UpdateContact(id, updatedContact);
    }

    public static async Task DeleteContact(PhoneBookService phoneBookService)
    {
        await ListContacts(phoneBookService);
        int id = Input.GetIntegerInput("Contact Id?");
        await phoneBookService.DeleteContact(id);
    }
}