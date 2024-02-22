using Data;
using Entity.DTOs;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDBContext dBContext;
        public UserRepo(ApplicationDBContext dbContext)
        {
            this.dBContext = dbContext;
        }

        public async Task<List<User>> GetStudents(int courseId)
        {
            var students = await dBContext.Courses
                .Where(c => c.Id == courseId)
                .SelectMany(c => c.UserCourses)
                .Select(uc => uc.User)
                .Where(u => u.Role.Name == "Student")
                .ToListAsync();
            return students;
        }

        public async Task<User?> GetUser(int userId)
        {
           var user = await dBContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) { return null; }
            return user;
        }
        public async Task<User?> GetUser(String Email, String hashedPassword)
        {
            var user = await dBContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == Email && u.PasswordHash == hashedPassword);
            if (user == null) { return null; }
            return user;
        }

        public async Task<List<User>> GetFilteredUsers(int courseId) { 
            var students = await dBContext.Courses
                .Where(c => c.Id == courseId)
                .SelectMany(c => c.UserCourses)
                .Select(uc => uc.User)
                .Where(u => u.Role.Name == "Student")
                .ToListAsync();
            
            var filteredStudents = await dBContext.Users.Where(u => !students.Contains(u) && u.Role.Name == "Student").ToListAsync();
            return filteredStudents;    
        }

        public async Task<User> AddUser(RegisterDto registerDto)
        {
            User newUser = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                PasswordHash = registerDto.Password,
                RoleId = registerDto.RoleId,
                UniversityId = registerDto.UniversityId,
            };

            var user = await dBContext.Users.AddAsync(newUser);
            await dBContext.SaveChangesAsync();

            return user.Entity;
        }
    }
}
