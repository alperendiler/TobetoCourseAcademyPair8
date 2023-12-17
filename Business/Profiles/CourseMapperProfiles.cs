using Business.Responses;
using Entities.Concretes;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Paging;
using System.Runtime.ConstrainedExecution;
using Business.Responses.Cars;
using Business.Requests.CourseRequests;
using Business.Responses.CourseResponses;

namespace Business.Profiles
{
    public class CourseMapperProfiles :Profile
    {
        public CourseMapperProfiles()
        {
            CreateMap<Course, GetListCourseResponse>()
                .ForMember(destinationMember: p => p.CategoryName, memberOptions: opt => opt.MapFrom(p => p.Category.Name)).ReverseMap();
            CreateMap<Course, GetListCourseResponse>().ForMember(destinationMember: p => p.InstructorName,
             memberOptions: opt => opt.MapFrom(p => p.Instructor.FirstName)).ReverseMap();
            CreateMap<Paginate<Course>, Paginate<GetListCourseResponse>>().ReverseMap();

            CreateMap<CreateCourseRequest, Course>();
            CreateMap<Course, GetCourseResponse>();
            CreateMap<DeleteCourseRequest, Course>();
            CreateMap<UpdateCourseRequest, Course>();
        }
    }
}
