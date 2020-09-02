using System;
using System.Linq;
using Velocity.Data;
using Velocity.Data.Models;

namespace Velocity.Core.Repository
{
    public class InvoiceDetailRepository : CrudRepositoryBase<InvoiceDetail>
    {
        private readonly Lazy<InvoiceRepository> invoiceRepository;

        public InvoiceDetailRepository(VelocityContext context) : base(context)
        {
            invoiceRepository = new Lazy<InvoiceRepository>(() => new InvoiceRepository(context));
        }

        public IQueryable<InvoiceDetail> GetInvoiceDetails(Guid invoiceId)
        {
            var invoice = invoiceRepository.Value.Get(invoiceId);

            if (invoice is null)
            {
                throw new ArgumentException("The specified invoice does not exist.");
            }

            return Get(detail => detail.InvoiceId == invoiceId);
        }
    }
}
