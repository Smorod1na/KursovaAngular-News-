using NewsApp.DAL.Entity;
using NewsApp.DAL.Repository.Abstraction;
using NewsApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsApp.Domain.Services
{
    public class CategoriService : ICategoriService
    {

        private readonly IGenericRepository<Categori> _repo;
        public CategoriService(IGenericRepository<Categori> repo)
        {
            _repo = repo;
        }
        public void AddCategori(Categori model)
        {
            throw new NotImplementedException();
        }

        public ICollection<Categori> GetAllCategori()
        {
            return _repo.GetAll().ToArray();
        }
        public Categori getCategori(string id)
        {
            return _repo.GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
