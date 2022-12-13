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

        [HttpGet, Route("get/information/{id}")]
        public string GetInformation(long id)
        {
            var _task = task.Get(id);

            return task.Information(_task);
        }

        [HttpPut, Route("create")]
        public void CreateTask(TaskRequest request)
        {
            task.Create(request);
        }
        [HttpPost, Route("update/{id}")]
        public void UpdateTask(long id, TaskRequest request)
        {
            task.Update(id, request);
        }
        [HttpDelete, Route("delete/{id}")]
        public void DeleteTask(long id)
        {
            task.Delete(id);
        }
    }
}
