using AutoMapper;
using Business.Abstracts;
using Business.Requests.CategoryRequests;
using Business.Requests.CourseRequests;
using Business.Responses.Cars;
using Business.Responses.CourseResponses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;
        IMapper _mapper;

        public CourseManager(ICourseDal courseDal, IMapper mapper)
        {
            _courseDal = courseDal;
            _mapper = mapper;

        }

        public async Task<GetCourseResponse> AddAsync(CreateCourseRequest request)
        {
            Course course = _mapper.Map<Course>(request);
            await _courseDal.AddAsync(course);
            GetCourseResponse response = _mapper.Map<GetCourseResponse>(course);
            return response;
        }

        public async Task<GetCourseResponse> DeleteAsync(DeleteCourseRequest request)
        {
            Course course = await _courseDal.GetAsync(predicate: c => c.Id == request.Id);
            await _courseDal.DeleteAsync(course);
            GetCourseResponse response = _mapper.Map<GetCourseResponse>(course);
            return response;

            
        }

        public async Task<GetCourseResponse> GetByIdAsync(DeleteCourseRequest request)
        {
            Course course = await _courseDal.GetAsync(predicate: c=>c.Id == request.Id);
            GetCourseResponse response = _mapper.Map<GetCourseResponse>(course);
            return response;
        }

        public async Task<IPaginate<GetListCourseResponse>> GetListAsync(PageRequest request)
        {
            IPaginate<Course> courses = await _courseDal.GetListAsync(index: request.Index, size: request.Size,include: c=>c.Include(c=>c.Category).Include(c=>c.Instructor));
            var response = _mapper.Map<Paginate<GetListCourseResponse>>(courses);
            return response;
        }

        public async Task<GetCourseResponse> UpdateAsync(UpdateCourseRequest request)
        {
            Course course = _mapper.Map<Course>(request);
            await _courseDal.UpdateAsync(course);
            GetCourseResponse response = _mapper.Map<GetCourseResponse>(course);
            return response;
        }
    }
}
