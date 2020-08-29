using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Velocity.Data.Interfaces;

namespace Velocity.Data.Models
{
    public class Container : IIdentity
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Container Number")]
        [Description("The unique number of the container.")]
        public string ContainerNumber { get; set; }

        [Required]
        [Display(Name = "Weight")]
        [Description("The weight of the container.")]
        public float? Weight { get; set; }

        [Required]
        [Display(Name = "Number of Cartons")]
        [Description("The number of cartons contained in the container.")]
        public int CartonsCount { get; set; }
    }
}
