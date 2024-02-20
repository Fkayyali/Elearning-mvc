using Data;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserCourseRepo : IUserCourseRepo
    {
        private readonly ApplicationDBContext dBContext;

        public UserCourseRepo(ApplicationDBContext dBContext) {
            this.dBContext = dBContext;
        }
        public async Task<UserCourse> AddUserCourse(int userId, int courseId)
        {
            UserCourse userCourse = new UserCourse
            {
                UserId = userId,
                CourseId = courseId
            };
            await dBContext.UserCourse.AddAsync(userCourse);
            await dBContext.SaveChangesAsync();
            return userCourse;
        }

        public async Task<UserCourse?> RemoveUserCourse(int userId, int courseId)
        {
            var userCourse = await dBContext.UserCourse.FirstOrDefaultAsync(uc => uc.UserId == userId && uc.CourseId == courseId);
            if (userCourse == null) { return null; }
            dBContext.UserCourse.Remove(userCourse);
            await dBContext.SaveChangesAsync();
            return userCourse;
        }
    }
}
