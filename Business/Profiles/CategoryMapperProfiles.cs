using AutoMapper;
using Business.Requests.CategoryRequests;
using Business.Requests.CourseRequests;
using Business.Responses.Cars;
using Business.Responses.CategoryResponses;
using Business.Responses.CourseResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CategoryMapperProfiles : Profile
    {
        public CategoryMapperProfiles()
        {   
            CreateMap<Paginate<GetListCategoryResponse>, Paginate<Category>>().ReverseMap();
            CreateMap<Category, GetListCategoryResponse>().ReverseMap();
            CreateMap<DeleteCategoryRequest, Category>().ReverseMap();
            CreateMap<UpdateCategoryRequest, Category>().ReverseMap();
            CreateMap<CreateCategoryRequest, Category>().ReverseMap();
        }

    }
}
