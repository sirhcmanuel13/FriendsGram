using FriendsGram.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FriendsGram.Services
{
    public class PostService
    {

        private HttpClient http;
        public async Task<ObservableCollection<Post>> GetPosts()
        {
            using (http = new HttpClient())
            {
                var urlString = "https://jsonplaceholder.typicode.com/posts";
                var response = await http.GetAsync(urlString);
                var x = response.GetType();
                var posts = JsonConvert.DeserializeObject<ObservableCollection<Post>>(response.Content.ReadAsStringAsync().Result);

                foreach (var i in posts)
                {
                    i.Image = string.Format("https://randomuser.me/api/portraits/lego/{0}.jpg", i.UserId - 1);
                }
                return posts;
            }
        }
    }
}




