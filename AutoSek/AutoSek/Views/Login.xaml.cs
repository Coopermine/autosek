using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using AutoSek.Models;
using AutoSek.ViewModels;
namespace AutoSek.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{

            InitializeComponent ();
            this.BindingContext = new LoginViewModel();
         
        }

       
        
	}
}