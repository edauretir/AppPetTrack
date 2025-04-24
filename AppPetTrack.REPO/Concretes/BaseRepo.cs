using System.Collections.Generic;
using AppPetTrack.CORE.Abstracts;
using AppPetTrack.CORE.Enums;
using AppPetTrack.REPO.Context;
using AppPetTrack.REPO.Contract;
using Microsoft.EntityFrameworkCore;

namespace AppPetTrack.REPO.Concretes
{
    public abstract class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {
        private readonly AppPetTrackDbContext _context;
        private DbSet<T> _dbSet;

        protected BaseRepo(AppPetTrackDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Create(T entity) => _context.Add(entity);


        public void Delete(T entity, bool softDelete = true)
        {
            if (softDelete)
            {
                entity.DeletedAt = DateTime.Now;
                entity.Status = Status.Deleted;
                _context.Update(entity);
            }
            else
            {
                _context.Remove(entity);
            }
        }

        public IQueryable<T> GetAll(bool track = true) => track ? _dbSet : _dbSet.AsNoTracking();

        public IQueryable<T> GetByCondition(System.Linq.Expressions.Expression<Func<T, bool>> condition) => _dbSet.Where(condition);

        public T? GetById(int id) => _dbSet.Find(id);

        public void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            entity.Status = Status.Updated;
            _dbSet.Update(entity);
        }
    }
}
