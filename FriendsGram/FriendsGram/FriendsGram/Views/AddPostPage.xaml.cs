using FriendsGram.Models;
using FriendsGram.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FriendsGram
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPostPage : ContentPage
	{
        Post posts;
        PostsPage postPage;
        public AddPostPage (PostsPage postPage)
		{
			InitializeComponent();
            this.postPage = postPage;
            BindingContext = postPage;
        }
   
        private async void Save_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Title.Text) && (string.IsNullOrEmpty(Body.Text)))
            {
                DisplayAlert("MESSAGE", "Fill up the blank fields!", "OK");
            }
            else
            {
                posts = new Post
                {
                    Title = this.Title.Text.ToUpper(),
                    Body = this.Body.Text,
                    Image = "https://randomuser.me/api/portraits/lego/0.jpg",
                    UserId = 1                 
                };
                postPage.postViewModel.Posts.Insert(0, posts);
                await Navigation.PopModalAsync();
            }
        }

        async void buttonCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}