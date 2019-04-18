using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.DTO
{
    public class ProjectsDTO
    {
        //public ProjectsDTO()
        //{
        //    this.UserStories = new HashSet<UserStory>();
        //}

        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ClientName { get; set; }

        public virtual IList<UserStoriesDTO> UserStories { get; set; }
    }


    public class ProjectsPutDTO
    {
        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ClientName { get; set; }
    }

    public class ProjectsPostDTO
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ClientName { get; set; }
    }

    public class ProjectsResultDTO
    {

        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ClientName { get; set; }

        public IList<UserStoriesResultDTO> UserStories { get; set; }
    }
}