using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSek.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;

namespace AutoSek.ViewModels
{
    class SelecionaDeviceViewModel
    {

        public ObservableCollection<Item> Items
        {
            get;
            set;
        }

        public SelecionaDeviceViewModel()
        {
            SelectDevices();
        }


            public async void SelectDevices()
        {
            this.Items = new ObservableCollection<Item>();

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://138.121.164.7:5000/api/alldevices");
                var resp = await client.GetAsync("");
                if (resp.IsSuccessStatusCode)
                {
                    var respStr = await resp.Content.ReadAsStringAsync();

                    var l = JsonConvert.DeserializeObject<List<Devices>>(respStr);

                    foreach (var foo in l)
                    {
                       
                       
                        this.Items.Add(new Item
                        {
                            Title = foo.name,
                            Description = foo.address,
                            Image = "https://www.itau.com.py/images/ico06.png",
                            Selected = false
                        });

                    }


                }
            }
            catch (Exception ex)
            {
     
            }

        }

        

    }

    public class Item : NotifyBase
    {
        

        string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                this.Notificar("Title");
            }
        }

        string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                this.Notificar("Description");
            }
        }

        string image;
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                this.Notificar("Image");
            }
        }

        bool selected;
        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                this.Notificar("Selected");
            }
        }

        public override string ToString()
        {
            return this.Title;
        }
        




    }

}
