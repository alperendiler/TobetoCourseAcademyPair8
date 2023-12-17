using Azure.Core;
using Business.Requests.CategoryRequests;
using Business.Responses.CategoryResponses;
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
    public interface ICategoryService
    {
        Task<IPaginate<GetListCategoryResponse>> GetListAsync(PageRequest request);
        Task<GetListCategoryResponse> GetById(DeleteCategoryRequest request);
        Task<GetListCategoryResponse> Update(UpdateCategoryRequest request);
        Task<GetListCategoryResponse> Delete(DeleteCategoryRequest request);
        Task<GetListCategoryResponse> Add(CreateCategoryRequest request);
    }
}
