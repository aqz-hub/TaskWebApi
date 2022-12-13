namespace TaskWebApi.Models.Requests
{
    public class TaskRequest
    {
        public Models.Task.TaskStatuses Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public Project Project { get; set; }
    }
}
