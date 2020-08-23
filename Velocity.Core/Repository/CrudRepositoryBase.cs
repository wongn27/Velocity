using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Velocity.Core.Interfaces;
using Velocity.Data;
using Velocity.Data.Interfaces;

namespace Velocity.Core.Repository
{
    /// <summary>
    /// A base class for a crud repository that supports 
    /// Create, Remove, Update, and Delete operations on a 
    /// <see cref="DbSet{TModel}"/>.
    /// </summary>
    public abstract class CrudRepositoryBase<TModel> : ICrudRepository<TModel>
        where TModel : class, IIdentity, new()
    {
        private readonly VelocityContext context;

        protected DbSet<TModel> Model { get; set; }

        public CrudRepositoryBase(VelocityContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            Model = context.GetDbSetFor<TModel>();
            this.context = context;
        }

        public void Create(TModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Model.Add(model);
            context.SaveChanges();
        }

        public async Task CreateAsync(TModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await Model.AddAsync(model);
            await context.SaveChangesAsync();
        }

        public void Delete(TModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            TModel newModel = Get(model.Id);

            if (newModel is null)
            {
                throw new ArgumentNullException(nameof(newModel));
            }

            Model.Remove(newModel);
            context.SaveChanges();
        }

        public async Task DeleteAsync(TModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            TModel newModel = await GetAsync(model.Id);

            if (newModel is null)
            {
                throw new ArgumentNullException(nameof(newModel));
            }

            Model.Remove(newModel);
            await context.SaveChangesAsync();
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
            return Model.Where(predicate).AsQueryable();
        }

        public void Update(TModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Model.Attach(model);
            Model.Update(model);

            context.SaveChanges();
        }

        public async Task UpdateAsync(TModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Model.Attach(model);
            Model.Update(model);

            await context.SaveChangesAsync();
        }
    }
}
