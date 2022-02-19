using AppointmentBookingApi.Data.IRepository;
using AppointmentBookingApi.Dtos.Appointment;
using AppointmentBookingApi.Entities;
using AppointmentBookingApi.ResponseWrapper;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleRepository _ScheduleRepository;
        private readonly IMapper _mapper;
        public SchedulesController(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _ScheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ScheduleForCreateDto scheduleForCreateDto)
        {
            if (scheduleForCreateDto == null)
            {
                return BadRequest();
            }

            var model = _mapper.Map<Schedule>(scheduleForCreateDto);

            var appointments = await _ScheduleRepository.CreateSchedule(model);

            var result = _mapper.Map<List<AppointmentForGetDto>>(appointments.Data);

            return Ok(new Response<List<AppointmentForGetDto>> { Data = result , Count = result.Count});
        }
    }
}
