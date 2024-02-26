using Entity.Lookups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(10)]

        public string FirstName { get; set; }
        [MaxLength(10)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string Email { get; set; }
        [MaxLength(30)]
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int? UniversityId { get; set; }
        public University University { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
    }
}
