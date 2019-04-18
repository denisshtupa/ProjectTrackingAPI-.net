using AutoMapper;
using ProjectTrackingServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.Mapper
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<ProjectsDTO,Project>().ForPath(dest => dest.UserStories, options => options.Ignore());
            CreateMap<ProjectsDTO, ProjectsResultDTO>().ReverseMap();
            CreateMap<ProjectsPostDTO, ProjectsResultDTO>().ReverseMap();
            CreateMap<ProjectsPostDTO, Project>().ForMember(dest => dest.UserStories, options => options.Ignore());
            CreateMap<Project, ProjectsPostDTO>().ReverseMap();
            CreateMap<Project, ProjectsDTO>();

            CreateMap<Employee, EmployeesResultDTO>();
            CreateMap<EmployeesResultDTO, Employee>();
            CreateMap<Employee, EmployeesPostDTO>();
            CreateMap<EmployeesPostDTO, Employee>();
            CreateMap<EmployeesPostDTO, EmployeesResultDTO>().ReverseMap();

            CreateMap<ManagerComment, ManagerCommentsResultDTO>().ReverseMap();
            CreateMap<ManagerComment, ManagerCommentsPostDTO>().ReverseMap();
            CreateMap<ManagerCommentsPostDTO, ManagerCommentsResultDTO>().ReverseMap();

            CreateMap<ProjectTask, ProjectsTasksResultDTO>().ReverseMap();
            CreateMap<ProjectTask, ProjectsTasksPostDTO>().ReverseMap();
            CreateMap<ProjectsTasksPostDTO, ProjectsTasksResultDTO>().ReverseMap();

            CreateMap<UserStory, UserStoriesResultDTO>().ReverseMap();
            CreateMap<UserStory, UserStoriesPostDTO>().ReverseMap();
            CreateMap<UserStoriesPostDTO, UserStoriesResultDTO>().ReverseMap();


        }

        //public GeneralProfile()
        //{
        //    CreateMap<ProjectsDTO, Project>().ReverseMap();
        //}

        //CreateMap<RoleRequestDTO, Role>();
        //    CreateMap<Action, ActionDTO>().ReverseMap();
        //CreateMap<ActionType, ActionTypeDTO>().ReverseMap();
        //CreateMap<RoleRequestDTO, Role>();
        //    CreateMap<Role, ResultRoleDTO>();
        //    CreateMap<Role, RoleDTO>();
        //    CreateMap<RoleUser, RoleUserDTO>().ReverseMap();
        //CreateMap<RoleGroup, RoleGroupDTO>().ReverseMap();
        //CreateMap<ResultRoleDTO, RoleRequestDTO>().ReverseMap();
    }
}