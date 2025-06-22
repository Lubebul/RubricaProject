using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rubrica.Application.Interfaces;
using Rubrica.Domain.Class;
using Rubrica.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Rubrica.Infrastructure.Repository
{
    public class ContactRepository : IContactRepository
    {

        private readonly RubricaDbContext _context;
        private readonly ILogger<ContactRepository> _log;

        public ContactRepository(RubricaDbContext context, ILogger<ContactRepository> logger)
        {
            _context = context;
            _log = logger;
        }

        public async Task AddAsync(Contact contatto)
        {
            await _context.AddAsync(contatto);
            await _context.SaveChangesAsync();
        }

        public async Task<Contact?> DeleteAsync(Guid id)
        {
            var toRemove = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);

            _log.LogInformation($"Going to Remove {{{toRemove ?? null}}}");

            var toReturn = toRemove != null ? _context.Contacts.Remove(toRemove)?.Entity : null;

            await _context.SaveChangesAsync();

            return toReturn;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllCitiesAsync()
        {

            return await _context.City.Select(x => x.Name).ToListAsync();

        }

        public async Task<Contact?> GetByIdAsync(Guid id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Contact?>> GetByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Given name is null or empty");

            return await _context.Contacts.Where(x => x.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Contact?>> GetBySurnameAsync(string surname)
        {
            if (string.IsNullOrEmpty(surname)) throw new ArgumentNullException("Given surname is null or empty");

            return await _context.Contacts.Where(x => x.Surname == surname).ToListAsync();
        }

        public async Task<IEnumerable<Contact?>> Search(string name, string surname, string email, string phoneNumber)
        {
            var query = _context.Contacts.AsQueryable();


            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name.Contains(name));

            if (!string.IsNullOrEmpty(surname))
                query = query.Where(x => x.Surname.Contains(surname));

            if (!string.IsNullOrEmpty(email))
                query = query.Where(x => x.Email.Contains(email));

            if (!string.IsNullOrEmpty(phoneNumber))
                query = query.Where(x => x.PhoneNumber == name);

            return await query.ToListAsync();

        }

        public async Task<Contact?> UpdateAsync(Contact contatto)
        {

            if (contatto == null)
                throw new ArgumentNullException("Contact to update is null");

            var toUpdate = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == contatto.Id);

            if (toUpdate == null)
                throw new ArgumentException($"Can't find Contanct with id {contatto.Id}");

            toUpdate.Name = contatto.Name;
            toUpdate.Surname = contatto.Surname;
            toUpdate.BirthDate = contatto.BirthDate;
            toUpdate.PhoneNumber = contatto.PhoneNumber;
            toUpdate.Gender = contatto.Gender;
            toUpdate.City = contatto.City;
            toUpdate.Email = contatto.Email;

            await _context.SaveChangesAsync();

            return toUpdate;
            
        }
    }
}
