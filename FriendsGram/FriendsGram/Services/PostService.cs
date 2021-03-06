﻿using FriendsGram.Model;
using FriendsGram.Models;
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
using Xamarin.Forms.Internals;

namespace FriendsGram.Services
{
    public class PostService
    {
        private HttpClient http;
        public async Task<ObservableCollection<Post>> GetPosts()
        {
            try
            {
                using (http = new HttpClient())
                {
                    var urlString = "https://jsonplaceholder.typicode.com/posts";
                    var response = await http.GetAsync(urlString);
                    var x = response.GetType();
                    var posts = JsonConvert.DeserializeObject<ObservableCollection<Post>>(response.Content.ReadAsStringAsync().Result);
                    return posts;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException.Message);
                return null;
            }
        }
    }
}




