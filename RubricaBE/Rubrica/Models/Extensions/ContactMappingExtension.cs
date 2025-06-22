using Rubrica.API.Models.Dto;
using Rubrica.Domain.Class;

namespace Rubrica.API.Models.Extensions
{
    public static class ContactMappingExtension
    {

        public static ContactDto ToDto(this Contact contact)
        {
            return new ContactDto
            {
                BirthDate = contact.BirthDate,
                City = contact.City,
                Email = contact.Email,
                Gender = contact.Gender,
                Id = contact.Id,
                Name = contact.Name,
                PhoneNumber = contact.PhoneNumber,
                Surname = contact.Surname
            };
        }

        public static Contact ToEntity(this CreateContactDto contact)
        {

            return new Contact
            {
                Id = Guid.NewGuid(),
                Name = contact.Name,
                Surname = contact.Surname,
                PhoneNumber = contact.PhoneNumber,
                BirthDate = contact.BirthDate,
                City = contact.City,
                Email = contact.Email,
                Gender = contact.Gender
            };

        }

        public static Contact ToEntity(this ContactDto contact) {

            return new Contact
            {
                Id = contact.Id,
                Name = contact.Name,
                Surname = contact.Surname,
                PhoneNumber = contact.PhoneNumber,
                BirthDate = contact.BirthDate,
                City = contact.City,
                Email = contact.Email,
                Gender = contact.Gender
            };

        }


        public static Contact ToEntity(this UpdateContactDto contact)
        {
            return new Contact
            {
                Id = contact.Id,
                Name = contact.Name,
                Surname = contact.Surname,
                PhoneNumber = contact.PhoneNumber,
                BirthDate = contact.BirthDate,
                City = contact.City,
                Email = contact.Email
            };
        }


    }

}
