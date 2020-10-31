using NewsApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Domain.Interfaces
{
    public interface ICategoriService
    {
        ICollection<Categori> GetAllCategori();
        void AddCategori(Categori model);
        Categori getCategori(string id);
    }
}
