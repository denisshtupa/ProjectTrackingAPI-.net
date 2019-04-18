using AutoMapper;
using ProjectTrackingServices.DTO;
using ProjectTrackingServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.Models
{
    public class UserStoriesRepository : IUserStoriesRepository, IDisposable
    {
        private ProjectTrackingDBEntities db = new ProjectTrackingDBEntities();

        private IMapper _mapper;

        public UserStoriesRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<UserStoriesResultDTO> GetAllUserStories()
        {
            var query = (from userStor in db.UserStories
                         select userStor).ToList();

            if (query.Count == 0)
                return null;

            List<UserStoriesResultDTO> userStory = _mapper.Map<List<UserStoriesResultDTO>>(query);

            return userStory;
        }

        public UserStoriesResultDTO GetUserStoryById(int id)
        {
            var query = (from userStor in db.UserStories
                         where userStor.UserStoryID == id
                         select userStor).SingleOrDefault();

            UserStoriesResultDTO userStory = _mapper.Map<UserStoriesResultDTO>(query);

            return userStory;
        }

        public UserStoriesResultDTO CreateUserStory(UserStoriesPostDTO userStory)
        {
            var userStoryToCreate = _mapper.Map<UserStoriesPostDTO>(userStory);

            var toCreate = _mapper.Map<UserStory>(userStoryToCreate);

            db.UserStories.Add(toCreate);
            db.SaveChanges();

            UserStoriesResultDTO userStoryResult = _mapper.Map<UserStoriesResultDTO>(userStoryToCreate);
            return userStoryResult;
        }

        public UserStoriesResultDTO UpdateUserStory(int id, UserStoriesPutDTO userStory)
        {
            var query = (from userS in db.UserStories
                         where userS.UserStoryID == id
                         select userS).SingleOrDefault();

            if(userStory.Story != null)
            {
                query.Story = userStory.Story;
            }
            if(userStory.ProjectID != null)
            {
                query.ProjectID = userStory.ProjectID;
            }

            db.SaveChanges();
            return GetUserStoryById(id);
        }

        public Boolean DeleteUserStory(int id)
        {
            var query = (from userS in db.UserStories
                         where userS.UserStoryID == id
                         select userS).SingleOrDefault();

            db.UserStories.Remove(query);
            db.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}