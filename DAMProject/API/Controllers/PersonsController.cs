﻿using Microsoft.AspNetCore.Mvc;
using Models.Person;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsService _personsService;

        public PersonsController(IPersonsService personsService)
        {
            _personsService = personsService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddPersonDTO personDTO)
        {
            var result = await _personsService.AddAsync(personDTO);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _personsService.GetAllAsync();

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> GetById(Guid? id)
        {
            var result = await _personsService.GetByIdAsync((Guid)id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var result = await _personsService.DeleteAsync((Guid)id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Update(Guid? id, [FromBody]AddPersonDTO person)
        {
            var result = await _personsService.UpdateAsync((Guid)id, person);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO loginDTO)
        {
            var result = await _personsService.LoginAsync(loginDTO);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }
    }
}
