using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AutoSek.ViewModels;


namespace AutoSek.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelecionaDevice : TabbedPage
    {

        private SelecionaDeviceViewModel _viewModel = new SelecionaDeviceViewModel();
        public SelecionaDevice()
        {
            InitializeComponent();
            this.BindingContext = this._viewModel;
        

        }
        public void MenuItemClicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var item = menuItem.CommandParameter as Item;
      //      string ret = SelecionaDevice(6);
            DisplayAlert("Informações","" , "Ok");

        }
        
        



    }
}