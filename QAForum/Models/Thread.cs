using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QAForum.Models
{
    public class Thread
    {
        public int ThreadID { get; set; }
        public int ForumID { get; set; }
        public string ThreadTitle { get; set; }
        public Guid OwnerID { get; set; }
    }
}