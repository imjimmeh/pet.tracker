using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pets.Tracker.Shared.Models.Contexts;
using Pets.Tracker.Shared.Models.Pets;
using Microsoft.AspNetCore.Identity;
using Pets.Tracker.Shared.Models.Users;
using System.Security.Claims;

namespace Pets.Tracker.Web.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly UsersDbContext _context;
        private readonly UserManager<PetsTrackerUser> _userManager;


        public PetsController(UsersDbContext context, UserManager<PetsTrackerUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            return await _context.Pets.ToListAsync();
        }

        // GET: api/Pets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest();
            }

            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
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

        // POST: api/Pets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet([Bind("Id,Name,DateOfBirth,Gender,AnimalId")]Pet pet)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return NotFound();

            pet.OwnerId = userId;
            _context.Pets.Add(pet);
            try
            {
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPet", new { id = pet.Id }, pet);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pet>> DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return pet;
        }

        private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.Id == id);
        }
    }
}
