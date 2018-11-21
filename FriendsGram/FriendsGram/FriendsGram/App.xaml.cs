using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FriendsGram
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
            if (this.Properties.ContainsKey("isLoggedIn"))
            {
                MainPage = new NavigationPage(new TabbedPage());

            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }

        protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
