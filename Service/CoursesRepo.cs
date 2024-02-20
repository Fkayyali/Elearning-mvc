using Data;
using Entity.DTOs;
using Entity.Lookups;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CoursesRepo : ICoursesRepo
    {
        private readonly ApplicationDBContext dBContext;
        public CoursesRepo(ApplicationDBContext dbContext) {
            this.dBContext = dbContext;
        }

        public async Task<Course> AddNewCourse(int userId, AddNewCourseDto newCourseDto)
        {
            Course course = new Course
            {
                Name = newCourseDto.Name,
                Description = newCourseDto.Description,
            };
            await dBContext.Courses.AddAsync(course);
            await dBContext.SaveChangesAsync();

            return course;
        }

        public async Task<Course?> DeleteCourse( int courseId)
        {
            var course = await dBContext.Courses.FirstOrDefaultAsync(course => course.Id == courseId);
            if (course == null) { return null; }
            dBContext.Courses.Remove(course);
            await dBContext.SaveChangesAsync();
            return course;
        }

        public async Task<List<CourseTeacherDto>> GetCourses(int userId)
        {
            var coursesWithTeachers = dBContext.Users
            .Where(u => u.Id == userId)
            .SelectMany(u => u.UserCourses)
            .Select(uc => new CourseTeacherDto
            {
                Id = uc.Course.Id,
                Name = uc.Course.Name,
                Description = uc.Course.Description,
                TeacherName = dBContext.Users
                    .Where(user => user.Role.Name == "Teacher" && user.UserCourses.Any(uc => uc.CourseId == uc.CourseId))
                    .FirstOrDefault().FirstName
            })
            .ToList();

            return coursesWithTeachers;
        }

        public async Task<List<CourseTeacherDto>> GetFilteredCourses(int userId)
        {
            var studentCourses = await dBContext.Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.UserCourses!)
                .Select(uc => uc.CourseId)
                .ToListAsync();


            var otherCoursesWithTeachers = dBContext.Courses
                .Where(course => !studentCourses.Contains(course.Id))
                .Select(course => new CourseTeacherDto
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                    TeacherName = dBContext.Users
                        .Where(user => user.Role.Name == "Teacher" && user.UserCourses.Any(uc => uc.CourseId == course.Id))
                        .FirstOrDefault().FirstName
                })
                .ToList();

            return otherCoursesWithTeachers;
        }
    }
}
