using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace FriendsGram.Services
{
    public class ServiceBase<T>
    {
        private HttpClient http;
        public async Task Retrieve()
        {
            try
            {
                using (http = new HttpClient())
                {
                    
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException.Message);
            }
        }
    }
}
