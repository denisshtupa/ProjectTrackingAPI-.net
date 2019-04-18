using ProjectTrackingServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackingServices.Repository
{
    public interface IUserStoriesRepository
    {
        List<UserStoriesResultDTO> GetAllUserStories();
        UserStoriesResultDTO GetUserStoryById(int id);
        UserStoriesResultDTO CreateUserStory(UserStoriesPostDTO userStory);
        UserStoriesResultDTO UpdateUserStory(int id, UserStoriesPutDTO userStory);
        Boolean DeleteUserStory(int id);
    }
}
