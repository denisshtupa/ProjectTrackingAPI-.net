using ProjectTrackingServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ProjectTrackingServices.Repository;

namespace ProjectTrackingServices.Models
{
    public class ProjectsRepository : IProjectsRepository, IDisposable
    {
        private ProjectTrackingDBEntities db = new ProjectTrackingDBEntities();

        private IMapper _mapper;

        public ProjectsRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        //Get App Projects and return object as ProjectsResultDTO
        public IEnumerable<ProjectsResultDTO> GetAllProjects()
        {
            var result = (from project in db.Projects
                          select project).ToList();

            if (result.Count == 0)
                return null;

            List<ProjectsResultDTO> defaultProject = new List<ProjectsResultDTO>();
            defaultProject = _mapper.Map<List<ProjectsResultDTO>>(result);

            return defaultProject;
        }

        //Get specific project by its id
        public ProjectsResultDTO GetProjectbyId(int id)
        {
            var result = (from project in db.Projects
                          where project.ProjectID == id
                          select project).SingleOrDefault();

            ProjectsResultDTO defaultProject = new ProjectsResultDTO();
            defaultProject = _mapper.Map<ProjectsResultDTO>(result);

            return defaultProject;
        }

        //Get specific project by its name
        public List<ProjectsResultDTO> GetProjectByName(string name)
        {
            var result = (from project in db.Projects
                         where project.ProjectName.Contains(name)
                         select project).ToList();

            List<ProjectsResultDTO> defaultProjects = new List<ProjectsResultDTO>();
            defaultProjects = _mapper.Map<List<ProjectsResultDTO>>(result);

            return defaultProjects;
        }

        //Create new project by using ProjectsPostDto object
        public ProjectsResultDTO CreateNewProject(ProjectsPostDTO projectPostDto)
        {
            var projectToCreate = _mapper.Map<ProjectsPostDTO>(projectPostDto);

            //projectToCreate.ProjectID = new int();

            var toCreate = _mapper.Map<Project>(projectToCreate);
                   
            //ProjectsPostDTO model = new ProjectsPostDTO();
            //model.ClientName = projectPostDto.ClientName;
            //model.ProjectName = projectPostDto.ProjectName;

            //ProjectsPostDTO projectToCreate = _mapper.Map<ProjectsPostDTO>(projectPostDto);
            //projectToCreate.StartDate = DateTime.Now;
            //projectToCreate.EndDate = DateTime.Now;

            //Project databaseModel = _mapper.Map<Project>(projectPostDto);

            db.Projects.Add(toCreate);
            db.SaveChanges();

            ProjectsResultDTO projectsResultDto = _mapper.Map<ProjectsResultDTO>(projectToCreate);

            return projectsResultDto;
        }

        public ProjectsResultDTO UpdateExistingProject(ProjectsPutDTO projectPutDto, int projectId)
        {
            var result = (from project in db.Projects
                         where project.ProjectID == projectId
                         select project).SingleOrDefault();

            if(projectPutDto.StartDate != null)
            {
                result.StartDate = projectPutDto.StartDate;

            }
            if(projectPutDto.EndDate != null)
            {
                result.EndDate = projectPutDto.EndDate;

            }
            if(projectPutDto.ProjectName != null)
            {
                result.ProjectName = projectPutDto.ProjectName;
            }
            if(projectPutDto.ClientName != null)
            {
                result.ClientName = projectPutDto.ClientName;
            }

            db.SaveChanges();

            return GetProjectbyId(projectId);
        }

        public Boolean DeleteProject(int projectId)
        {
            var query = (from project in db.Projects
                         where project.ProjectID == projectId
                         select project).SingleOrDefault();

            db.Projects.Remove(query);
            db.SaveChanges();

            return true;
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}