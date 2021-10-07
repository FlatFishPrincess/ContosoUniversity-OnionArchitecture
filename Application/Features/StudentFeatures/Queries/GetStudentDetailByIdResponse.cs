using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentFeatures.Queries
{
    public class EnrollmentDTO
    {
        public string CourseTitle { get; set; }
        public Grade Grade { get; set; }
    }
    public class GetStudentDetailByIdResponse
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<EnrollmentDTO> Enrollments { get; set; }
    }
}
