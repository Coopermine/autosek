using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AutoSek
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<Services.INavigationService, Services.INavigationService>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new Views.MainPage();
            else
                MainPage = new NavigationPage(new Views.MainPage());
        }
    }
}