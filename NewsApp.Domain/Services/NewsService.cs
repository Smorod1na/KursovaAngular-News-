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
        private readonly IGenericRepository<Comments> _repoComnnets;
        private readonly IGenericRepository<UserIsFavorite> _repoFavorite;


        public NewsService(IGenericRepository<News> repo,IGenericRepository<Comments> repoComnnets,
            IGenericRepository<UserIsFavorite> repoFavorite)
        {
            _repo = repo;
            _repoComnnets = repoComnnets;
            _repoFavorite = repoFavorite;
        }

        public void addFavorite(UserIsFavorite model)
        {
            _repoFavorite.Create(model);      }

        public void AddNews(News model)
        {
           _repo.Create(model);
        }

        public void deleteFavorite(UserIsFavorite model)
        {
            _repoFavorite.Delete(model);
        }

        public void deleteNews(News model)
        {           
            _repo.Delete(model);
        }

        public ICollection<UserIsFavorite> GetAllFavorite()
        {
           return _repoFavorite.GetAll().ToArray();
        }

        public ICollection<News> GetAllNews()
        {
            return _repo.GetAll().ToArray();
        }

        public News getNews(News model)
        {
            return model;     
        }

        public void setFavorite(UserIsFavorite model)
        {
            _repoFavorite.setFavorite(model);
        }

        public void Update(News model)
        {
            _repo.Update(model);
        }
    }
}
