using Business.Requests.InstructorRequests;
using Business.Responses.InstructorResponse;
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
    public interface IInstructorService
    {
        Task<IPaginate<GetListInstructorResponse>> GetListAsync(PageRequest request);
        Task<GetListInstructorResponse> GetById(DeleteInstructorRequest request);
        Task<GetListInstructorResponse> Add(CreateInstructorRequest request);
        Task<GetListInstructorResponse> Delete(DeleteInstructorRequest request);
        Task<GetListInstructorResponse> Update(UpdateInstructorRequest request);

    }
}
