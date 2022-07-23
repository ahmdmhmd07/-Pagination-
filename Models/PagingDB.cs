using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Models
{
    public class PagingDB :DbContext
    {
        public PagingDB(DbContextOptions<PagingDB> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
