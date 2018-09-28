using System.ComponentModel.DataAnnotations;

namespace Person.Domain.Entities
{
    public class Person
    {
        [Key]
        [Required]
        [MaxLength(36)]
        [MinLength(36)]
        public string Key { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
    }
}