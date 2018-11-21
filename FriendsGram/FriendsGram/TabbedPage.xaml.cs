using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FriendsGram
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TabbedPage : ContentPage
	{
		PostsPage postsPage = new PostsPage();
		public TabbedPage()
		{
			InitializeComponent();
			contentView.Content = postsPage;
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
			contentView.Content = new FriendsPage();
			friendButton.IsEnabled = false;
			postButton.IsEnabled = true;
			addPost.Source = "";
		}

		private void PostButton_Clicked(object sender, EventArgs e)
		{
			contentView.Content = postsPage;
			postButton.IsEnabled = false;
			friendButton.IsEnabled = true;
			addPost.Source = "plus.png";
		}

		private async void Add_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AddPostPage(postsPage));
		}
	}
}