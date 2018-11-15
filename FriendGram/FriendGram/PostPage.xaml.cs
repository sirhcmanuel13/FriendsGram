using FriendGram.Interfaces;
using FriendGram.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FriendGram
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PostPage : ContentView
	{
		public PostPage(List<Post> _postList)
		{
			InitializeComponent();
			postList.ItemsSource = _postList.ToList();
		}
	}
}