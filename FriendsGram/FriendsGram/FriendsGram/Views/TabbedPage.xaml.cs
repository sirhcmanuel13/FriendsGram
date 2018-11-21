using FriendsGram.Services;
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

        PostService postService = new PostService();
        PostsPage postsPage = new PostsPage();
        public TabbedPage()
        {
            InitializeComponent();    
            contentView.Content = postsPage;
            postButton.IsEnabled = false;       
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
            Application.Current.Properties.Clear();
			await Application.Current.SavePropertiesAsync();
		}

		private void FriendButton_Clicked(object sender, EventArgs e)
		{
            contentView.Content = new FriendsPage(postsPage.postViewModel);
            friendButton.IsEnabled = false;
			postButton.IsEnabled = true;
			addPost.Source = "";
            addPost.IsEnabled = false;
            navTitlePosts.IsVisible = false;
            navTitleFriends.IsVisible = true;
        }

		private void PostButton_Clicked(object sender, EventArgs e)
        {
            contentView.Content = postsPage;
            postButton.IsEnabled = false;
			friendButton.IsEnabled = true;
			addPost.Source = "plus.png";
            addPost.IsEnabled = true;
            navTitlePosts.IsVisible = true;
            navTitleFriends.IsVisible = false;      
        }

        private async void Add_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new AddPostPage(postsPage));
		}
	}
}