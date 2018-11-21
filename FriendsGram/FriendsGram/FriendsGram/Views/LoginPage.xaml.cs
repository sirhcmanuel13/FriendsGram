using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FriendsGram
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public Application app;
		public LoginPage()
		{
			InitializeComponent();
			app = Application.Current;
			errorMessage.IsVisible = false;
		}


		private async void Signin_Clicked(object sender, EventArgs e)
		{
			errorMessage.IsVisible = false;
			if (usernameEntry.Text == "admin" && passwordEntry.Text == "admin")
			{
				app.Properties["isLoggedIn"] = "true";
                await app.SavePropertiesAsync();
                Navigation.InsertPageBefore(new TabbedPage(), this);
                await Navigation.PopAsync();
			}
			else
			{
				errorMessage.IsVisible = true;
			}
		}

    }
}