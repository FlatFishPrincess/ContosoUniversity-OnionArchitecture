using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OfficeAssignment : BaseEntity
    {
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        public int? InstructorID { get; set; }

        public Instructor Instructor { get; set; }
    }
}
