using FriendsGram.Models;
using FriendsGram.Services;
using FriendsGram.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	public partial class PostsPage : ContentView
	{
        public PostViewModel postViewModel;
        public ObservableCollection<Post> postList;
        public PostsPage ()
		{
			InitializeComponent ();
            BindingContext = postViewModel = new PostViewModel();
            Device.BeginInvokeOnMainThread(() => this.listView.ItemsSource = postViewModel.Posts);
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPostPage(this));
        }

        private void listView_Refreshing(object sender, EventArgs e)
        {
            BindingContext = postViewModel = new PostViewModel();
            listView.ItemsSource = postViewModel.Posts;
            listView.IsRefreshing = false;
            listView.EndRefresh();
        }
    }
}