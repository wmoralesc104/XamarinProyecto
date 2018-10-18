using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace ProyectoXamarin
{
	public partial class App : Application
	{
        public const string WebServiceUrl = "https://api.thecatapi.com/v1/images/search";

        public App ()
		{
			InitializeComponent();

			//MainPage = new MainPage();

            var mainPage = new MenuPrincipal() { Title = "Menu Principal" };

            MainPage = new NavigationPage(mainPage)
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.DarkBlue
            };


        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
