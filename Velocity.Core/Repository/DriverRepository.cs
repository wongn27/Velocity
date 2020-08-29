using Velocity.Data;
using Velocity.Data.Models;

namespace Velocity.Core.Repository
{
    public class DriverRepository : CrudRepositoryBase<Driver>
    {
        public DriverRepository(VelocityContext context) : base(context)
        {
        }
    }
}
