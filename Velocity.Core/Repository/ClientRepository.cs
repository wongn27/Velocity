using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Velocity.Core.Interfaces;
using Velocity.Data;

namespace Velocity.Core.Repository
{
    public class ClientRepository : ICrudRepository<Client>
    {
        private readonly VelocityContext context;

        public ClientRepository(VelocityContext context)
        {
            this.context = context;
        }

        public void Create(Client model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            context.Clients.Add(model);
            context.SaveChanges();
        }

        public async Task CreateAsync(Client model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await context.Clients.AddAsync(model);
            await context.SaveChangesAsync();
        }

        public void Delete(Client model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Client client = Get(model.Id);

            if (client is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            context.Clients.Remove(client);
        }

        public Task DeleteAsync(Client model)
        {
            throw new NotImplementedException();
        }

        public Client Get(Guid id)
        {
            return context.Clients.Find(id) ?? throw new ArgumentException(nameof(id));
        }

        public IQueryable<Client> Get(string companyName)
        {
            return context.Clients.Where(c => c.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));
        }

        public IQueryable<Client> Get(Expression<Func<Client, bool>> predicate)
        {
            return context.Clients.Where(predicate);
        }

        public async Task<Client> GetAsync(Guid id)
        {
            return await context.Clients.FindAsync(id);
        }

        // find a better way. currently not async
        public async Task<IQueryable<Client>> GetAsync(Expression<Func<Client, bool>> predicate)
        {
            return context.Clients.Where(predicate);
        }

        public void Update(Client model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Client client = Get(model.Id);

            if (client is null)
            {
                throw new ArgumentException("This client cannot be updated as it doesn't exist.");
            }

            context.Clients.Update(client);
            context.SaveChanges();
        }

        public async Task UpdateAsync(Client model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Client client = Get(model.Id);

            if (client is null)
            {
                throw new ArgumentException("This client cannot be updated as it doesn't exist.");
            }

            context.Clients.Update(client);
            await context.SaveChangesAsync();
        }
    }
}
