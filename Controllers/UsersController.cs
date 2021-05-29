using CytoscapeDijkstra2.Models.DBModels;
using CytoscapeDijkstra2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CytoscapeDijkstra2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        /*
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
          return await _context.Users.ToListAsync();
        }
        */

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = userService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Register(string login, string password)
        {
            try
            {
                userService.Create(login, password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /*
        [HttpPost("{login},{password}")]
        public IActionResult RegisterUser(string login, string password)
        {

            _context.Users.Add(new Models.DBModels.User())
        }
        */

        /*
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}
