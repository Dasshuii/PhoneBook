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

    public async Task UpdateContact(int id, Contact contact)
    {
        var contactToUpdate = _pbContext.Contacts.Find(id);
        if (contactToUpdate != null)
        {
            contactToUpdate.Name = contact.Name;
            contactToUpdate.Email = contact.Email;
            contactToUpdate.PhoneNumber = contact.PhoneNumber;
        }

        await _pbContext.SaveChangesAsync();
    }

    public async Task DeleteContact(int id)
    {
        var contactToDelete = _pbContext.Contacts.Find(id);
        if (contactToDelete != null)
            _pbContext.Remove(contactToDelete);
        await _pbContext.SaveChangesAsync();
    }
}