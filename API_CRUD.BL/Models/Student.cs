using System.ComponentModel.DataAnnotations;

namespace API_CRUD.BL.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [Range(3,30)]
        public int? Age { get; set; }
    }
}
