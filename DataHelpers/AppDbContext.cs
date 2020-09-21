using DataHelpers.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataHelpers
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<abcEntity> AbcRecords { get; set; }
        public DbSet<hourEntity> HourRecords { get; set; }
        public DbSet<transferEntity> TransferRecords { get; set; }
    }
}
