using TaskWebApi.Models;

namespace TaskWebApi.Data
{
    public class DatabaseInitialization
    {
        public static void Initialization(ApiDbContext context)
        {
            if(!context.Projects.Any())
            {
                var project = new Project()
                {
                    Name = "test proj",
                    Priority = 1,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(3),
                    Status = Project.ProjectStatuses.Active
                };
                context.Projects.Add(project);
            }

            if(!context.Tasks.Any())
            {
                var task = new Models.Task()
                {
                    Name = "test task",
                    Priority = 1,
                    Description = "test",
                    Status = Models.Task.TaskStatuses.InProgress,
                    Project = context.Projects.FirstOrDefault()
                };
                context.Tasks.Add(task);
            }

            context.SaveChanges();
        }
    }
}
