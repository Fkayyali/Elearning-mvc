﻿using Entity.DTOs;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        Task<User?> GetUser(int userId);
        Task<User> AddUser(RegisterDto registerDto);
        Task<User?> GetUser(String Email, String hashedPassword);
        Task<List<User>> GetStudents(int courseId);
        Task<List<User>> GetFilteredUsers(int courseId);
    }
}
