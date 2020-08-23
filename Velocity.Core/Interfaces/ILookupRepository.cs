using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Velocity.Core.Interfaces
{
    public interface ILookupRepository<TModel>
        where TModel : class, new()
    {
        public TModel Get(Guid id);
        public Task<TModel> GetAsync(Guid id);
        public IQueryable<TModel> Get(Expression<Func<TModel, bool>> predicate);
        public Task<IQueryable<TModel>> GetAsync(Expression<Func<TModel, bool>> predicate);
    }
}
