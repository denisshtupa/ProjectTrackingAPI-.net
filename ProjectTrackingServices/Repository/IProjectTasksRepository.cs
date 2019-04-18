using ProjectTrackingServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackingServices.Repository
{
    public interface IProjectTasksRepository
    {
        List<ProjectsTasksResultDTO> GetAllProjectTasks();
        ProjectsTasksResultDTO GetProjectTasksById(int id);
        ProjectsTasksResultDTO InsertProjectTask(ProjectsTasksPostDTO projT);
        ProjectsTasksResultDTO UpdateProjectTask(int projTaskId, ProjectsTasksPutDTO projT);
        Boolean DeleteProjectTask(int id);
    }
}
