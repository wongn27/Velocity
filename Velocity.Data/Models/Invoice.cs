using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Velocity.Data.Interfaces;

namespace Velocity.Data.Models
{
    public class Invoice : IIdentity
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Invoice Number")]
        [Description("The invoice number for the invoice.")]
        public int InvoiceNumber { get; set; }

        [Required]
        [Timestamp]
        [Display(Name = "Invoice Date")]
        [Description("The date of the invoice.")]
        public DateTime InvoiceDate { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        public IEnumerable<Client> Clients { get; set; }

        [StringLength(50, MinimumLength = 0)]
        [Display(Name = "Terms")]
        [Description("The terms for the invoice.")]
        public string Terms { get; set; }

        [Required]
        [Display(Name = "Total Invoice")]
        [Description("The total invoice of days the chassis is rented.")]
        public decimal TotalInvoice { get; set; }
    }
}
