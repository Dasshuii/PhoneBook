using System;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using var db = new PhoneBookContext();

            Console.WriteLine("Inserting new contact");
            db.Add(new Contact
            {
                Name = "Chayotita",
                Email = "chayotita@gmail.com",
                PhoneNumber = "+50611111111"
            });
            await db.SaveChangesAsync();

            Console.WriteLine("Querying for a contact");
            var contact = await db.Contacts
                .OrderBy(c => c.Id)
                .FirstAsync();
            Console.WriteLine(contact);
        }
    }
}