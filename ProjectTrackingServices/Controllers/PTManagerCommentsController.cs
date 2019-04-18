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
    public class PTManagerCommentsController : ApiController
    {
        private IManagerCommentsRepository _managerComentsRepo;

        public PTManagerCommentsController(IManagerCommentsRepository managerCommentsRepo)
        {
            _managerComentsRepo = managerCommentsRepo;
        }

        // GET: api/PTManagerComments
        [Route("api/ptmanagercomments")]
        [HttpGet]
        public IHttpActionResult GetAllManagerComments()
        {
            var result = _managerComentsRepo.GetAllManagerComments();
            return Ok(result);
        }

        // GET: api/PTManagerComments/5
        [Route("api/ptmanagercomments/{id}")]
        [HttpGet]
        public IHttpActionResult GetManagerCommentById(int id)
        {
            var result = _managerComentsRepo.GetManagerCommentsById(id);
            return Ok(result);
        }

        // POST: api/PTManagerComments
        [Route("api/ptmanagercomments")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] ManagerCommentsPostDTO managerComm)
        {
            var result = _managerComentsRepo.CreateComment(managerComm);
            return Ok(result);
        }

        // PUT: api/PTManagerComments/5
        [Route("api/ptmanagercomments/{id}")]
        [HttpPatch]
        public IHttpActionResult Put([FromUri] int id, [FromBody] ManagerCommentsPutDTO managerComm)
        {
            var result = _managerComentsRepo.UpdateComment(id, managerComm);
            return Ok(result);
        }

        // DELETE: api/PTManagerComments/5
        [Route("api/ptmanagercomments/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var result = _managerComentsRepo.DeleteComment(id);
            return Ok(result);
        }
    }
}
