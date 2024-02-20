using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserRepo
    {
        Task<User?> GetUser(int userId);
        Task<User?> GetUser(String Email, String hashedPassword);
        Task<List<User>> GetStudents(int courseId);
        Task<List<User>> GetFilteredUsers(int courseId);
    }
}
