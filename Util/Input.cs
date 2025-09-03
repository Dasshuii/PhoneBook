using System.Text.RegularExpressions;

namespace PhoneBook.Util;

public class Input
{
    public static string GetUserInput(string prompt)
    {
        Console.WriteLine(prompt);
        string? input = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(input))
            input = Console.ReadLine();
        return input.Trim();
    }

    public static int GetIntegerInput(string prompt)
    {
        string input = GetUserInput(prompt);
        int number;

        while (!int.TryParse(input, out number))
            input = GetUserInput(prompt);
        return number;
    }

    public static string GetEmailInput(string prompt)
    {
        string email = GetUserInput(prompt);
        while (!ValidEmail(email))
            email = GetUserInput(prompt);
        return email;
    }

    public static string GetPhoneInput(string prompt)
    {
        string phone = GetUserInput(prompt);
        while (!ValidPhone(phone))
            phone = GetUserInput(prompt);
        return phone;
    }

    private static bool ValidEmail(string email)
    {
        string pattern = @"^[a-z]+@[a-z]+.com$";
        return Regex.IsMatch(email, pattern);
    }

    private static bool ValidPhone(string phone)
    {
        string pattern = @"^\+506\d{4}\d{4}$";
        return Regex.IsMatch(phone, pattern);
    }
}