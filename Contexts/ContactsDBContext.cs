using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ContactsService.Contexts
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options) { }
        public ContactsDbContext() { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<UserKeys> UserKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
