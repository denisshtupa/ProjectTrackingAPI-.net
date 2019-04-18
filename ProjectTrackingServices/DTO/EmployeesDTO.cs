using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.DTO
{
    public class EmployeesDTO
    {

        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public int? ManagerID { get; set; }
        public string ContactNo { get; set; }
        public string EMailID { get; set; }
        public string SkillSets { get; set; }

        public virtual IList<ProjectsTasksDTO> ProjectTasks { get; set; }
    }

    public class EmployeesPutDTO
    {
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public int? ManagerID { get; set; }
        public string ContactNo { get; set; }
        public string EMailID { get; set; }
        public string SkillSets { get; set; }
    }

    public class EmployeesPostDTO
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public int? ManagerID { get; set; }
        public string ContactNo { get; set; }
        public string EMailID { get; set; }
        public string SkillSets { get; set; }
    }

    public class EmployeesResultDTO
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public int? ManagerID { get; set; }
        public string ContactNo { get; set; }
        public string EMailID { get; set; }
        public string SkillSets { get; set; }

        public virtual IList<ProjectsTasksResultDTO> ProjectTasks { get; set; }
    }
}