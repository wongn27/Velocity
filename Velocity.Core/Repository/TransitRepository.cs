using Velocity.Data;
using Velocity.Data.Models;

namespace Velocity.Core.Repository
{
    public class TransitRepository : CrudRepositoryBase<Transit>
    {
        public TransitRepository(VelocityContext context) : base(context)
        {
        }
    }
}
