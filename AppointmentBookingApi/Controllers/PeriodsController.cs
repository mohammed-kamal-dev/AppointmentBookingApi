using AppointmentBookingApi.Data.IRepository;
using AppointmentBookingApi.Dtos.Period;
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
    public class PeriodsController : ControllerBase 
    {
        private readonly IPeriodRepository _periodRepository;
        private readonly IMapper _mapper;

        public PeriodsController(IPeriodRepository periodRepository = null, IMapper mapper = null)
        {
            _periodRepository = periodRepository;
            _mapper = mapper;
        }

        // Queries
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var model = await _periodRepository.GetByIdAsync(id);

            if (model == null) return NotFound();

            var result = _mapper.Map<PeriodForGetDto>(model);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var models = await _periodRepository.GetAllAsync();

            var result = _mapper.Map<List<PeriodForGetDto>>(models);

            return Ok(result);

        }

        // Commands
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PeriodForCreateDto periodForCreateDto)
        {
            if (periodForCreateDto == null)
            {
                return BadRequest();
            }

            var model = _mapper.Map<Period>(periodForCreateDto);

            await _periodRepository.AddAsync(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] PeriodForUpdateDto periodForUpdateDto , Guid id)
        {
            if (periodForUpdateDto == null) return BadRequest();

            if (id != periodForUpdateDto.Id) return BadRequest();

            var getModel = await _periodRepository.GetByIdAsync(id);

            if (getModel == null) return NotFound();

            var model = _mapper.Map<Period>(periodForUpdateDto);

            var updateModel = _mapper.Map(model, getModel);

            await _periodRepository.UpdateAsync(updateModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var getModel = await _periodRepository.GetByIdAsync(id);

            if (getModel == null) return NotFound();

            await _periodRepository.DeleteAsync(getModel);

            return NoContent();
        }
    }
}
