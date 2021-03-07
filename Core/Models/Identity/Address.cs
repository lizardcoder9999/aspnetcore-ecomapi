using System.ComponentModel.DataAnnotations;

namespace Core.Models.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        //Convention based foreign key
        [Required]
        public string AppUserId { get; set; }

        //One to one relationship between AppUser with Address.
        public AppUser AppUser { get; set; }
    }
}
