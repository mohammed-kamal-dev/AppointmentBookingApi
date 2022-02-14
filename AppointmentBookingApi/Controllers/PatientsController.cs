using AppointmentBookingApi.Data.IRepository;
using AppointmentBookingApi.Dtos.Patient;
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
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public PatientsController(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        // Queries
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var model = await _patientRepository.GetByIdAsync(id);

            if (model == null) return NotFound();

            var result = _mapper.Map<PatientForGetDto>(model);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var models = await _patientRepository.GetAllAsync();

            var result = _mapper.Map<List<PatientForGetDto>>(models);

            return Ok(result);

        }

        // Commands
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PatientForCreateDto patientForCreateDto)
        {
            if (patientForCreateDto == null)
            {
                return BadRequest();
            }

            var model = _mapper.Map<Patient>(patientForCreateDto);

            await _patientRepository.AddAsync(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] PatientForUpdateDto patientForUpdateDto, Guid id)
        {
            if (patientForUpdateDto == null) return BadRequest();

            if (id != patientForUpdateDto.Id) return BadRequest();

            var getModel = await _patientRepository.GetByIdAsync(id);

            if (getModel == null) return NotFound();

            var model = _mapper.Map<Patient>(patientForUpdateDto);

            var updateModel = _mapper.Map(model, getModel);

            await _patientRepository.UpdateAsync(updateModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var getModel = await _patientRepository.GetByIdAsync(id);

            if (getModel == null) return NotFound();

            await _patientRepository.DeleteAsync(getModel);

            return NoContent();
        }
    }
}
