using NewsApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Domain.Interfaces
{
    public interface INewsService
    {
        News getNews(News model);
        ICollection<News> GetAllNews();
        void AddNews(News model);
        void deleteNews(News model);
        void Update(News model);
        void setFavorite(UserIsFavorite model);
        void deleteFavorite(UserIsFavorite model);

        void addFavorite(UserIsFavorite model);
        ICollection<UserIsFavorite> GetAllFavorite();


    }
}
