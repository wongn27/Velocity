using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
    public class FeeRepository : ILookupRepository<Fee>
    {
        private readonly VelocityContext context;

        public FeeRepository(VelocityContext context)
        {
            this.context = context;
        }

        public Fee Get(Guid id)
        {
            return context.Fees.Find(id) ?? throw new ArgumentException(nameof(id));
        }

        public IQueryable<Fee> Get(Expression<Func<Fee, bool>> predicate)
        {
            return context.Fees.Where(predicate);
        }

        public async Task<Fee> GetAsync(Guid id)
        {
            return await context.Fees.FindAsync(id);
        }

        // find a better way. currently not async
        public async Task<IQueryable<Fee>> GetAsync(Expression<Func<Fee, bool>> predicate)
        {
            return context.Fees.Where(predicate);
        }

    }
}
