using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.DTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int ModifiedBy { get; set; }
    }
}
