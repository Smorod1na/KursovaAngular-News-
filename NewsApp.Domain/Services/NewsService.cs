using NewsApp.DAL.Entity;
using NewsApp.DAL.Repository.Abstraction;
using NewsApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsApp.Domain.Services
{
    public class NewsService : INewsService
    {
        private readonly IGenericRepository<News> _repo;
        public NewsService(IGenericRepository<News> repo)
        {
            _repo = repo;
        }

        public void AddNews(News model)
        {
           _repo.Create(model);
        }

        public ICollection<News> GetAllNews()
        {
            return _repo.GetAll().ToArray();
        }
    }
}
