using AutoMapper;
using ProjectTrackingServices.DTO;
using ProjectTrackingServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.Models
{
    public class ManagerCommentsRepository : IManagerCommentsRepository, IDisposable
    {
        private ProjectTrackingDBEntities db = new ProjectTrackingDBEntities();

        private IMapper _mapper;

        public ManagerCommentsRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<ManagerCommentsResultDTO> GetAllManagerComments()
        {
            var query = (from comment in db.ManagerComments
                         select comment).ToList();

            if (query.Count == 0)
                return null;

            List<ManagerCommentsResultDTO> managerComments = new List<ManagerCommentsResultDTO>();
            managerComments = _mapper.Map<List<ManagerCommentsResultDTO>>(query);

            return managerComments;
        }

        public ManagerCommentsResultDTO GetManagerCommentsById(int id)
        {
            var query = (from comment in db.ManagerComments
                         where comment.ManagerCommentID == id
                         select comment).SingleOrDefault();

            ManagerCommentsResultDTO managerComments = new ManagerCommentsResultDTO();
            managerComments = _mapper.Map<ManagerCommentsResultDTO>(query);

            return managerComments;
        }

        public ManagerCommentsResultDTO CreateComment(ManagerCommentsPostDTO comment)
        {
            var managerToCreate = _mapper.Map<ManagerCommentsPostDTO>(comment);

            var toCreate = _mapper.Map<ManagerComment>(managerToCreate);


            db.ManagerComments.Add(toCreate);
            db.SaveChanges();

            ManagerCommentsResultDTO managerResultDto = _mapper.Map<ManagerCommentsResultDTO>(managerToCreate);
            return managerResultDto;
        }

        public ManagerCommentsResultDTO UpdateComment(int id, ManagerCommentsPutDTO comment)
        {
            var query = (from comm in db.ManagerComments
                         where comm.ManagerCommentID == id
                         select comm).SingleOrDefault();

            if(comment.Comments != null)
            {
                query.Comments = comment.Comments;
            }
            if(comment.ProjectTaskID !=null)
            {
                query.ProjectTaskID = comment.ProjectTaskID;
            }

            db.SaveChanges();
            return GetManagerCommentsById(id);
        }

        public Boolean DeleteComment(int comment)
        {
            var query = (from coment in db.ManagerComments
                         where coment.ManagerCommentID == comment
                         select coment).SingleOrDefault();

            db.ManagerComments.Remove(query);
            db.SaveChanges();
            return true;
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}