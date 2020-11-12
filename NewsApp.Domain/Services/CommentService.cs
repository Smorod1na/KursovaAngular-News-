using NewsApp.DAL.Entity;
using NewsApp.DAL.Repository.Abstraction;
using NewsApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsApp.Domain.Services
{
    public class CommentService : ICommentService
    {
        private readonly IGenericRepository<Comments> _repoComment;

        public CommentService(IGenericRepository<Comments> repoComment)
        {
            _repoComment = repoComment;
        }
        public void AddComment(Comments comments)
        {
            _repoComment.Create(comments);
        }

        public void DeleteComment(Comments comments)
        {
            _repoComment.Delete(comments);
        }

        public ICollection<Comments> GetAllComment()
        {
            return _repoComment.GetAll().ToList();
        }
    }
}
