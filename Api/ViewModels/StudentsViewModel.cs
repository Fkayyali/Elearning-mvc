using Entity.Models;

namespace Api.ViewModels
{
    public class StudentsViewModel
    {
        public List<User> Students { get; set; } = [];
        public int CourseId { get; set; }
    }
}
