using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Velocity.Core.Interfaces;
using Velocity.Data;

namespace Velocity.Core.Repository
{
    public class ContainerRepository : ICrudRepository<Container>
    {
        private readonly VelocityContext context;

        public ContainerRepository(VelocityContext context)
        {
            this.context = context;
        }

        public void Create(Container model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            context.Containers.Add(model);
            context.SaveChanges();
        }

        public async Task CreateAsync(Container model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await context.Containers.AddAsync(model);
            await context.SaveChangesAsync();
        }

        public void Delete(Container model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var container = Get(model.Id);

            if (container is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            context.Containers.Remove(container);
        }

        public async Task DeleteAsync(Container model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var container = await GetAsync(model.Id);

            if (container is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            context.Containers.Remove(container);
            await context.SaveChangesAsync();
        }

        public Container Get(Guid id)
        {
            return context.Containers.Find(id) ?? throw new ArgumentException(nameof(id));
        }

        public IQueryable<Container> Get(Expression<Func<Container, bool>> predicate)
        {
            return context.Containers.Where(predicate);
        }

        public async Task<Container> GetAsync(Guid id)
        {
            return await context.Containers.FindAsync(id);
        }

        // find a better way. currently not async
        public async Task<IQueryable<Container>> GetAsync(Expression<Func<Container, bool>> predicate)
        {
            return context.Containers.Where(predicate);
        }

        public void Update(Container model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var container = Get(model.Id);

            if (container is null)
            {
                throw new ArgumentException("This Container cannot be updated as it doesn't exist.");
            }

            context.Containers.Update(container);
            context.SaveChanges();
        }

        public async Task UpdateAsync(Container model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var container = Get(model.Id);

            if (container is null)
            {
                throw new ArgumentException("This Container cannot be updated as it doesn't exist.");
            }

            context.Containers.Update(container);
            await context.SaveChangesAsync();
        }
    }
}
