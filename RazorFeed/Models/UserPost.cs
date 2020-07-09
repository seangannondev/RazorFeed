using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorFeed.Models
{
    public class UserPost
    {
        public int Id { get; set; }
        public string UuserId { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
    }
}
