using Rubrica.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Domain.Class
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? City { get; set; }

        public DateOnly? BirthDate { get; set; }

        public Contact() { }

        public Contact(Guid id, string name, string surname, Gender gender, string email)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Gender = gender;
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        public Contact(Guid id, string name, string cognome, Gender gender, string email, string? phoneNumber, string? city, DateOnly? birthDate)
            : this(id, name, cognome, gender, email)
        {
            PhoneNumber = phoneNumber ?? string.Empty;
            City = city ?? string.Empty;
            BirthDate = birthDate;
        }

    }
}
