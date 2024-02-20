using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    internal class UserCourseConfiguration : IEntityTypeConfiguration<UserCourse>
    {
        public void Configure(EntityTypeBuilder<UserCourse> builder)
        {
            //builder.HasKey(uc => new { uc.UserId, uc.CourseId });
            builder.HasOne<User>(uc => uc.User).WithMany(u => u.UserCourses).HasForeignKey(uc => uc.UserId);
            builder.HasOne<Course>(uc => uc.Course).WithMany(u => u.UserCourses).HasForeignKey(uc => uc.CourseId);
        }
    }
}
