using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SeedData
{
    public static class UniversityData
    {
        public static void SeedUniversityData(this ModelBuilder builder)
        {
            University JU = new University { Id = 1, Name = "JU", Location = "Amman", ServiceStartDate = new DateTime(1965, 2, 2) };
            University JUST = new University { Id = 2, Name = "JUST", Location = "Irbid", ServiceStartDate = new DateTime(1985, 2, 2) };
            builder.Entity<University>().HasData(JU, JUST);
        }
    }
}
