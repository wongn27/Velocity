using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Velocity.Data.Models
{
    // may implement later for auditing records
    [ComplexType]
    public class Audit
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateLastModified { get; set; }

        public string CreatedBy { get; set; }

        public string LastModifiedBy { get; set; }
    }
}
