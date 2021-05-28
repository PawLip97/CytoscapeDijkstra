using CytoscapeDijkstra2.Models.DBModels;
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
        private readonly dijkstraContext _context;

        public UsersController(dijkstraContext context)
        {
            _context = context;
        }

        /*
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
          return await _context.Users.ToListAsync();
        }
        */

        [HttpGet]
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            return _context.Users.Where(p => p.Id == id).FirstOrDefault();
        }

        /*
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}
