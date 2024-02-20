using Entity.Lookups;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SeedData
{
    public static class UserData
    {
        public static void SeedUserData(this ModelBuilder builder)
        {

            User user1 = new User { Id = 1, FirstName = "Ali", LastName = "Yousef", Email = "Ali@gmail.com", PasswordHash = "123", RoleId = 1, UniverstityId = 1 };
            User user2 = new User { Id = 2, FirstName = "Ammar", LastName = "Ahmed", Email = "Ammar@gmail.com", PasswordHash = "123", RoleId = 1, UniverstityId = 1 };
            User user3 = new User { Id = 3, FirstName = "Hosny", LastName = "Tamer", Email = "Hosny@gmail.com", PasswordHash = "123", RoleId = 2, UniverstityId = 1 };
            User user4 = new User { Id = 4, FirstName = "Majed", LastName = "Saed", Email = "Majed@gmail.com", PasswordHash = "123", RoleId = 1, UniverstityId = 1 };
            User user5 = new User { Id = 5, FirstName = "Khaled", LastName = "Jaber", Email = "Khaled@gmail.com", PasswordHash = "123", RoleId = 1, UniverstityId = 1 };

            builder.Entity<User>().HasData(user1, user2, user3, user4, user5);
        }
    }
}
