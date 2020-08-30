using System;
using System.ComponentModel.DataAnnotations;
using Velocity.Data.Interfaces;

namespace Velocity.Data.Models
{
    public class Client : IIdentity
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string State { get; set; }

        [Required]
        [MaxLength(5)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Phone]
        [Required]
        [MaxLength(15)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string TypeOfClient { get; set; }
    }
}
