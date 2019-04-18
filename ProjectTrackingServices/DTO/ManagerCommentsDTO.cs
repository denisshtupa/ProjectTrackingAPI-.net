using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.DTO
{
    public class ManagerCommentsDTO
    {
        public int ManagerCommentID { get; set; }
        public string Comments { get; set; }
        public int? ProjectTaskID { get; set; }

        public virtual ProjectsTasksDTO ProjectTask { get; set; }
    }

    public class ManagerCommentsPutDTO
    {
        public string Comments { get; set; }
        public int? ProjectTaskID { get; set; }
    }

    public class ManagerCommentsPostDTO
    {
        public int ManagerCommentID { get; set; }
        public string Comments { get; set; }
        public int? ProjectTaskID { get; set; }
    }


    public class ManagerCommentsResultDTO
    {
        public int ManagerCommentID { get; set; }
        public string Comments { get; set; }
        public int? ProjectTaskID { get; set; }

        public virtual ProjectsTasksResultDTO ProjectTask { get; set; }
    }
}