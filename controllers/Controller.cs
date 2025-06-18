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
        private static List<ForceUsers> forceUsers = new List<ForceUsers>()
        {
            new ForceUsers{Name = "Starkiller", ForcePower1 = "ForceLightning"}
        };

        [HttpGet]
        public IEnumerable<ForceUsers> Get()
        {
            return forceUsers;
        }
        // private readonly PeopleContext _context;

        // public ForceUserController(PeopleContext context)
        // {
        //     _context = context;
        // }
        // public async Task<IActionResult> Get()
        // {
        //     var forceUsers = await _context.forceUsers.ToListAsync();
        //     return Ok(forceUsers);
        // }
    }
}