using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SeedData
{
    public static class CourseData
    {
        public static void SeedCourseData(this ModelBuilder builder)
        {
            Course course1 = new Course { Id = 1, Name = "Math", Description = "Math Math Math" };
            Course course2 = new Course { Id = 2, Name ="Science", Description= "Science Science Science" };
            Course course3 = new Course { Id = 3, Name ="History", Description= "History History History " };
            Course course4 = new Course { Id = 4, Name ="Spanish", Description="Spanish Spanish" };

            builder.Entity<Course>().HasData(course1, course2, course3, course4);
        }
    }
}
