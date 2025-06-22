using System.ComponentModel.DataAnnotations;

namespace Rubrica.API.Models.Dto
{
    public class SearchContactDto
    {
        [MaxLength(30, ErrorMessage = "Name can't be longer than 30")]
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "Email format not valid")]
        [MaxLength(100)]
        public string? Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [MaxLength(30, ErrorMessage = "Surname can't be longer than 30")]
        public string? Surname { get; set; }
    }
}
