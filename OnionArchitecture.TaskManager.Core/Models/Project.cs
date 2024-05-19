using System.ComponentModel.DataAnnotations;

namespace OnionArchitecture.TaskManager.Core.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime ModifiedAt { get; set; }
        [Required]
        public int ModifiedBy { get; set; }
    }
}
