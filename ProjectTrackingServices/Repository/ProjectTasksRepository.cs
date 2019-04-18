using AutoMapper;
using ProjectTrackingServices.DTO;
using ProjectTrackingServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.Models
{
    public class ProjectTasksRepository : IProjectTasksRepository, IDisposable
    {
        private static ProjectTrackingDBEntities db = new ProjectTrackingDBEntities();

        private IMapper _mapper;

        public ProjectTasksRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public  List<ProjectsTasksResultDTO> GetAllProjectTasks()
        {
            var query = (from projTask in db.ProjectTasks
                        select projTask).ToList();

            var projTasks = _mapper.Map<List<ProjectsTasksResultDTO>>(query);

            return projTasks;
        }


        public ProjectsTasksResultDTO GetProjectTasksById(int id)
        {
            var query = (from projTask in db.ProjectTasks
                        where projTask.ProjectTaskID == id
                        select projTask).SingleOrDefault();

            var projectTasks = _mapper.Map<ProjectsTasksResultDTO>(query);

            return projectTasks;
        }

        public ProjectsTasksResultDTO InsertProjectTask(ProjectsTasksPostDTO projT)
        {
            var projTaskToCreate = _mapper.Map<ProjectsTasksPostDTO>(projT);

            var toCreate = _mapper.Map<ProjectTask>(projTaskToCreate);

            toCreate.TaskStartDate = DateTime.Now;
            toCreate.TaskEndDate = DateTime.Now.AddDays(60);
                        
            db.ProjectTasks.Add(toCreate);
            db.SaveChanges();

            ProjectsTasksResultDTO projectResult = _mapper.Map<ProjectsTasksResultDTO>(toCreate);

            return projectResult;
        }

        public ProjectsTasksResultDTO UpdateProjectTask(int projTaskId, ProjectsTasksPutDTO projT)
        {
            var query = (from projTask in db.ProjectTasks
                           where projTask.ProjectTaskID == projTaskId
                           select projTask).SingleOrDefault();

            if(projT.AssignedTo != null)
            {
                query.AssignedTo = projT.AssignedTo;
            }
            if(projT.TaskCompletion != null)
            {
                query.TaskCompletion = projT.TaskCompletion;
            }
            if(projT.TaskStartDate != null)
            {
                query.TaskStartDate = projT.TaskStartDate;
            }
            if (projT.TaskEndDate != null)
            {
                query.TaskEndDate = projT.TaskEndDate;
            }
            
            db.SaveChanges();
            return GetProjectTasksById(projTaskId);
        }

        public Boolean DeleteProjectTask(int id)
        {
            var query = (from projTask in db.ProjectTasks
                           where projTask.ProjectTaskID == id
                           select projTask).SingleOrDefault();

            db.ProjectTasks.Remove(query);
            db.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}