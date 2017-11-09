using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSek.Views
{
    class NavigationService : Services.INavigationService
    {
        public async Task NavigateToLogin()
        {
           await AutoSek.App.Current.MainPage.Navigation.PushAsync(new Views.Login());
        }

        public async Task NavigateToMain()
        {
            await AutoSek.App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
    }
}
