using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Velocity.Data.Interfaces;

namespace Velocity.Data.Models
{
    public class Fee : IIdentity
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [Description("The name of the fee.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Default Amount")]
        [Description("The default amount for this fee.")]
        public decimal DefaultAmount { get; set; }
    }
}
