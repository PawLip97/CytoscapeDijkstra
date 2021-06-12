using CytoscapeDijkstra2.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CytoscapeDijkstra2.Services
{
    public interface IGraphService
    {
        List<Graphsdatum> GetAllGraphs();
        List<Graphsdatum> GetUsersGraphs(int userId);
        Graphsdatum GetById(int id);
        Graphsdatum Save(int userId, string name, string dataJson, int nodesCount, int edgesCount);
        void Update(int id, Graphsdatum user);
        void Delete(int id);
    }

    public class GraphService : IGraphService
    {
        private dijkstraContext context;

        public GraphService(dijkstraContext context)
        {
            this.context = context;
        }

        public List<Graphsdatum> GetAllGraphs()
        {
            return context.Graphsdata.Where(p => p.IsDeleted == 0).ToList();
        }

        public List<Graphsdatum> GetUsersGraphs(int userId)
        {
            return context.Graphsdata.Where(p => p.IsDeleted == 0 && p.UserId == userId).ToList();
        }

        public Graphsdatum GetById(int id)
        {
            return context.Graphsdata.Where(p => p.Id == id).FirstOrDefault();
        }

        public Graphsdatum Save(int userId, string name, string dataJson, int nodesCount, int edgesCount)
        {
            var newGraph = new Graphsdatum();

            newGraph.UserId = userId;
            newGraph.Name = name;
            newGraph.Data = dataJson;
            newGraph.DateCreated = DateTime.Now;
            newGraph.IsDeleted = 0;
            newGraph.NodesCount = nodesCount;
            newGraph.EdgesCount = edgesCount;

            context.Graphsdata.Add(newGraph);
            context.SaveChanges();

            return newGraph;
        }

        public void Update(int id, Graphsdatum user)
        {
            // TODO
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var graph = context.Graphsdata.Where(p => p.Id == id).FirstOrDefault();

            if (graph != null)
            {
                context.Graphsdata.Remove(graph);
                context.SaveChanges();
            }
        }
    }
}
