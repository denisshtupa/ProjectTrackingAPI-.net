using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.DTO
{
    public class UserStoriesDTO
    {
        public int UserStoryID { get; set; }
        public string Story { get; set; }
        public int? ProjectID { get; set; }

        public virtual ProjectsDTO Project { get; set; }

        public virtual IList<ProjectsTasksDTO> ProjectTasks { get; set; }
    }

    public class UserStoriesPutDTO
    {
        public string Story { get; set; }
        public int? ProjectID { get; set; }        
    }

    public class UserStoriesPostDTO
    {
        public int UserStoryID { get; set; }
        public string Story { get; set; }
        public int? ProjectID { get; set; }
    }

    public class UserStoriesResultDTO
    {
        public int UserStoryID { get; set; }
        public string Story { get; set; }
        public int? ProjectID { get; set; }

        public virtual ProjectsPostDTO Project { get; set; }

        //public virtual IList<ProjectsTasksDTO> ProjectTasks { get; set; }
    }
}