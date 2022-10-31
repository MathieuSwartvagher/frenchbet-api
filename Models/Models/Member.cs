using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Member
    {
        public string ComName { get; set; }
        public string UsrName { get; set; }
        public byte? MemIsAdmin { get; set; }
        public byte? MemIsAsking { get; set; }
        public string MemAskingMessage { get; set; }

        public virtual Community ComNameNavigation { get; set; }
        public virtual User UsrNameNavigation { get; set; }
    }
}
