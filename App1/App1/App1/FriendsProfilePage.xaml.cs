using App1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FriendsProfilePage : ContentPage
	{
        Friends friendz;
        public FriendsProfilePage(Friends friends = null)
		{
			InitializeComponent ();
            this.friendz = new Friends();
            this.friendz = friends;
            BindingContext = this.friendz;
            RunGetPost();
        }
        async Task GetPosts()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var urlString = "https://jsonplaceholder.typicode.com/posts";
                    var response = await client.GetAsync(urlString);
                    var posts = JsonConvert.DeserializeObject<List<Post>>(response.Content.ReadAsStringAsync().Result);
                    var postsWithSameId = posts.Where(x => x.UserId == friendz.Id);
                    posts.ForEach(x => x.UserImage = (string.Format("https://randomuser.me/api/portraits/lego/{0}.jpg", friendz.Id - 1)));

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        listView1.ItemsSource = postsWithSameId;
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ex", ex.Message);
            }
        }
        private void RunGetPost()
        {
            Task.Run(async () =>
            {
                await GetPosts();
            });
        }

    }

}