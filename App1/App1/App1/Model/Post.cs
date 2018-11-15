using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Model
{
    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string UserImage { get; set; }
    }
}
