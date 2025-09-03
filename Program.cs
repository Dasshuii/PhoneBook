using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using PhoneBook.Model;
using PhoneBook.Service;
using PhoneBook.Util;

namespace PhoneBook;

public class Program
{
    public static void Main()
    {
        string phoneNumber = Input.GetPhoneInput("Phone Number? (+506XXXX-XXXX)");
        // var db = new PhoneBookContext();
        // var phoneBookService = new PhoneBookService(db);

        // bool exit = false;
        // while (!exit)
        // {
        //     Menu.PrintMainMenu();
        //     int opt = Input.GetIntegerInput("Opt?");

        //     switch (opt)
        //     {
        //         case 1:
        //             var contacts = await phoneBookService.GetAllContacts();
        //             foreach (var registry in contacts)
        //                 Console.WriteLine(registry);
        //             break;
        //         case 2:
        //             var contact = GetContact();
        //             await phoneBookService.AddContact(contact);
        //             break;
        //         case 3:
        //             break;
        //         case 4:
        //             break;
        //         case 0:
        //             exit = true;
        //             break;
        //         default:
        //             Console.WriteLine("Invalid option. Try again");
        //             break;
        //     }
        // }

    }

    public static Contact GetContact()
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
}