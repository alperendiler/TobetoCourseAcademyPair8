using Business.Abstracts;
using Business.Requests.InstructorRequests;
using Business.Responses.Cars;
using Business.Responses.InstructorResponse;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        IInstructorService _instructorService;

        public InstructorsController(IInstructorService ınstructorService)
        {
            _instructorService = ınstructorService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateInstructorRequest request)
        {
            await _instructorService.Add(request); return Ok();
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteInstructorRequest request)
        {
             var result = await _instructorService.Delete(request); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromQuery] UpdateInstructorRequest request)
        {
            var result = await _instructorService.Update(request); return Ok(result);
        }
        [HttpGet("GetList")]
        public async Task<IPaginate<GetListInstructorResponse>> GetList([FromQuery] PageRequest request)
        {
            return  await _instructorService.GetListAsync(request); 
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] DeleteInstructorRequest request)
        {
            var result = await _instructorService.GetById(request); return Ok(result);    
        }
      
    }
}
