using AppointmentBookingApi.Data.IRepository;
using AppointmentBookingApi.Dtos.Doctor;
using AppointmentBookingApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorsController(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        // Queries
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var model = await _doctorRepository.GetByIdAsync(id);

            if (model == null) return NotFound();

            var result = _mapper.Map<DoctorForGetDto>(model);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var models = await _doctorRepository.GetAllAsync();

            var result = _mapper.Map<List<DoctorForGetDto>>(models);

            return Ok(result);

        }

        // Commands
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DoctorForCreateDto doctorForCreateDto)
        {
            if (doctorForCreateDto == null)
            {
                return BadRequest();
            }

            var model = _mapper.Map<Doctor>(doctorForCreateDto);

            await _doctorRepository.AddAsync(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] DoctorForUpdateDto doctorForUpdateDto, Guid id)
        {
            if (doctorForUpdateDto == null) return BadRequest();

            if (id != doctorForUpdateDto.Id) return BadRequest();

            var getModel = await _doctorRepository.GetByIdAsync(id);

            if (getModel == null) return NotFound();

            var model = _mapper.Map<Doctor>(doctorForUpdateDto);

            var updateModel = _mapper.Map(model, getModel);

            await _doctorRepository.UpdateAsync(updateModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var getModel = await _doctorRepository.GetByIdAsync(id);

            if (getModel == null) return NotFound();

            await _doctorRepository.DeleteAsync(getModel);

            return NoContent();
        }

    }
}
