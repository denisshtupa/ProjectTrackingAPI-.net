using ProjectTrackingServices.DTO;
using ProjectTrackingServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using ProjectTrackingServices.Repository;
using System.Data.Entity;
using ProjectTrackingServices.BaseRepository;

namespace ProjectTrackingServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PTProjectsController : ApiController
    {

        //ProjectsRepository _projectRepository = new ProjectsRepository();
        private IProjectsRepository _projectsRepo;
        //private IBaseRepository<Project, int> _baseRepo;
        //BaseRepository<Project,int> _baseRepo = new BaseRepository<Project, int>();
        
       
        public PTProjectsController(IProjectsRepository projectsRepo)
        {
            _projectsRepo = projectsRepo;
            //_baseRepo = baseRepo;
        }

        // GET: api/PTProjects
        [Route("api/ptprojects")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var projects = _projectsRepo.GetAllProjects();
            return Ok(projects);
        }

        // GET: api/PTProjects/5
        [Route("api/ptprojects/{id?}")]
        [HttpGet]
        public IHttpActionResult GetProjectsById([FromUri] int id)
        {
            var project = _projectsRepo.GetProjectbyId(id);
            return Ok(project);
        }

        [Route("api/ptprojects/{name:alpha}")]
        [HttpGet]
        public IHttpActionResult GetProjectByName(string name)
        {
            var project = _projectsRepo.GetProjectByName(name);
            return Ok(project);
        }


        /// <summary>
        /// Add new project.
        /// </summary>
        /// <param name="projectDTO">The project dto.</param>
        /// <returns>return details of created project </returns>
        [Route("api/ptprojects")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]ProjectsPostDTO projectDTO)
        {
            var project = _projectsRepo.CreateNewProject(projectDTO);
            return Ok(project);
        }

        // PUT: api/PTProjects
        [Route("api/ptprojects/update/{projectId}")]
        [HttpPut]
        public IHttpActionResult Put([FromBody]ProjectsPutDTO projectDto, [FromUri] int projectId)
        {
            var project = _projectsRepo.UpdateExistingProject(projectDto, projectId);
            return Ok(project);
        }

        // DELETE: api/PTProjects/1
        [Route("api/ptprojects/{id?}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var project = _projectsRepo.DeleteProject(id);
            return Ok(project);
        }
    }
}
