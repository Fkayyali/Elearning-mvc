using Entity.Models;

namespace Api.ViewModels
{
    public class AddStudentViewModel
    {
        public List<User> FilteredStudents { get; set; } = [];
        public int CourseId { get; set; }
    }
}
