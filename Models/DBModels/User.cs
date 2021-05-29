using System;
using System.Collections.Generic;

#nullable disable

namespace CytoscapeDijkstra2.Models.DBModels
{
    public partial class User
    {
        public User()
        {
            Graphsdata = new HashSet<Graphsdatum>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public byte[] Password { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime? DateLastLogin { get; set; }
        public ulong IsDeleted { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<Graphsdatum> Graphsdata { get; set; }
    }
}
