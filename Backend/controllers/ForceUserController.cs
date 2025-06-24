using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StarWarsApi.models;

namespace StarWarsApi.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForceUserController : ControllerBase
    {
        private readonly PeopleContext _context;

        public ForceUserController(PeopleContext context)
        {
            _context = context;
        }



        //retriving information from the database
        [HttpGet]
        public async Task<IActionResult> GetForceusers()
        {
            var forceUsers = await _context.forceUsers.ToListAsync();
            return Ok(forceUsers);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetForceUserById(int id)
        {
            var forceUsers = await _context.forceUsers.FirstOrDefaultAsync(a => a.Id == id);
            if (forceUsers == null)
            {
                return NotFound();
            }
            return Ok(forceUsers);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetForceUserByName(string name)
        {
            var forceUsers = await _context.forceUsers.FirstOrDefaultAsync(a => a.Name == name.ToLower());
            if (forceUsers == null)
            {
                return NotFound();
            }
            return Ok(forceUsers);
        }

        //Method to add a new forceuser
        [HttpPost]
        public async Task<IActionResult> AddForceUser([FromBody] ForceUsers forceUsers)
        {
            _context.forceUsers.Add(forceUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetForceUserById), new { id = forceUsers.Id }, forceUsers);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditForceUser(int id, [FromBody] ForceUsers forceUsers)
        {
            var currentForceUser = await _context.forceUsers.FindAsync(id);
            if (currentForceUser == null)
            {
                return NotFound($"the force user with id {id} does not exist");
            }
            await _context.SaveChangesAsync();
            return Ok(currentForceUser);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteForceUser(int id)
        {
            var forceUserToRemove = await _context.forceUsers.FindAsync(id);
            if (forceUserToRemove == null)
            {
                return NotFound($"sorry a force user with {id} as id could not be found");
            }

            _context.forceUsers.Remove(forceUserToRemove);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}