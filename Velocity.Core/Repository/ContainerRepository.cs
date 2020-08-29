using Velocity.Data;
using Velocity.Data.Models;

namespace Velocity.Core.Repository
{
    public class ContainerRepository : CrudRepositoryBase<Container>
    {
        public ContainerRepository(VelocityContext context) : base(context)
        {
        }
    }
}
