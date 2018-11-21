using FriendsGram.Model;
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
	public partial class FriendsPage : ContentView
	{
		public FriendsPage()
		{
			InitializeComponent();
			RemoveListviewHighlight();
			RunGetfriends();
		}

		async Task GetFriends()
		{
			try
			{
				using (var client = new HttpClient())
				{
					var urlString = "https://jsonplaceholder.typicode.com/users";
					var response = await client.GetAsync(urlString);
					var friends = JsonConvert.DeserializeObject<List<Friends>>(response.Content.ReadAsStringAsync().Result);
					friends.ForEach(x => x.UserImage = (string.Format("https://randomuser.me/api/portraits/lego/{0}.jpg", x.Id - 1)));

					Device.BeginInvokeOnMainThread(() =>
					{
						listView1.ItemsSource = friends;
					});
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Ex", ex.Message);
			}
		}
		async void buttonGoToProfile_Clicked(object sender, EventArgs e)
		{
			var details = (sender as Button).CommandParameter as Friends;
			await Navigation.PushAsync(new FriendsProfilePage(details));
		}

		async void listView1_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var details = e.Item as Friends;
			await Navigation.PushAsync(new FriendsProfilePage(details));
		}

		private void RemoveListviewHighlight()
		{
			listView1.ItemTapped += (object sender, ItemTappedEventArgs e) =>
			{
				if (e.Item == null) return;

				if (sender is ListView lv) lv.SelectedItem = null;
			};
		}
		private void RunGetfriends()
		{
			Task.Run(async () =>
			{
				await GetFriends();
			});
		}
	}
}
