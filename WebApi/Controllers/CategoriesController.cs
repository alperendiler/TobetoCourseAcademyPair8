using Business.Abstracts;
using Business.Requests.CategoryRequests;
using Business.Responses.Cars;
using Business.Responses.CategoryResponses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateCategoryRequest request)
        {
           var result =  await _categoryService.Add(request); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryRequest request)
        {
           var result =  await _categoryService.Update(request); return Ok(result);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteCategoryRequest request)
        {
           var result =  await _categoryService.Delete(request); return Ok(result);
        }
        [HttpGet("GetByList")]
        public async Task<IPaginate<GetListCategoryResponse>>GetList([FromQuery] PageRequest request)
        {
            return await _categoryService.GetListAsync(request);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] DeleteCategoryRequest request)
        {
            var result = await _categoryService.GetById(request); 
            return Ok(result);
        }
    }
}
