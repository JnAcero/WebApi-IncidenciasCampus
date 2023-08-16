using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositories
{
    public class GenericRepoA<T> : IGenericRepoA<T>
    {
        private readonly ApiIncidenciasDbContext _context;

        public GenericRepoA(ApiIncidenciasDbContext context)
        {
        _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<T>> GetAllAsync()
        {
           throw new NotImplementedException();
        }

        public virtual Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public  virtual Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
           _context.Update(entity);
        }
    }

}