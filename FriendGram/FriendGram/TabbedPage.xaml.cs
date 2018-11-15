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
	public partial class TabbedPage : ContentPage
	{
		public List<Post> postList = new List<Post>();
		public TabbedPage ()
		{
			InitializeComponent ();

			Task.Run(async () =>
			{
				//loadingIndicator.IsRunning = true;
				await GetPosts();
			});

			contentView.Content = new PostPage(postList);
			postButton.IsEnabled = false;
		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
			Application.Current.Properties.Clear();
			await Application.Current.SavePropertiesAsync();
		}

		private void FriendButton_Clicked(object sender, EventArgs e)
		{
			contentView.Content = new FriendPage();
			friendButton.IsEnabled = false;
			postButton.IsEnabled = true;
			addPost.Source = "";
		}

		private void PostButton_Clicked(object sender, EventArgs e)
		{
			contentView.Content = new PostPage(postList);
			postButton.IsEnabled = false;
			friendButton.IsEnabled = true;
			addPost.Source = "plus.png";
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
					postList = postResult.ToList();
					//loadingIndicator.IsRunning = false;
				});
			}
		}
	}
}