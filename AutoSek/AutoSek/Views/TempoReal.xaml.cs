using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using AutoSek.Models;
using AutoSek.ViewModels;
using System.Net.Http;
using Newtonsoft.Json;
using Acr.UserDialogs;

namespace AutoSek.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TempoReal : ContentPage
	{
        private TempoRealViewModel _viewModel;
        double lt;
        double lg;
        string name;
        string endereco;
        string velocidade;

        public TempoReal ()
		{

          //  _viewModel = new TempoRealViewModel();

            InitializeComponent ();
            //  BindingContext = _viewModel;

            //     LocationMap.RouteCoordinates.Add(new Position(37.797534, -122.401827));



          

          Task T = Task.Run(() => BuscaCoordenadas(7, 500));
          T.Wait();


            foreach (var foo in ListaDeRotas)
            {

                var pin = new CustomPin
                {
                    Type = PinType.Place,
                    Position = new Position(System.Convert.ToDouble(foo.latitude), System.Convert.ToDouble(foo.longitude)),
                    Label = foo.devicename,
                    Address = foo.address,
                    Id = foo.routeid.ToString(),
                    Url = ""
                };
                
                lt = System.Convert.ToDouble(foo.latitude);
                lg = System.Convert.ToDouble(foo.longitude);

                LocationMap.RouteCoordinates.Add(new Position(lt, lg));

                LocationMap.Pins.Add(pin);

            }

            LocationMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lt, lg), Distance.FromMiles(1.0)));



        }

        List<Routes> ListaDeRotas;
        public async Task BuscaCoordenadas(int device, int limit)
        {



            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://138.121.164.7:5000/api/routes?deviceid=" + device + "&limit=" + limit + "");
                var resp = await client.GetAsync("");
                if (resp.IsSuccessStatusCode)
                {
                    var respStr = await resp.Content.ReadAsStringAsync();

                    var l = JsonConvert.DeserializeObject<List<Routes>>(respStr);

                    ListaDeRotas = l;

                 



                    // NavigationPage page = new NavigationPage(new Views.MainPage());
                    //   AutoSek.App.Current.MainPage = page;

                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert("Consulta indisponivel no momento. Tente mais tarde");
            }





        }



    

    }





}