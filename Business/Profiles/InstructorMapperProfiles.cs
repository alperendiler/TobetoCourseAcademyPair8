using AutoMapper;
using Business.Requests.CourseRequests;
using Business.Requests.InstructorRequests;
using Business.Responses.Cars;
using Business.Responses.CourseResponses;
using Business.Responses.InstructorResponse;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class InstructorMapperProfiles : Profile
    {
        public InstructorMapperProfiles()
        {
            CreateMap<Paginate<GetListInstructorResponse>,Paginate<Instructor>>().ReverseMap();
            CreateMap<Instructor, GetListInstructorResponse>().ReverseMap();

            CreateMap<CreateInstructorRequest, Instructor>().ReverseMap();
            CreateMap<DeleteInstructorRequest, Instructor>().ReverseMap();
            CreateMap<UpdateInstructorRequest, Instructor>().ReverseMap();
        }
    }
}
