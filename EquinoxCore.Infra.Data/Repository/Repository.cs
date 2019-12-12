using EquinoxCore.Domain.Interfaces;
using EquinoxCore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquinoxCore.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly EquinoxContext DB;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(EquinoxContext db) {
            DB = db;
            DbSet = db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            DB.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return DB.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }
    }
}
