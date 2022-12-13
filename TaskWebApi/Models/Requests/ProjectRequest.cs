namespace TaskWebApi.Models.Requests
{
    public class ProjectRequest
    {
        public Project.ProjectStatuses Status { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
    }
}
