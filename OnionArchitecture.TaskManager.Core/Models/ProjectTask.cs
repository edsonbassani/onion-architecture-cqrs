using System.ComponentModel.DataAnnotations;

namespace OnionArchitecture.TaskManager.Core.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        public int ParentTaskId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int Assignment { get; set; }
        [Required]
        public DateTime CompletionDate { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
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
