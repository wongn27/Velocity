using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Velocity.Data.Interfaces;

namespace Velocity.Data.Models
{
    public class InvoiceDetail : IIdentity
    {
        public Guid Id { get; set; }

        [Required]
        public Guid InvoiceId { get; set; }

        public int Quantity { get; set; }

        [NotMapped]
        public string Description { get; }

        public Guid ContainerId { get; set; }

        [Required]
        [Display(Name = "Rate")]
        [Description("The rate for this invoice detail entry.")]
        public decimal Rate { get; set; }

        [Required]
        [Display(Name = "Amount")]
        [Description("The amount for this invoice detail entry.")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(400)]
        [Display(Name = "Master Number")]
        [Description("The steamship line unique identifer.")]
        public string MasterNumber { get; set; }

        [Required]
        [StringLength(400)]
        [Display(Name = "House Number")]
        [Description("The optional steamship line unique identifer extension.")]
        public string HouseNumber { get; set; }

        [Required]
        [StringLength(400)]
        [Display(Name = "Pick Up")]
        [Description("The pick up location of the container. Can be from the terminal or steamship line.")]
        public string FromAddress { get; set; }

        [Required]
        [StringLength(400)]
        [Display(Name = "Drop Off")]
        [Description("The drop off location of the container.")]
        public string ToAddress { get; set; }

        [Required]
        [Timestamp]
        [Display(Name = "Fee From Date")]
        [Description("The beginning date for the fee.")]
        public DateTime FeeFromDate { get; set; }

        [Required]
        [Timestamp]
        [Display(Name = "Fee To Date")]
        [Description("The end date for the fee.")]
        public DateTime FeeToDate { get; set; }

        [StringLength(400)]
        [Display(Name = "Reference Number")]
        [Description("The reference number as part of the invoice.")]
        public string ReferenceNumber { get; set; }
    }
}
