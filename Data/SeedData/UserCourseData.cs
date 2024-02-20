using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SeedData
{
    public static class UserCourseData
    {
        public static void SeedUserCourseData(this ModelBuilder builder)
        {
            UserCourse userCourse1 = new UserCourse { Id = 1, UserId = 1, CourseId = 1 };
            UserCourse userCourse2 = new UserCourse { Id = 2, UserId = 1, CourseId = 2 };
            UserCourse userCourse3 = new UserCourse { Id = 3, UserId = 1, CourseId = 3 };
            UserCourse userCourse4 = new UserCourse { Id = 4, UserId = 2, CourseId = 3 };
            UserCourse userCourse5 = new UserCourse { Id = 5, UserId = 2, CourseId = 4 };
            UserCourse userCourse6 = new UserCourse { Id = 6, UserId = 3, CourseId = 1 };
            UserCourse userCourse7 = new UserCourse { Id = 7, UserId = 3, CourseId = 3 };
            UserCourse userCourse8 = new UserCourse { Id = 8, UserId = 3, CourseId = 4 };
            UserCourse userCourse9 = new UserCourse { Id = 9, UserId = 4, CourseId = 1 };
            UserCourse userCourse10 = new UserCourse { Id = 10, UserId = 4, CourseId = 2 };
            UserCourse userCourse11 = new UserCourse { Id = 11, UserId = 4, CourseId = 4 };
            UserCourse userCourse12 = new UserCourse { Id = 12, UserId = 5, CourseId = 2 };
            builder.Entity<UserCourse>().HasData(userCourse1, userCourse2, userCourse3, userCourse4, userCourse5, userCourse6, userCourse7, userCourse8, userCourse9, userCourse10, userCourse11, userCourse12); ;
        }
    }
}
