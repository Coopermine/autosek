using AutoSek.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoSek.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            menuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Tempo Real", Icon = "itemIcon3.png", TargetType = typeof(TempoReal) };
            var page2 = new MasterPageItem() { Title = "Rotas", Icon = "itemIcon6.png", TargetType = typeof(Rotas) };
            var page3 = new MasterPageItem() { Title = "Enviar Comandos", Icon = "itemIcon1.png", TargetType = typeof(EnviarComandos) };
            var page4 = new MasterPageItem() { Title = "Visão Geral", Icon = "itemIcon2.png", TargetType = typeof(SelecionaDevice) };
           

            // Adding menu items to menList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);



            
            // Setting our list to be ItemSource for ListView in MainPage.xaml
            ListaNavegacao.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Detail)));

            IsPresented = true;

        }
        private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

          //  ObjLogin.logado = true;


            //if (page.Name.ToString() == "Login")
            //{

            //    //   // abrir pagina login
            //    Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Login)));
            //    IsPresented = false;
            //}
            //else
            //{



              Detail = new NavigationPage((Page)Activator.CreateInstance(page));
              IsPresented = false;


            //}

        }
    }
}