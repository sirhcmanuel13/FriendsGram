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
	public partial class FriendPage : ContentView
	{
		public FriendPage ()
		{
			InitializeComponent ();

			Task.Run(async () =>
			{
				//loadingIndicator.IsRunning = true;
				await GetFriends();
			});
		}

		private async Task GetFriends()
		{
			using (var client = new HttpClient())
			{
				var response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
				var friendResult = JsonConvert.DeserializeObject<List<Friend>>(response.Content.ReadAsStringAsync().Result);

				for (int i = 0; i < friendResult.Count; i++)
				{
					friendResult[i].UserName = "@" + friendResult[i].UserName;
					if (friendResult[i].Id < 10)
					{
						friendResult[i].ImageUrl = $"https://randomuser.me/api/portraits/lego/{friendResult[i].Id}.jpg";
					}
					else
					{
						friendResult[i].ImageUrl = "https://vignette.wikia.nocookie.net/naginoasukara/images/8/86/Placeholder_person.png/revision/latest?cb=20130924151342";
					}
				}

				Device.BeginInvokeOnMainThread(() =>
				{
					friendList.ItemsSource = friendResult.ToList();
					//loadingIndicator.IsRunning = false;
				});
			}
		}

		private void FriendList_ItemTapped(object sender, ItemTappedEventArgs e)
		{

		}
	}
}