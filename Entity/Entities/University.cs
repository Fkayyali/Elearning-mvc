using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class University
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(40)]
        public string Location { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
