using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using TaskWebApi.Interfaces;
using TaskWebApi.Models.Requests;

namespace TaskWebApi.Controllers
{
    [ApiController]
    [Route("task")]
    public class TaskController : ControllerBase
    {
        private readonly ITask task;
        public TaskController(ITask task)
        {
            this.task = task;
        }

        [HttpGet, Route("get/{id}")]
        public Models.Task Get(long id)
        {
            return task.Get(id);
        }

        [HttpPut, Route("create")]
        public void Create(TaskRequest request)
        {
            task.Create(request);
        }
        [HttpPost, Route("update/{id}")]
        public void Update(long id, TaskRequest request)
        {
            task.Update(id, request);
        }
        [HttpDelete, Route("delete/{id}")]
        public void Delete(long id)
        {
            task.Delete(id);
        }
    }
}
