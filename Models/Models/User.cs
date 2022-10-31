using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class User
    {
        public User()
        {
            Members = new HashSet<Member>();
        }

        public string UsrName { get; set; }
        public string UsrMail { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
