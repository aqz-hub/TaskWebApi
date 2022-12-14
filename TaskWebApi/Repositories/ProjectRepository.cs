using TaskWebApi.Data;
using TaskWebApi.Interfaces;
using TaskWebApi.Models;
using TaskWebApi.Exceptions;
using TaskWebApi.Models.Requests;

namespace TaskWebApi.Repositories
{
    public class ProjectRepository : IProject
    {
        private readonly ApiDbContext context;
        public ProjectRepository(ApiDbContext context)
        {
            this.context = context;
        }

        public bool Create(ProjectRequest request)
        {
            try
            {
                var project = new Project()
                {
                    Name = request.Name,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Priority = request.Priority,
                    Status = request.Status,
                };
                context.Projects.Add(project);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, ex);
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var project = Get(id);
                if (project != null)
                {
                    context.Projects.Remove(project);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new DomainException($"Project with Id: {id} is not finded");
                }
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, ex);
            }
        }

        public Project Get(long id)
        {
            var project = context.Projects.SingleOrDefault(x => x.Id == id);
            if (project != null)
            {
                return project;
            }
            else
            {
                throw new DomainException($"Project with Id: {id} is not finded");
            }
        }

        public bool Update(long id, ProjectRequest request)
        {
            try
            {
                var project = Get(id);
                if (project != null)
                {
                    project.Name = request.Name;
                    project.StartDate = request.StartDate;
                    project.EndDate = request.EndDate;
                    project.Priority = request.Priority;
                    project.Status = request.Status;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new DomainException($"Project with Id: {id} is not finded");
                }
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, ex);
            }
        }
    }
}
