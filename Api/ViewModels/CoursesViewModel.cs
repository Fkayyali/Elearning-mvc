using Entity.DTOs;

namespace Api.ViewModels
{
    public class CoursesViewModel
    {
        public List<CourseTeacherDto> Courses { get; set; } = [];
        public bool IsTeacher { get; set; } = false;
    }
}
