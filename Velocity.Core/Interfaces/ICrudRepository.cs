using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Velocity.Core.Interfaces
{
    public interface ICrudRepository<TModel>
        where TModel : class, new()
    {
        public void Create(TModel model);
        public Task CreateAsync(TModel model);

        public void Delete(TModel model);
        public Task DeleteAsync(TModel model);

        public void Update(TModel model);
        public Task UpdateAsync(TModel model);

        public TModel Get(Guid id);
        public Task<TModel> GetAsync(Guid id);
        public IQueryable<TModel> Get(Expression<Func<TModel, bool>> predicate);
        public Task<IQueryable<TModel>> GetAsync(Expression<Func<TModel, bool>> predicate);

    }
}
