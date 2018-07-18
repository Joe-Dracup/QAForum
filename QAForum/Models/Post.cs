using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QAForum.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public Guid UserID { get; set; }
        public int ThreadID { get; set; }
        public string PostTitle { get; set; }
        public DateTime PostDateTime { get; set; }
        public string PostBody { get; set; }

    }
}