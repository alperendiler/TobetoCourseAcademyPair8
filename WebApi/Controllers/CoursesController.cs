using Azure.Core;
using Business.Abstracts;
using Business.Requests;
using Business.Requests.CourseRequests;
using Business.Responses.Cars;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCourseRequest request)
        {
            return Ok(await _courseService.AddAsync(request));
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCourseRequest request)
        {
            return Ok(await (_courseService.UpdateAsync(request)));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCourseRequest request)
        {
            return Ok(await _courseService.DeleteAsync(request));
        }
        [HttpGet("GetList")]
        public async Task<IPaginate<GetListCourseResponse>> GetList([FromQuery] PageRequest request)
        {
            return await _courseService.GetListAsync(request);
        }
        [HttpGet("Get")]
       public async Task<IActionResult> GetByIdAsync([FromQuery] DeleteCourseRequest request)
        {
            var result = await _courseService.GetByIdAsync(request);
            return Ok(result);
        }

    }
}
