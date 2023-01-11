using GeoPet.Application.DTOs;
using GeoPet.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeoPet.API.Controllers;

    [Route("api/v1/[Controller]")]
    [ApiController]
    public class PetsController : Controller
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // api/pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetDTO>>> Get()
        {
            var pets = await _petService.GetPets();
            return Ok(pets);
        }

        [HttpGet("{id}", Name = "GetPet")]
        public async Task<ActionResult<PetDTO>> Get(int id)
        {
            var pet = await _petService.GetById(id);

            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PetDTO petDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _petService.Add(petDto);

            return new CreatedAtRouteResult("GetPet",
                new { id = petDto.Id }, petDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PetDTO petDto)
        {
            if (id != petDto.Id)
            {
                return BadRequest();
            }

            await _petService.Update(petDto);

            return Ok(petDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PetDTO>> Delete(int id)
        {
            var petDto = await _petService.GetById(id);
            if (petDto == null)
            {
                return NotFound();
            }
            await _petService.Remove(id);
            return Ok(petDto);
        }
    }
