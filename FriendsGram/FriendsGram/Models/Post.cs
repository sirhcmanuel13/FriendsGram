using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FriendsGram.Models
{
    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }

    }
}
