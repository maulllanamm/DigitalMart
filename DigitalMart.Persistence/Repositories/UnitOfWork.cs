﻿using DigitalMart.Application.Repositories;
using DigitalMart.Domain.Common;
using DigitalMart.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace DigitalMart.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private Dictionary<Type, object> _repositories;
        private IDbContextTransaction _transaction;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IBaseRepository<Entity> GetBaseRepository<Entity>() where Entity : class, IBaseEntity
        {
            if (_repositories == null)
                _repositories = new Dictionary<Type, object>();

            var type = typeof(Entity);
            if (!_repositories.ContainsKey(type))
                _repositories[type] = new BaseRepository<Entity>(_context);
            return (IBaseRepository<Entity>)_repositories[type];
        }


        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.SaveChanges();
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
