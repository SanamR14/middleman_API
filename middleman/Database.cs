using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using middleman.Models;

namespace middleman
{
    public class MiddlemanDbContext : DbContext
    {
        public MiddlemanDbContext(DbContextOptions<MiddlemanDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } //Table Name - Users
        public DbSet<Seller> Sellers { get; set; } //Table Name - Sellers
    }
}

