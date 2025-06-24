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

    }
}