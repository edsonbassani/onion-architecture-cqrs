using System.ComponentModel.DataAnnotations;

namespace OnionArchitecture.TaskManager.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
        [StringLength(10, MinimumLength = 5)]
        public string Login { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 100)]
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime ModifiedAt { get; set; }
        [Required]
        public int ModifiedBy { get; set; }
    }
}
