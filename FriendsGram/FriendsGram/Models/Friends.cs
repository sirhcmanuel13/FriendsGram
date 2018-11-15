using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsGram.Model
{
    public class Friends
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string NameAndUsername
        {
            get
            {
                return string.Format($"{Name}{Environment.NewLine}@{Username}");
            }
        }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string UserImage { get; set; }
        //{
        //    get
        //    {
        //       return string.Format("https://randomuser.me/api/portraits/lego/0.jpg");
        //    }
        //}
    }
}
