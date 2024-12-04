using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Models
{
    public class Students
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(16)]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string Number { get; set; }
        [Required]
        [MaxLength(4)]
        public string BloodGroup { get; set; }
    }
}
