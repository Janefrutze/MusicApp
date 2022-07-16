using GalaSoft.MvvmLight;
using MusicApp.MVVM.Model;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.MVVM.ViewModel
{
    public class MainViewModel 
    {

        public ObservableCollection<Item> Songs { get; set; }


        public ViewModelBase CurrentViewModel { get; }


        public MainViewModel()
        {
            CurrentViewModel = new SearchViewModel();

            Songs = new ObservableCollection<Item>();
            PopulateCollection();

        }


        void PopulateCollection()
        {
            var client = new RestClient();
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("BQBBa7Bl7P7yGZ7WrNXFRZnY34rgQ-tLpBxb6--qR4DlEXJViULpsuLUGfaQjjhPMJNF_y52ExA73NE3KUTdCOed7sMWmejOO57vG4VR5Y8xsIsXmQ59DdF_UWnLMzATJiibM68taFeRGJkM_zjWaVXnC6ANJOcYRzsydMVuc8PjZec", "Bearer");


            var request = new RestRequest("https://api.spotify.com/v1/browse/new-releases", Method.Get);
            request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");

            var response = client.GetAsync(request).GetAwaiter().GetResult();
            Console.WriteLine("Output: ", response);
            var data = JsonConvert.DeserializeObject<TrackModel>(response.Content);

            for (int i = 0; i < data.Albums.Limit; i++)
            {

                var track = data.Albums.Items[i];
                track.Duration = "2:34";
                Songs.Add(track);
            }
        }


    }
}
