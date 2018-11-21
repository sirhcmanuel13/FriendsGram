using FriendsGram.Model;
using FriendsGram.ViewModels;
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
        FriendViewModel friendViewModel;
        PostViewModel postViewModel;
		public FriendsPage(PostViewModel postViewModel)
		{
			InitializeComponent();
            AIndicator.IsRunning = true;
            AIndicatorLayout.IsVisible = true;
            friendViewModel = new FriendViewModel();
            this.postViewModel = postViewModel;
            Device.BeginInvokeOnMainThread(() =>
            {
                ListView1.ItemsSource = friendViewModel.FriendsList;
                AIndicator.IsRunning = false;
                AIndicatorLayout.IsVisible = false;
            });
		}

        private void ListView1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView1.SelectedItem = null;
        }

        private async void ListView1_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var profile = e.Item as Friends;
            friendViewModel = new FriendViewModel(profile,postViewModel);
            await Navigation.PushModalAsync(new FriendsProfilePage(friendViewModel));
        }
    }
}
