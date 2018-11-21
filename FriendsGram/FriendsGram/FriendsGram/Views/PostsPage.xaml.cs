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
            AIndicator.IsRunning = true;
            AIndicatorLayout.IsVisible = true;
            BindingContext = postViewModel = new PostViewModel();
            postViewModel.IsBusy = true;
            Device.BeginInvokeOnMainThread(() =>
            {
                listView.ItemsSource = postViewModel.Posts;
                AIndicator.IsRunning = false;
                AIndicatorLayout.IsVisible = false;
            });

            listView.SelectedItem = null;

        }


        private void listView_Refreshing(object sender, EventArgs e)
        {
            BindingContext = postViewModel = new PostViewModel();
            listView.ItemsSource = postViewModel.Posts;
            listView.IsRefreshing = false;
            listView.EndRefresh();

        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listView.SelectedItem = null;
        }
    }
}