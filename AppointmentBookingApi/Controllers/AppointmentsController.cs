using AppointmentBookingApi.Data.IRepository;
using AppointmentBookingApi.Dtos.Appointment;
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
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        public AppointmentsController(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var model = await _appointmentRepository.GetByIdAsync(id);

            if (model == null) return NotFound();

            var result = _mapper.Map<AppointmentForGetDto>(model);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var models = await _appointmentRepository.GetAllAsync();

            var result = _mapper.Map<List<AppointmentForGetDto>>(models);

            return Ok(result);

        }

        [HttpGet("Filter")]
        public async Task<IActionResult> GetAppointment([FromQuery] AppointmentQueryDto appointmentQueryDto)
        {
            var models = await _appointmentRepository.GetAppointmentsByDoctorAndPeriod(appointmentQueryDto);

            var result = _mapper.Map<List<AppointmentForGetDto>>(models);

            return Ok(result);
        }

        // Commands
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AppointmentForCreateDto appointmentForCreateDto)
        {
            if (appointmentForCreateDto == null)
            {
                return BadRequest();
            }

            var model = _mapper.Map<Appointment>(appointmentForCreateDto);

            await _appointmentRepository.AddAsync(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] AppointmentForUpdateDto appointmentForUpdateDto, Guid id)
        {
            if (appointmentForUpdateDto == null) return BadRequest();

            if (id != appointmentForUpdateDto.Id) return BadRequest();

            var getModel = await _appointmentRepository.GetByIdAsync(id);

            if (getModel == null) return NotFound();

            var model = _mapper.Map<Period>(appointmentForUpdateDto);

            var updateModel = _mapper.Map(model, getModel);

            await _appointmentRepository.UpdateAsync(updateModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var getModel = await _appointmentRepository.GetByIdAsync(id);

            if (getModel == null) return NotFound();

            await _appointmentRepository.DeleteAsync(getModel);

            return NoContent();
        }
    }
}
