using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Velocity.Data;

namespace Velocity.Core
{
    // Temporary class to illustrate Import/Export quickbooks functionality, we will build a more modular infrastructure
    // to support other exporters if possible.
    internal class QuickBooksExporter
    {
        public void ExportToQuickbooks(IEnumerable<Invoice> invoices)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder
                .Append("HDR").Append("\t").Append("INVOICE DATE").Append("\t").AppendLine()
                .Append("!HDR").Append("\t").Append(invoices.First().InvoiceDate.ToString("YYYYMMDD"));
            foreach (Invoice invoice in invoices)
            {
                strBuilder
                    .Append("TRANS").Append("\t").Append("INVOICE DATE").Append("\t").AppendLine()
                    .Append("!TRANS").Append("\t").Append(invoice.InvoiceDate.ToString("YYYYMMDD")).AppendLine();
            }

            string contents = strBuilder.ToString();
            string fileName = $"Invoice-{DateTime.Today.ToShortDateString()}.iif";

            File.WriteAllText($"C:/{fileName}", contents);
        }

        public IEnumerable<Invoice> ImportFromQuickbooks(string path)
        {
            return Enumerable.Empty<Invoice>();
        }
    }
}
