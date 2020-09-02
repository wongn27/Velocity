using System;
using System.Linq;
using Velocity.Data;
using Velocity.Data.Models;

namespace Velocity.Core.Repository
{
    public class InvoiceRepository : CrudRepositoryBase<Invoice>
    {
        private readonly Lazy<InvoiceDetailRepository> invoiceDetailRepository;

        public InvoiceRepository(VelocityContext context) : base(context)
        {
            invoiceDetailRepository = new Lazy<InvoiceDetailRepository>(() => new InvoiceDetailRepository(context));
        }
    }
}
