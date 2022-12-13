using System.ComponentModel.DataAnnotations;

namespace TaskWebApi.Models
{
    public class Project
    {
        public enum ProjectStatuses
        {
            NotStarted,
            Active,
            Completed
        }
        [Key]
        public long Id { get; set; }
        public ProjectStatuses Status { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
