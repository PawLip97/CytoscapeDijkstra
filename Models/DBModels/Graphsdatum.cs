using System;
using System.Collections.Generic;

#nullable disable

namespace CytoscapeDijkstra2.Models.DBModels
{
    public partial class Graphsdatum
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public ulong IsDeleted { get; set; }
        public int NodesCount { get; set; }
        public int EdgesCount { get; set; }

        public virtual User User { get; set; }
    }
}
