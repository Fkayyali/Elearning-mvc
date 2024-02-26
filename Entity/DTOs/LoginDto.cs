using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email can not be blank!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can not be blank!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
