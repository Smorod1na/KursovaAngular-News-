﻿using Microsoft.EntityFrameworkCore;
using NewsApp.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsApp.DAL.Repository.Implement
{
    public class EFRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly EFContext _context;
        private readonly DbSet<TEntity> _set;
        public EFRepository(EFContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }
        public void Create(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _set.AsEnumerable();
        }

        public void Update(TEntity entity)
        {
            //_set.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
