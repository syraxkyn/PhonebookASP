using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Phonebook.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext():base("DefaultContext")
        {

        }
        public DbSet<HandbookRecord> HandbookRecords { get; set; }
    }
}