using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.CourseResponses
{
    public class GetCourseResponse
    {
        public Guid Id { get; set; }
        public Guid InstructorId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }
        public  DateTime? UpdatedDate { get; set; }
        public  DateTime? DeletedDate { get; set; }
    }
}
