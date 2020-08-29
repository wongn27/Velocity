using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Velocity.Core.Interfaces;
using Velocity.Data;

namespace Velocity.Core.Repository
{
    public abstract class LookupRepositoryBase<TModel> : ILookupRepository<TModel>
        where TModel : class, new()
    {
        private DbSet<TModel> Model { get; set; }

        public LookupRepositoryBase(VelocityContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            Model = context.GetDbSetFor<TModel>();
        }

        public TModel Get(Guid id)
        {
            return Model.Find(id) ?? throw new ArgumentException(nameof(id));
        }

        public IQueryable<TModel> Get(Expression<Func<TModel, bool>> predicate)
        {
            return Model.Where(predicate);
        }

        public async Task<TModel> GetAsync(Guid id)
        {
            return await Model.FindAsync(id) ?? throw new ArgumentException(nameof(id));
        }

        public async Task<IQueryable<TModel>> GetAsync(Expression<Func<TModel, bool>> predicate)
        {
            var models = await Model.Where(predicate).ToArrayAsync();
            return models.AsQueryable();
        }

        public IQueryable<TModel> GetAll()
        {
            return Model;
        }

        public async Task<IQueryable<TModel>> GetAllAsync()
        {
            var models = await Model.ToArrayAsync();
            return models.AsQueryable();
        }
    }
}
