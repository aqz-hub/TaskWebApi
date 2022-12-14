using Microsoft.AspNetCore.Mvc;
using TaskWebApi.Interfaces;
using TaskWebApi.Models;
using TaskWebApi.Models.Requests;

namespace TaskWebApi.Controllers
{
    [ApiController]
    [Route("project")]
    public class ProjectController : ControllerBase
    {
        private readonly IProject project;
        public ProjectController(IProject project)
        {
            this.project = project;
        }

        [HttpGet, Route("get/{id}")]
        public Project Get(long id)
        {
           return project.Get(id);
        }

        [HttpPut, Route("create")]
        public void Create(ProjectRequest request)
        {
            project.Create(request);
        }
        [HttpPost, Route("update/{id}")]
        public void Update(long id, ProjectRequest request)
        {
            project.Update(id, request);
        }
        [HttpDelete, Route("delete/{id}")]
        public void Delete(long id)
        {
            project.Delete(id);
        }
    }
}
