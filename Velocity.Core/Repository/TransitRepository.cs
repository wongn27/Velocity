using Velocity.Data;

namespace Velocity.Core.Repository
{
    public class TransitRepository : CrudRepositoryBase<Transit>
    {
        public TransitRepository(VelocityContext context) : base(context)
        {
        }
    }
}
