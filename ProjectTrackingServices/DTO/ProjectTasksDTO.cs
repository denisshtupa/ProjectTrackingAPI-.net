using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.DTO
{
    public class ProjectsTasksDTO
    {
        public int ProjectTaskID { get; set; }
        public int? AssignedTo { get; set; }
        public DateTime? TaskStartDate { get; set; }
        public DateTime? TaskEndDate { get; set; }
        public int? TaskCompletion { get; set; }
        public int? UserStoryID { get; set; }

        public virtual EmployeesDTO Employee { get; set; }
        public virtual IList<ManagerCommentsDTO> ManagerComments { get; set; }
        public virtual UserStoriesDTO UserStory { get; set; }
    }

    public class ProjectsTasksPutDTO
    {
        public int? AssignedTo { get; set; }
        public DateTime? TaskStartDate { get; set; }
        public DateTime? TaskEndDate { get; set; }
        public int? TaskCompletion { get; set; }

    }

    public class ProjectsTasksPostDTO
    {
        public int ProjectTaskID { get; set; }
        public int? AssignedTo { get; set; }
        public int? TaskCompletion { get; set; }
        public int? UserStoryID { get; set; }
    }

    public class ProjectsTasksResultDTO
    {
        public int ProjectTaskID { get; set; }
        public int? AssignedTo { get; set; }
        public DateTime? TaskStartDate { get; set; }
        public DateTime? TaskEndDate { get; set; }
        public int? TaskCompletion { get; set; }
        public int? UserStoryID { get; set; }

        public virtual EmployeesResultDTO Employee { get; set; }
        //public virtual IList<ManagerCommentsResultDTO> ManagerComments { get; set; }
        //public virtual UserStoriesResultDTO UserStory { get; set; }
    }
}