using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Velocity.Data.Enums;
using Velocity.Data.Interfaces;

namespace Velocity.Data.Models
{
    // Computed table
    public class Transit : IIdentity
    {
        public Guid Id { get; set; }

        [Required]
        public Guid ContainerId { get; set; }

        [Required]
        public Guid InvoiceId { get; set; }

        [NotMapped]
        [Display(Name = "Transit State")]
        [Description("Whether the container is in transit.")]
        public TransitState TransitState { get; set; }

        [Display(Name = "In Transit")]
        [Description("Whether the container is in transit.")]
        public bool IsPending { get; set; }
    }
}
