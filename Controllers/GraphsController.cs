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
            var graphs = graphService.GetAllGraphs();
            return Ok(graphs);
        }

        [HttpGet("usersGraphs/{id}")]
        public IActionResult GetUsersGraphs(int id)
        {
            var graphs = graphService.GetUsersGraphs(id);
            return Ok(graphs);
        }

        [HttpPost("saveGraph")]
        public IActionResult SaveGraph([FromBody] GraphSaveRequest graphSaveRequest)
        {
            var graph = graphService.Save(graphSaveRequest.userId, graphSaveRequest.graphName, graphSaveRequest.data, graphSaveRequest.nodesCount, graphSaveRequest.edgesCount);
            return Ok(graph);
        }

        [HttpDelete("{graphId}")]
        public IActionResult DeleteGraph(int graphId)
        {
            graphService.Delete(graphId);
            return Ok();
        }
    }

    public class GraphSaveRequest
    {
        public int userId { get; set; }
        public string graphName { get; set; }
        public string data { get; set; }
        public int nodesCount { get; set; }
        public int edgesCount { get; set; }
    }
}
