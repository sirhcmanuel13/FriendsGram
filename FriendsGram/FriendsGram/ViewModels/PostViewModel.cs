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
    public class PostViewModel : INotifyPropertyChanged
    {

        PostService postService;

        private ObservableCollection<Post> _posts;

        public PostViewModel()
        {

            _posts = new ObservableCollection<Post>();
            postService = new PostService();
            Posts = Task.Run(async () =>    Posts = await postService.GetPosts()).Result;
          
        }

        public ObservableCollection<Post> Posts
        {
            get
            {
                return _posts;
            }
            set
            {
                _posts = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
