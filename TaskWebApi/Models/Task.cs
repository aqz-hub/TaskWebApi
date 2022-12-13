using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskWebApi.Models
{
    public class Task
    {
        public enum TaskStatuses
        {
            ToDo,
            InProgress,
            Done
        }
        [Key]
        public long Id { get; set; }
        public TaskStatuses Status { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Priority { get; set; }
        public long? ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}
