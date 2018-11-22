using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FriendsGram.Models
{
    public class Post
    {
        int userId;
        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
                image = string.Format("https://randomuser.me/api/portraits/lego/{0}.jpg", userId - 1);
            }
        }
        public int Id { get; set; }
        
        public string Title { get; set; }
        public string Body { get; set; }

        string image;
        public string Image {
            get
            {
                return image;
            }
        }

    }
}
