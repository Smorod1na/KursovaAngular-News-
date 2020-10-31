using NewsApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Domain.Interfaces
{
    public interface INewsService
    {
        ICollection<News> GetAllNews();
        void AddNews(News model);
    }
}
