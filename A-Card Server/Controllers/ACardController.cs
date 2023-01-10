using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using A_Card_Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace A_Card_Server.Controllers
{
    [Route("api/acard")]
    public class ACardController : Controller
    {
        private readonly ACardContext _dbContext;

        JsonSerializerOptions options = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };

        #region animal

        public ACardController(ACardContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("animals")]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {
            if (_dbContext.Animals == null)
                return NotFound();

            return await _dbContext.Animals.ToListAsync();
        }

        [HttpGet("animals/{uuid}")]
        public async Task<ActionResult<Animal>> GetAnimal(string uuid)
        {
            if (_dbContext.Animals == null)
                return NotFound();

            var animal = await _dbContext.Animals.FindAsync(uuid);

            if (animal == null)
                return NotFound();

            return animal;
        }

        [HttpPost("animals")]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        {
            _dbContext.Animals.Add(animal);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAnimal), new { uuid = animal.uuid }, animal);
        }

        [HttpPut("animals/{uuid}")]
        public async Task<IActionResult> PutAnimal(string uuid, Animal animal)
        {
            if (uuid != animal.uuid)
                return BadRequest();

            _dbContext.Entry(animal).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!AnimalExists(uuid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool AnimalExists(string UUID)
        {
            return (_dbContext.Animals?.Any(e => e.uuid == UUID)).GetValueOrDefault();
        }

        [HttpDelete("animals/{uuid}")]
        public async Task<IActionResult> DeleteAnimal(string uuid)
        {
            if(_dbContext.Animals == null)
                return NotFound();

            var animal = await _dbContext.Animals.FindAsync(uuid);

            if (animal == null)
                return NotFound();

            _dbContext.Animals.Remove(animal);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region owner



        #endregion
    }
}