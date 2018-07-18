using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QAForum.Models
{
    [Table("Forums")]
    public class Forum
    {
        [Column()]
        public int ForumID { get; set; }
        [DisplayName("Title")]
        public string ForumTitle { get; set; }
    }
}