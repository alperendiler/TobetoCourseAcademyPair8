using AutoMapper;
using Business.Abstracts;
using Business.Requests.InstructorRequests;
using Business.Responses.Cars;
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
    public class InstructorManager : IInstructorService
    {
        IInstructorDal _instructorDal;
        IMapper _mapper;
        public InstructorManager(IInstructorDal instructorDal, IMapper mapper)
        {
            _instructorDal = instructorDal;
            _mapper = mapper;
        }

        public async Task<GetListInstructorResponse> Add(CreateInstructorRequest request)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);
              await _instructorDal.AddAsync(instructor);
            var  response = _mapper.Map<GetListInstructorResponse>(instructor);
            return response;

        }

        public async Task<GetListInstructorResponse> Delete(DeleteInstructorRequest request)
        {
            Instructor instructor = await _instructorDal.GetAsync(i =>i.Id == request.Id);
            await _instructorDal.DeleteAsync(instructor);
            var response = _mapper.Map<GetListInstructorResponse>(instructor);
            return response;
        }

       

        public async Task<GetListInstructorResponse> GetById(DeleteInstructorRequest request)
        {
            Instructor instructor = await _instructorDal.GetAsync(predicate: i=>i.Id == request.Id);
            var response = _mapper.Map<GetListInstructorResponse>(instructor);
            return response;
            
        }

        public async Task<IPaginate<GetListInstructorResponse>> GetListAsync(PageRequest request)
        {
            IPaginate<Instructor> instroctors = await _instructorDal.GetListAsync(index: request.Index,size: request.Size);
            var response = _mapper.Map<Paginate<GetListInstructorResponse>>(instroctors);
            return response;
        }

        public async Task<GetListInstructorResponse> Update(UpdateInstructorRequest request)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);
            await _instructorDal.UpdateAsync(instructor);
            var response = _mapper.Map<GetListInstructorResponse>(instructor);
            return response;
        }

        
    }
}
