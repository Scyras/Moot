using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moot.DB.Items;
using Moot.Environments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moot.DB
{
    public class MootContext : DbContext
    {
        public MootContext(DbContextOptions<MootContext> options)
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }
    }
}
