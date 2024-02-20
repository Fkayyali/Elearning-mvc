using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserCourseRepo
    {
        Task<UserCourse?> RemoveUserCourse(int userId, int courseId);
        Task<UserCourse> AddUserCourse(int userId, int courseId);
    }
}
