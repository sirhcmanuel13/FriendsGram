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
   
        private void Save_Clicked(object sender, EventArgs e)
        {
            posts = new Post
            {
                Title = this.Title.Text,
                Body = this.Body.Text,
                Image = "https://randomuser.me/api/portraits/lego/0.jpg"
            };
            postPage.postViewModel.Posts.Insert(0, posts);
            ClosePage();
        }

        async void ClosePage()
        {
            await Navigation.PopAsync();
        }


    }
}