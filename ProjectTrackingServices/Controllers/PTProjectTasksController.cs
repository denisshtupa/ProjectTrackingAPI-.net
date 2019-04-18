using ProjectTrackingServices.DTO;
using ProjectTrackingServices.Models;
using ProjectTrackingServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectTrackingServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PTProjectTasksController : ApiController
    {
        private IProjectTasksRepository _projectTaskRepo;

        public PTProjectTasksController(IProjectTasksRepository projectTasksRepo)
        {
            _projectTaskRepo = projectTasksRepo;
        }

        // GET: api/PTProjectTasks
        [Route("api/ptprojecttasks")]
        [HttpGet]
        public IHttpActionResult GetAllProjectTasks()
        {
            var result = _projectTaskRepo.GetAllProjectTasks();
            return Ok(result);
        }

        // GET: api/PTProjectTasks/5
        [Route("api/ptprojecttasks/{id}")]
        [HttpGet]
        public IHttpActionResult GetProjectsTaskById([FromUri]int id)
        {
            var result = _projectTaskRepo.GetProjectTasksById(id);
            return Ok(result);
        }

        // POST: api/PTProjectTasks
        [Route("api/ptprojecttasks")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]ProjectsTasksPostDTO proj)
        {
            var result = _projectTaskRepo.InsertProjectTask(proj);
            return Ok(result);
        }

        // PUT: api/PTProjectTasks/5
        [Route("api/ptprojecttasks")]
        [HttpPatch]
        public IHttpActionResult Put(int projId, [FromBody] ProjectsTasksPutDTO proj)
        {
            var result = _projectTaskRepo.UpdateProjectTask(projId, proj);
            return Ok(result);
        }

        // DELETE: api/PTProjectTasks/5
        [Route("api/ptprojecttasks/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
            var result = _projectTaskRepo.DeleteProjectTask(id);
            return Ok(result);
        }
    }
}
