using ProjectTrackingServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.Repository
{
    public interface IProjectsRepository
    {
        IEnumerable<ProjectsResultDTO> GetAllProjects();
        ProjectsResultDTO GetProjectbyId(int id);
        List<ProjectsResultDTO> GetProjectByName(string name);
        ProjectsResultDTO CreateNewProject(ProjectsPostDTO projectPostDto);
        ProjectsResultDTO UpdateExistingProject(ProjectsPutDTO projectPutDto, int projectId);
        Boolean DeleteProject(int projectId);
    }
}