using FriendsGram.Models;
using FriendsGram.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FriendsGram.ViewModels
{
    public class PostViewModel : BaseViewModel
    {

        PostService postService;

        private ObservableCollection<Post> _posts;

        public PostViewModel()
        {
            _posts = new ObservableCollection<Post>();
            postService = new PostService();
            _posts = Task.Run(async () =>  await postService.GetPosts()).Result;         
        }

        public ObservableCollection<Post> Posts
        {
            get
            {
                return _posts;
            }
            set
            {
                OnPropertyChanged();
            }
        }
    }
}
