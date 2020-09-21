using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataHelpers.Setup
{
    public static class AppDbContextExtensions
    {
        public static void SeedAppDbContext(this AppDbContext appDbContext)
        {
            appDbContext.AbcRecords.AddRange(
                new Entities.abcEntity { Id = 1, Date = DateTime.Now.AddDays(-5).ToShortDateString(),WeekNumber = 29, DayNumber = 6, Sales=100 },
                new Entities.abcEntity { Id = 2, Date = DateTime.Now.AddDays(-4).ToShortDateString(), WeekNumber = 29, DayNumber = 5, Sales = 110 },
                new Entities.abcEntity { Id = 3, Date = DateTime.Now.AddDays(-3).ToShortDateString(), WeekNumber = 29, DayNumber = 4, Sales = 120 },
                new Entities.abcEntity { Id = 4, Date = DateTime.Now.AddDays(-2).ToShortDateString(), WeekNumber = 29, DayNumber = 3, Sales = 130 },
                new Entities.abcEntity { Id = 5, Date = DateTime.Now.AddDays(-1).ToShortDateString(), WeekNumber = 29, DayNumber = 2, Sales = 140 },
                new Entities.abcEntity { Id = 6, Date = DateTime.Now.AddDays(0).ToShortDateString(), WeekNumber = 29, DayNumber = 1, Sales = 150 }
                );

            appDbContext.HourRecords.AddRange(
                new Entities.hourEntity { Id = 1, Date = DateTime.Now.AddDays(-5).ToShortDateString(), DayNumber = 6, Hours = 11, WeekNumber = 29 },
                new Entities.hourEntity { Id = 2, Date = DateTime.Now.AddDays(-4).ToShortDateString(), DayNumber = 5, Hours = 10, WeekNumber = 29 },
                new Entities.hourEntity { Id = 3, Date = DateTime.Now.AddDays(-3).ToShortDateString(), DayNumber = 4, Hours = 9, WeekNumber = 29 },
                new Entities.hourEntity { Id = 4, Date = DateTime.Now.AddDays(-2).ToShortDateString(), DayNumber = 3, Hours = 8, WeekNumber = 29 },
                new Entities.hourEntity { Id = 5, Date = DateTime.Now.AddDays(-1).ToShortDateString(), DayNumber = 2, Hours = 7, WeekNumber = 29 }
                );

            appDbContext.TransferRecords.AddRange(
                new Entities.transferEntity { Id = 1, Date = DateTime.Now.AddDays(-5).ToShortDateString(), DayNumber = 6, WeekNumber = 29, Transfers = "10" },
                new Entities.transferEntity { Id = 2, Date = DateTime.Now.AddDays(-4).ToShortDateString(), DayNumber = 5, WeekNumber = 29, Transfers = "20" },
                new Entities.transferEntity { Id = 3, Date = DateTime.Now.AddDays(-3).ToShortDateString(), DayNumber = 4, WeekNumber = 29, Transfers = "30" },
                new Entities.transferEntity { Id = 4, Date = DateTime.Now.AddDays(-2).ToShortDateString(), DayNumber = 3, WeekNumber = 29, Transfers = "40" }
                );

            appDbContext.SaveChanges();
            //detach everything
            foreach (var entity in appDbContext.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }
        }
    }
}
