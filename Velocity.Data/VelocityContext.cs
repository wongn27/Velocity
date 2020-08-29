using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Velocity.Data.Enums;
using Velocity.Data.Interfaces;

namespace Velocity.Data
{
    public class VelocityContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Transit> Transits { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Velocity");
        }

        public DbSet<TEntity> GetDbSetFor<TEntity>()
            where TEntity : class
        {
            DbSet<TEntity> entity = this.Set<TEntity>();
            return entity;
        }
    }


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
    public class Transit : IIdentity
    {
        public Guid Id { get; set; }

        [Required]
        public Container Container { get; set; }

        [Required]
        public Invoice Invoice { get; set; }

        [NotMapped]
        [Display(Name = "Transit State")]
        [Description("Whether the container is in transit.")]
        public TransitState TransitState { get; set; }

        [Display(Name = "In Transit")]
        [Description("Whether the container is in transit.")]
        public bool IsPending { get; set; }
    }

    public class InvoiceDetail : IIdentity
    {
        public Guid Id { get; set; }

        [Required]
        public Invoice Invoice { get; set; }

        public int Quantity { get; set; }

        [NotMapped]
        public string Description { get; }

        public Container Container { get; set; }

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
        public Client Client { get; set; }

        public IEnumerable<InvoiceDetail> InvoiceDetails { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Terms")]
        [Description("The terms for the invoice.")]
        public string Terms { get; set; }

        [Required]
        [Display(Name = "Total Invoice")]
        [Description("The total invoice of days the chassis is rented.")]
        public decimal TotalInvoice { get; set; }
    }

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
    }
}
