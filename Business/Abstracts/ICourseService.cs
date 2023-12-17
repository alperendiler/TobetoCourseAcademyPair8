using Business.Requests;
using Business.Requests.CourseRequests;
using Business.Responses.Cars;
using Business.Responses.CourseResponses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICourseService
    {
        Task<GetCourseResponse> GetByIdAsync(DeleteCourseRequest request);
        Task<IPaginate<GetListCourseResponse>> GetListAsync(PageRequest request);
        Task<GetCourseResponse> AddAsync(CreateCourseRequest request);
        Task<GetCourseResponse> UpdateAsync(UpdateCourseRequest request);
        Task<GetCourseResponse> DeleteAsync(DeleteCourseRequest request);
       
    }
}
