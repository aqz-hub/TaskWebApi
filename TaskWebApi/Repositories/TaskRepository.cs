using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System.Data;
using TaskWebApi.Data;
using TaskWebApi.Exceptions;
using TaskWebApi.Interfaces;
using TaskWebApi.Models;
using TaskWebApi.Models.Requests;

namespace TaskWebApi.Repositories
{
    public class TaskRepository : ITask
    {
        private readonly ApiDbContext context;
        public TaskRepository(ApiDbContext context)
        {
            this.context = context;
        }

        public bool Create(TaskRequest request)
        {
            try
            {
                var task = new Models.Task()
                {
                    Name = request.Name,
                    Description = request.Description,
                    Priority = request.Priority,
                    Status = request.Status,
                    Project = request.Project
                };
                context.Tasks.Add(task);
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
                var task = Get(id);
                if(task != null)
                {
                    context.Tasks.Remove(task);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new DomainException($"Task with Id: {id} is not finded");
                }
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, ex);
            }
        }

        public Models.Task Get(long id)
        {
            var task = context.Tasks.SingleOrDefault(x => x.Id == id);
            if (task != null)
            {
                return task;
            }
            else
            {
                throw new DomainException($"Task with Id: {id} is not finded");
            }
        }

        public IEnumerable<Models.Task> GetAll(Project project)
        {
            var tasks = context.Tasks.Where(x => Equals(x.Project, project));
            if(tasks.Count() > 0)
            {
                return tasks;
            }
            else
            {
                throw new DomainException($"Cannot finded tasks for project: {project.Name}");
            }
        }

        public bool Update(long id, TaskRequest request)
        {
            try
            {
                var task = Get(id);
                if(task != null)
                {
                    task.Name = request.Name;
                    task.Description = request.Description;
                    task.Priority = request.Priority;
                    task.Status = request.Status;
                    task.Project = request.Project;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new DomainException($"Task with Id: {id} is not finded");
                }
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, ex);
            }
        }
    }
}
