using Rubrica.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rubrica.API.Models.Dto
{
    public class CreateContactDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30, ErrorMessage = "Name can't be longer than 30")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [MaxLength(30, ErrorMessage = "Surname can't be longer than 30")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email format not valid")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Phone(ErrorMessage =" Wrong phone number format")]
        public string? PhoneNumber { get; set; }

        public string? City { get; set; }

        public DateOnly? BirthDate { get; set; }
    }
}
