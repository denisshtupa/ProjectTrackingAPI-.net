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
    public class PTUserStoriesController : ApiController
    {
        private IUserStoriesRepository _userStoryRepo;

        public PTUserStoriesController(IUserStoriesRepository userStoryRepo)
        {
            _userStoryRepo = userStoryRepo;
        }


        // GET: api/PTUserStories
        [Route("api/ptuserstories")]
        [HttpGet]
        public IHttpActionResult GetAllUserStories()
        {
            var result = _userStoryRepo.GetAllUserStories();
            return Ok(result);
        }

        // GET: api/PTUserStories/5
        [Route("api/ptpuserstories/{id}")]
        [HttpGet]
        public IHttpActionResult GetUserStoryById([FromUri] int id)
        {
            var result = _userStoryRepo.GetUserStoryById(id);
            return Ok(result);
        }

        // POST: api/PTUserStories
        [Route("api/ptuserstories")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]UserStoriesPostDTO userSt)
        {
            var result = _userStoryRepo.CreateUserStory(userSt);
            return Ok(result);
        }

        // PUT: api/PTUserStories/5
        [Route("api/ptuserstories/{id}")]
        [HttpPatch]
        public IHttpActionResult Put([FromUri] int id, [FromBody]UserStoriesPutDTO userStory)
        {
            var result = _userStoryRepo.UpdateUserStory(id, userStory);
            return Ok(result);
        }

        // DELETE: api/PTUserStories/5
        [Route("api/ptuserstories/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var result = _userStoryRepo.DeleteUserStory(id);
            return Ok(result);
        }
    }
}
