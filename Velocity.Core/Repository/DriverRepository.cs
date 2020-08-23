using Velocity.Data;

namespace Velocity.Core.Repository
{
    public class DriverRepository : CrudRepositoryBase<Driver>
    {
        public DriverRepository(VelocityContext context) : base(context)
        {
        }
    }
}
