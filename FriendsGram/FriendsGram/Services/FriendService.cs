using FriendsGram.Model;
using FriendsGram.Models;
using FriendsGram.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FriendsGram.Services
{
    public class FriendService
    {


        public async Task<ObservableCollection<Friends>> GetFriends()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var urlString = "https://jsonplaceholder.typicode.com/users";
                    var response = await client.GetAsync(urlString);
                    var friends = JsonConvert.DeserializeObject<ObservableCollection<Friends>>(response.Content.ReadAsStringAsync().Result);
                   // friends.ForEach(x => x.UserImage = (string.Format("https://randomuser.me/api/portraits/lego/{0}.jpg", x.Id - 1)));

                    return friends;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ex", ex.Message);
                return null;
            }
        }

        public async Task<ObservableCollection<Post>> GetPostsWithID(Friends friends,PostViewModel postViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var postsWithSameId = postViewModel.Posts.Where(x => x.UserId == friends.Id).ToList();
                    var friendPosts = new ObservableCollection<Post>(postsWithSameId);
                    return friendPosts;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ex", ex.Message);
                return null;
            }
        }

    }
}
