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
        public string UsernameFormat
        {
            get
            {
                return string.Format($"@{Username}");
            }
        }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string UserImage { get; set; }

        public string Firstname
        {
            get
            {
                var firstname = Name.Split(' ');

                return string.Format("{0}",firstname[0].ToUpper());
            }
        }
    }
}
