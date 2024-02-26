using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class AddNewCourseDto
    {
        [Required(ErrorMessage = "Name can not be blank!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description can not be blank!")]
        public string Description { get; set; }
    }
}
