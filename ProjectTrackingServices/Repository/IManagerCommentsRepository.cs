using ProjectTrackingServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackingServices.Repository
{
    public interface IManagerCommentsRepository
    {
        List<ManagerCommentsResultDTO> GetAllManagerComments();
        ManagerCommentsResultDTO GetManagerCommentsById(int id);
        ManagerCommentsResultDTO CreateComment(ManagerCommentsPostDTO comment);
        ManagerCommentsResultDTO UpdateComment(int id, ManagerCommentsPutDTO comment);
        Boolean DeleteComment(int comment);
    }
}
