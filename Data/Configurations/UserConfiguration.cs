using Entity.Lookups;
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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne<University>(user => user.University).WithMany(university => university.Users).HasForeignKey(user => user.UniverstityId);
            builder.HasOne<Role>(user => user.Role).WithMany(role => role.Users).HasForeignKey(user => user.RoleId);

            //builder.HasMany<UserCourse>(s => s.UserCourses);
                        
        }
    }
}
