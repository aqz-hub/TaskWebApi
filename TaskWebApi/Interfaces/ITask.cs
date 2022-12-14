using TaskWebApi.Models;
using TaskWebApi.Models.Requests;

namespace TaskWebApi.Interfaces
{
    public interface ITask
    {
        public Models.Task Get(long id);
        public IEnumerable<Models.Task> GetAll(Project project);
        public bool Create(TaskRequest request);
        public bool Update(long id, TaskRequest request);
        public bool Delete(long id);
    }
}
