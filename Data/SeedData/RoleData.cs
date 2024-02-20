using Entity.Lookups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SeedData
{
    public static class RoleData
    {
        public static void SeedRoleData(this ModelBuilder builder)
        {
            Role student = new Role { Id = 1, Name = "Student", Description = "Student" };
            Role teacher = new Role { Id = 2, Name = "Teacher", Description = "Teacher" };

            builder.Entity<Role>().HasData(student, teacher);
        }

    }
}
