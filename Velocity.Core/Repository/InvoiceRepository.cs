using System.Linq;
using Velocity.Data;
using Velocity.Data.Models;

namespace Velocity.Core.Repository
{
    public class InvoiceRepository : CrudRepositoryBase<Invoice>
    {
        private readonly InvoiceDetailRepository invoiceDetailRepository;

        public InvoiceRepository(VelocityContext context) : base(context)
        {
            invoiceDetailRepository = new InvoiceDetailRepository(context);
        }
    }
}
