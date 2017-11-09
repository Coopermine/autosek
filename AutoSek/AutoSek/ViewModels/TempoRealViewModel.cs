using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSek.Models;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Acr.UserDialogs;
using System.Net.Http;
using Newtonsoft.Json;

namespace AutoSek.ViewModels
{
    class TempoRealViewModel 
    {
        public ObservableCollection<BindableLocation> Locations { get; set; }

        public ICommand PinCommand;

   

        public TempoRealViewModel()
        {


Task T = Task.Run(() => Marca());
          T.Wait();



        }


        public async Task Marca()
        {
          


            try
            {

              



              

                Task T = Task.Run(() => BuscaCoordenadas(7, 2));
                T.Wait();
                var locations = new List<BindableLocation>();

                foreach (var foo in ListaDeRotas)
                {

                    var location = new BindableLocation
                    {
                        LocationTitle = foo.devicename,
                        LocationDescription = foo.address,
                        Latitude = System.Convert.ToDouble(foo.latitude),
                        Longitude = System.Convert.ToDouble(foo.longitude),
                        ActionCommand = new Command(PinSelected)
                    };
                    locations.Add(location);
                //    UserDialogs.Instance.Alert(foo.latitude.ToString());
                }
                         
              
                Locations = new ObservableCollection<BindableLocation>(locations);
                

            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.ToString() + "Erro linha 79");
            }
        }
     

        public void PinSelected(object param)
        {

            var pin = param as Pin;

            if (pin != null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    UserDialogs.Instance.Alert(pin.Label);
                });
            }
        }
        List<Routes> ListaDeRotas;
        public async Task BuscaCoordenadas(int device,int limit)
        {
          
       
        
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://138.121.164.7:5000/api/routes?deviceid="+ device +"&limit="+limit+"");
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
                
            }




           
        }


    }

}

