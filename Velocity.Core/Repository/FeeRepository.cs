using Velocity.Data;

namespace Velocity.Core.Repository
{
    public class FeeRepository : LookupRepositoryBase<Fee>
    {
        public FeeRepository(VelocityContext context) : base(context)
        {
        }
    }
}
