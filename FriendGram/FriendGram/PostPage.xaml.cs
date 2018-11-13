using FriendGram.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FriendGram
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PostPage : ContentView
	{
		public PostPage ()
		{
			InitializeComponent ();

			Task.Run(async () =>
			{
				//loadingIndicator.IsRunning = true;
				await GetPosts();
			});
		}

		private async Task GetPosts()
		{
			using (var client = new HttpClient())
			{
				var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
				var postResult = JsonConvert.DeserializeObject<List<Post>>(response.Content.ReadAsStringAsync().Result);

				for (int i = 0; i < postResult.Count; i++)
				{
					if (postResult[i].UserId < 10)
					{
						postResult[i].ImageUrl = $"https://randomuser.me/api/portraits/lego/{postResult[i].UserId}.jpg";
					}
					else
					{
						postResult[i].ImageUrl = "https://vignette.wikia.nocookie.net/naginoasukara/images/8/86/Placeholder_person.png/revision/latest?cb=20130924151342";
					}
				}

				Device.BeginInvokeOnMainThread(() =>
				{
					postList.ItemsSource = postResult.ToList();
					//loadingIndicator.IsRunning = false;
				});
			}
		}
	}
}