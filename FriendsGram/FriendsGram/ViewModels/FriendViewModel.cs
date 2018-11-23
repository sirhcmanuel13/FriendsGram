using FriendsGram.Model;
using FriendsGram.Models;
using FriendsGram.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FriendsGram.ViewModels
{
    public class FriendViewModel : BaseViewModel
    {
        FriendService friendService;
        PostViewModel postViewModel;
        public Friends friends;
        public FriendViewModel()
        {
            _friendsList = new ObservableCollection<Friends>();
            friendService = new FriendService();
            _friendsList = Task.Run(async () => await friendService.GetFriends()).Result;
        }
        public FriendViewModel(Friends friends,PostViewModel postViewModel)
        {
            this.friends = friends;
            this.postViewModel = postViewModel;
            _friendPosts = new ObservableCollection<Post>();
            friendService = new FriendService();
            _friendPosts = Task.Run(async () => await friendService.GetPostsWithID(this.friends,postViewModel)).Result;
        }
        private ObservableCollection<Friends> _friendsList;
        public ObservableCollection<Friends> FriendsList
        {
            get
            {
                return _friendsList;
            }
            set
            {
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Post> _friendPosts;
        public ObservableCollection<Post> FriendPosts
        {
            get
            {
                return _friendPosts;
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public bool HasSelected { get; set; }
    }
}
