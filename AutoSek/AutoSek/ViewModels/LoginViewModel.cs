using AutoSek.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AutoSek.ViewModels
{
    class LoginViewModel : NotifyBase
    {
        public string Nome { get; set; }
        public string Senha { get; set; }

     
        private string _mensagem;
        public string Mensagem
        {
            get { return _mensagem; }
            set
            {
                _mensagem = value;
                Notificar();
            }
        }

        public Command LogarCommand
        {
            get
            {
                return new Command(() =>
                {

                    Logar(Nome,Senha);

                });
            }
        }

        public async void Logar(string name, string password)
        {

         
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://138.121.164.7:5000/api/values?name=" + name + "&pass=" + password + "");
                var resp = await client.GetAsync("");
                if (resp.IsSuccessStatusCode)
                {
                    var respStr = await resp.Content.ReadAsStringAsync();

                    var l = JsonConvert.DeserializeObject<List<User>>(respStr);

                    // ir para pagina 

                    string cf = l[0].name;
                    
                    NavigationPage page = new NavigationPage(new  Views.MainPage());
                    AutoSek.App.Current.MainPage = page;
                   
                }
            }
            catch (Exception ex)
            {
                Mensagem = "Acesso não autorizado";
            }

        }

    }
}
