using Microsoft.AspNetCore.Mvc;
using TaskWebApi.Interfaces;
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

        [HttpGet, Route("get/information/{id}")]
        public string GetInformation(long id)
        {
            var _project = project.Get(id);

            return project.Information(_project);
        }

        [HttpPut, Route("create")]
        public void CreateProject(ProjectRequest request)
        {
            project.Create(request);
        }
        [HttpPost, Route("update/{id}")]
        public void UpdateProject(long id, ProjectRequest request)
        {
            project.Update(id, request);
        }
        [HttpDelete, Route("delete/{id}")]
        public void DeleteProject(long id)
        {
            project.Delete(id);
        }
    }
}
