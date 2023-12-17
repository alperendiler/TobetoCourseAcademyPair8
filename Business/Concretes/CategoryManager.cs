using AutoMapper;
using Azure.Core;
using Business.Abstracts;
using Business.Requests.CategoryRequests;
using Business.Responses.CategoryResponses;
using Business.Responses.CourseResponses;
using Business.Responses.InstructorResponse;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        IMapper _mapper;


        public CategoryManager(ICategoryDal categoryDal,IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<GetListCategoryResponse> Add(CreateCategoryRequest request)
        {
            Category category = _mapper.Map<Category>(request);
              await _categoryDal.AddAsync(category);
            GetListCategoryResponse response = _mapper.Map<GetListCategoryResponse>(category);
            return response;

        }

        public async Task<GetListCategoryResponse> Delete(DeleteCategoryRequest request)
        {
            Category category = await _categoryDal.GetAsync(predicate: c=>c.Id == request.Id);
            await _categoryDal.DeleteAsync(category);
            var response = _mapper.Map<GetListCategoryResponse>(category);
            return response;

            
        }

        public async Task<GetListCategoryResponse> GetById(DeleteCategoryRequest request)
        {
            Category category = await _categoryDal.GetAsync(c=>c.Id==request.Id);
            var response = _mapper.Map<GetListCategoryResponse>(category);
            return response;

        }

        public async Task<IPaginate<GetListCategoryResponse>> GetListAsync(PageRequest request)
        {
            IPaginate<Category> categories = await _categoryDal.GetListAsync(index: request.Index, size: request.Size);
            var response = _mapper.Map<Paginate<GetListCategoryResponse>>(categories);
            return response;
        }

        public async Task<GetListCategoryResponse> Update(UpdateCategoryRequest request)
        {
            Category category = _mapper.Map<Category>(request);
            await _categoryDal.UpdateAsync(category);
            var response = _mapper.Map<GetListCategoryResponse>(category);
            return response;

           
        }
    }
}



