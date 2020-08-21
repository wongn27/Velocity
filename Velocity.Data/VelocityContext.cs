using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Velocity.Data.Enums;

namespace Velocity.Data
{
    public class VelocityContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Transit> Transits { get; set; }
        public DbSet<Fee> Fees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Velocity");
        }

        public DbSet<TEntity> GetDbSetFor<TEntity>(Type model)
            where TEntity : class
        {
            // ver Clients = GetDbSetFor<>(typeof(Client))


            if (model is null)
            {
                return null;
            }

            var entity = this.Set<TEntity>();
            return entity;

        }
    }

    public class Fee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal DefaultAmount { get; set; }
    }

    // may implement later for auditing records
    [ComplexType]
    public class Audit
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateLastModified { get; set; }

        public string CreatedBy { get; set; }

        public string LastModifiedBy { get; set; }
    }

    // Computed table
    public class Transit
    {
        public Guid Id { get; set; }

        [Required]
        public Container Container { get; set; }

        [Required]
        public Invoice Invoice { get; set; }

        [NotMapped]
        [DisplayName("Transit State")]
        [Description("Whether the container is in transit.")]
        public TransitState TransitState { get; set; }

        [DisplayName("In Transit")]
        [Description("Whether the container is in transit.")]
        public bool IsPending { get; set; }
    }

    public class Invoice
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Invoice Number")]
        [Description("The invoice number for the invoice.")]
        public int InvoiceNumber { get; set; }

        [Required]
        [Timestamp]
        [DisplayName("Invoice Date")]
        [Description("The date of the invoice.")]
        public DateTime InvoiceDate { get; set; }

        [Required]
        public Client Client { get; set; }

        [Required]
        [StringLength(400)]
        [DisplayName("Master Number")]
        [Description("The steamship line unique identifer.")]
        public string MasterNumber { get; set; }

        [Required]
        [StringLength(400)]
        [DisplayName("House Number")]
        [Description("The optional steamship line unique identifer extension.")]
        public string HouseNumber { get; set; }

        public Container Container { get; set; } // weight and packages gets propagated

        public decimal Rate { get; set; }

        [Required]
        [StringLength(400)]
        [DisplayName("Reference Number")]
        [Description("The reference number as part of the invoice.")] 
        public string ReferenceNumber { get; set; }

        [Required]
        [Timestamp]
        [DisplayName("Container Fee")]
        [Description("The fee associated with renting the container.")]
        public decimal ContainerFee { get; set; }

        [NotMapped]
        [DisplayName("Chassis Days")]
        [Description("The number of days the chassis is rented.")]
        public int ChassisDaysCount { get; }

        [NotMapped]
        [DisplayName("Parking Days")]
        [Description("The number of days the truck is parked for.")]
        public int ParkingDaysCount { get; }

        [NotMapped]
        [DisplayName("Total Invoice")]
        [Description("The total invoice of days the chassis is rented.")]
        public decimal TotalInvoice { get; }

        [Required]
        [StringLength(400)]
        [DisplayName("Pick Up")]
        [Description("The pick up location of the container.")]
        public string FromAddress { get; set; }

        [Required]
        [StringLength(400)]
        [DisplayName("Drop Off")]
        [Description("The drop off location of the container.")]
        public string ToAddress { get; set; }

        [Required]
        [Timestamp]
        [DisplayName("Drop Off Date")]
        [Description("The drop off time of the container.")]
        public DateTime FromDate { get; set; }

        [Required]
        [Timestamp]
        [DisplayName("Pick Up Date")]
        [Description("The pick up time of the container.")]
        public DateTime ToDate { get; set; }
    }

    public class Container
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Container Number")]
        [Description("The unique number of the container.")]
        public string ContainerNumber { get; set; }

        [DisplayName("Weight")]
        [Description("The weight of the container.")]
        public float? Weight { get; set; }

        [DisplayName("Number of Cartons")]
        [Description("The number of cartons contained in the container.")]
        public int CartonsCount { get; set; }
    }

    public class Client
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string State { get; set; }

        [Required]
        [MaxLength(5)]
        public string ZipCode { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Phone]
        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
    }
}
