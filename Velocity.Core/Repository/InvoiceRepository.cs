using Velocity.Data;

namespace Velocity.Core.Repository
{
    public class InvoiceRepository : CrudRepositoryBase<Invoice>
    {
        public InvoiceRepository(VelocityContext context) : base(context)
        {
        }
    }
}
