using GeoPet.Application.DTOs;
using GeoPet.Application.Interfaces;
using GeoPet.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeoPet.API.Controllers;
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class PetOwnersController : ControllerBase
    {
        private readonly IPetOwnerService _petOwnerService;
        public PetOwnersController(IPetOwnerService petOwnerService)
        {
            _petOwnerService = petOwnerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetOwnerDTO>>> Get()
        {
            var petOwners = await _petOwnerService.GetPetOwners();
            return Ok(petOwners);
        }

        [HttpGet("{id}", Name = "GetPetOwner")]
        public async Task<ActionResult<PetOwner>> Get(int id)
        {
            var petOwner = await _petOwnerService.GetById(id);

            if (petOwner == null)
            {
                return NotFound();
            }
            return Ok(petOwner);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PetOwnerDTO petOwnerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _petOwnerService.Add(petOwnerDto);

            return new CreatedAtRouteResult("GetPetOwner",
                new { id = petOwnerDto.Id }, petOwnerDto);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PetOwnerDTO petOwnerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != petOwnerDto.Id)
            {
                return BadRequest();
            }
            await _petOwnerService.Update(petOwnerDto);
            return Ok(petOwnerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PetOwner>> Delete(int id)
        {
            var petOwnerDto = await _petOwnerService.GetById(id);
            if (petOwnerDto == null)
            {
                return NotFound();
            }
            await _petOwnerService.Remove(id);
            return Ok(petOwnerDto);
        }
    }
