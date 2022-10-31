using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Community
    {
        public Community()
        {
            Members = new HashSet<Member>();
        }

        public string ComName { get; set; }
        public string ComDesc { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
