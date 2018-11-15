using FriendsGram.Model;
using FriendsGram.Models;
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

namespace FriendsGram
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FriendsProfilePage : ContentPage
	{
		Friends friends;
		public FriendsProfilePage(Friends friends = null)
		{
			InitializeComponent();
			this.friends = new Friends();
			this.friends = friends;
			BindingContext = this.friends;
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
					var postsWithSameId = posts.Where(x => x.UserId == friends.Id);
					posts.ForEach(x => x.Image = (string.Format("https://randomuser.me/api/portraits/lego/{0}.jpg", friends.Id - 1)));

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