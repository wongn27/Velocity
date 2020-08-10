using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Velocity.Data
{
    public class VelocityContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Transit> Transits { get; set; }
    }

    public class Transit
    {
        public Guid Id { get; set; }

        [ForeignKey("Container")]
        public Guid ContainerId { get; set; }

        [Timestamp]
        [DisplayName("Drop Off Date")]
        [Description("The drop off time of the container.")]
        public DateTime FromDate { get; set; }

        [Timestamp]
        [DisplayName("Pick Up Date")]
        [Description("The pick up time of the container.")]
        public DateTime ToDate { get; set; }

        [DisplayName("Pick Up")]
        [Description("The pick up location of the container.")]
        public string FromAddress { get; set; }

        [DisplayName("Drop Off")]
        [Description("The drop off location of the container.")]
        public string ToAddress { get; set; }

        [DisplayName("In Transit")]
        [Description("Whether the container is in transit.")]
        public bool IsPending { get; set; }
    }

    public class Invoice
    {
        public Guid Id { get; set; }

        [Timestamp]
        [DisplayName("Invoice Date")]
        [Description("The date of the invoice.")]
        public DateTime InvoiceDate { get; set; }

        // Fees, Amount, Company/Client
    }

    public class Container
    {
        public Guid Id { get; set; }

        // Unique
        public string ContainerNumber { get; set; }

        // Will EF interpret it as a FK relationship?
        public Client Client { get; set; } 

    }

    public class Client
    {
        public Guid Id { get; set; }

        // Todo: Make some nullable 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }
        
        public string Address { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Name { get; set; }
    }
}
