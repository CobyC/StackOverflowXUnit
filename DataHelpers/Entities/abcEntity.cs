using System;
using System.Collections.Generic;
using System.Text;

namespace DataHelpers.Entities
{
    public class abcEntity
    {
        public int Id { get; set; }

        public int WeekNumber { get; set; }

        public string Date { get; set; }

        public int DayNumber { get; set; }

        public int Sales { get; set; }

    }

    public class hourEntity
    {
        public int Id { get; set; }
        public int WeekNumber { get; set; }

        public string Date { get; set; }

        public int DayNumber { get; set; }
        public double Hours { get; set; }
    }

    public class transferEntity
    {
        public int Id { get; set; }
        public int WeekNumber { get; set; }

        public string Date { get; set; }

        public int DayNumber { get; set; }

        public string Transfers { get; set; }
    }
}
