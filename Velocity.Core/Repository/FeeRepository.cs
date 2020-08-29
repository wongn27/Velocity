using Velocity.Data;
using Velocity.Data.Models;

namespace Velocity.Core.Repository
{
    public class FeeRepository : LookupRepositoryBase<Fee>
    {
        public FeeRepository(VelocityContext context) : base(context)
        {
        }
    }
}
