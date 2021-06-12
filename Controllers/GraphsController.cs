using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CytoscapeDijkstra2.Services;

namespace CytoscapeDijkstra2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraphsController : Controller
    {
        private IGraphService graphService;
        public GraphsController(IGraphService graphService)
        {
            this.graphService = graphService;
        }

        [HttpGet("allGraphs")]
        public IActionResult GetAll()
        {
            var users = graphService.GetAllGraphs();
            return Ok(users);
        }

        [HttpGet("usersGraphs/{id}")]
        public IActionResult GetUsersGraphs(int id)
        {
            var users = graphService.GetUsersGraphs(id);
            return Ok(users);
        }
    }
}
