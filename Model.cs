using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PhoneBook;

public class PhoneBookContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=localhost;Database=PhoneBook;Trusted_Connection=True;TrustServerCertificate=True");
}

public class Contact
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public override string ToString() => $"{Id} - {Name} - {Email} - {PhoneNumber}";
}