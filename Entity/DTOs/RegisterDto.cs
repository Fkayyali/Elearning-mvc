using Entity.Lookups;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "First Name can not be blank!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name can not be blank!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email can not be blank!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can not be blank!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password can not be blank!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Role can not be blank!")]
        public int RoleId { get; set; }

        [Required(ErrorMessage ="University can not be blank!")]
        public int UniversityId { get; set; }

    }
}
