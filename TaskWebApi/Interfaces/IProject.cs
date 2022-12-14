using TaskWebApi.Models;
using TaskWebApi.Models.Requests;

namespace TaskWebApi.Interfaces
{
    public interface IProject
    {
        public Project Get(long id);
        public bool Create(ProjectRequest request);
        public bool Update(long id, ProjectRequest request);
        public bool Delete(long id);
    }
}
