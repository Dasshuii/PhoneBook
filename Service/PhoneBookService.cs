using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Model;

namespace PhoneBook.Service;

public class PhoneBookService(PhoneBookContext pbContext)
{
    private readonly PhoneBookContext _pbContext = pbContext;

    public async Task<List<Contact>> GetAllContacts() => await _pbContext.Contacts.ToListAsync(); 

    public async Task AddContact(Contact contact)
    {
        _pbContext.Add(contact);
        await _pbContext.SaveChangesAsync();
    }
}