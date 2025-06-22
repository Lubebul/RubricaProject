using Rubrica.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Application.Interfaces
{
    public interface IContactRepository
    {
        //CRUD Ops

        public Task<IEnumerable<Contact>> GetAllAsync();
        public Task<Contact?> GetByIdAsync(Guid id);
        public Task<IEnumerable<Contact?>> Search(string name, string surname, string email, string phoneNumber);
        public Task<IEnumerable<Contact?>> GetByNameAsync(string name);
        public Task<IEnumerable<Contact?>> GetBySurnameAsync(string surname);
        public Task AddAsync(Contact contatto);
        public Task<Contact?> UpdateAsync(Contact contatto);
        public Task<Contact?> DeleteAsync(Guid id);

        // Retrive City

        public Task<IEnumerable<string>> GetAllCitiesAsync();

    }
}
