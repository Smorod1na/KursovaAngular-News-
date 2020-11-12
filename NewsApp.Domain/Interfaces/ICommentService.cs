using NewsApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Domain.Interfaces
{
    public interface ICommentService
    {
        void AddComment(Comments comments);
        ICollection<Comments> GetAllComment();
        void DeleteComment(Comments comments);
    }
}
