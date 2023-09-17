using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebCRUD
{
    [Index(nameof(Person.EmailAddress), IsUnique = true)]
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[^0-9]*$", ErrorMessage = "The field should not contain numbers.")]
        public string FirstName { get; set; } = string.Empty;
        [RegularExpression("^[^0-9]*$", ErrorMessage = "The field should not contain numbers.")]
        public string LastName { get; set; } = string.Empty;
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        public string NotesField { get; set; } = string.Empty;
        public string CreationTime { get; set; } = DateTime.Now.ToString("yyyyy-MM-dd HH:mm:ss");
    }
}
