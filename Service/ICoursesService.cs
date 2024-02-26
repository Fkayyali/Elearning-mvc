using Entity.DTOs;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICoursesService
    {
        Task<List<CourseTeacherDto>> GetCourses(int userId);
        Task<List<CourseTeacherDto>> GetFilteredCourses(int userId);
        Task<Course?> DeleteCourse(int courseId);
        Task<Course> AddNewCourse(int userId, AddNewCourseDto newCourseDto);
    }
}
