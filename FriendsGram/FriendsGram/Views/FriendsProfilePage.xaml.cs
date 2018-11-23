using FriendsGram.Model;
using FriendsGram.Models;
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
    public partial class FriendsProfilePage : ContentPage
    {
        FriendViewModel friendViewModel;
        public FriendsProfilePage(FriendViewModel friendViewModel)
        {
            try
            {
                InitializeComponent();
                this.friendViewModel = friendViewModel;
                BindingContext = friendViewModel.friends;
                Device.BeginInvokeOnMainThread(() => listView1.ItemsSource = friendViewModel.FriendPosts);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private async void buttonBack_Clicked(object sender, EventArgs e)
        {
            friendViewModel.HasSelected = false;
            await Navigation.PopModalAsync();
        }

        private void listView1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listView1.SelectedItem = null;
        }
    }
}