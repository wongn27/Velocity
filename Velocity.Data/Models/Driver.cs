using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Velocity.Data.Interfaces;

namespace Velocity.Data.Models
{
    public class Driver : IIdentity
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [Description("The first name of the driver.")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [Description("The last name of the driver.")]
        public string LastName { get; set; }
    }
}
