using System.Collections.Generic;
using System.Linq;
using ContactsService.Models;
using ContactsService.Contexts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContactsService.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        ContactsDbContext _context;
        public ContactsRepository(ContactsDbContext context)
        {
            _context = context;
        }       

        public async Task Add(Contact item)
        {            
            await _context.Contacts.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public bool CheckValidUserKey(string reqkey)
        {
            var userkeyList = _context.UserKeys.ToList();

            if (userkeyList.Exists(s=>s.UserKey == reqkey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Contact> Find(string key)
        {
            return await _context.Contacts
                .Where(e => e.PhoneNumber.Equals(key))
                .SingleOrDefaultAsync();
        }       

        public async Task Remove(string Id)
        {
            var itemToRemove = await _context.Contacts.SingleOrDefaultAsync(r => r.PhoneNumber == Id);
            if (itemToRemove != null)
            {
                _context.Contacts.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Contact item)
        {            
            var itemToUpdate = await _context.Contacts.SingleOrDefaultAsync(r => r.PhoneNumber == item.PhoneNumber);
            if (itemToUpdate != null)
            {
                itemToUpdate.FirstName = item.FirstName;
                itemToUpdate.LastName = item.LastName;
                itemToUpdate.PhoneNumber = item.PhoneNumber;
                itemToUpdate.BirthDate = item.BirthDate;
                itemToUpdate.Gender = item.Gender;
                itemToUpdate.Email = item.Email;
                itemToUpdate.Status = item.Status;
                itemToUpdate.Address = item.Address;
                await _context.SaveChangesAsync();
            }
        }
    }
}