namespace PhoneBook;

public class Menu
{
    public static void PrintMainMenu()
    {
        Console.WriteLine("=== Phone Book ===");
        Console.WriteLine("[1] Contacts");
        Console.WriteLine("[2] Add Contact");
        Console.WriteLine("[3] Update Contact");
        Console.WriteLine("[4] Delete Contact");
        Console.WriteLine("[0] Exit");
    }
}