using MusicApp.MVVM.Model;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MusicApp.MVVM.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {

        public ObservableCollection<Item> searchSongs { get; set; }

        public SearchViewModel()
        {
            searchTracks("Pussy");
        }
        void searchTracks(String searchString)
        {
            var client = new RestClient();
            searchString = HttpUtility.UrlEncode(searchString);
            var requestURL = "https://api.spotify.com/v1/search?q="+searchString+"&type=track%2Cartist&market=DE&limit=10&offset=5";


            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("BQDKxys9s_N5DpwaL-wunGVdNr7CqqcRrZMPGtYYZebS27I9pG_k33eDL_y7jAr-A7yc0UxugGPdcKL_HpS70eyTBIPuydP3GbzMG0RVJ8sCqusiEVKNWqPWHQHWGPjWzPc4srAlWZhlDrbobh497O1DlhOnIYnXRr3WEZxziIw3wGs", "Bearer");

            System.Diagnostics.Debug.WriteLine("Output: " + requestURL);

            var request = new RestRequest(requestURL, Method.Get);
            request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");

            var response = client.GetAsync(request).GetAwaiter().GetResult();
            System.Diagnostics.Debug.WriteLine("Output: " +  response.Content);
            var data = JsonConvert.DeserializeObject<TrackSearchModel>(response.Content);

           /* for (int i = 0; i < data.Tracks.Limit; i++)
            {
                var track = data.Tracks.Items[i];
                track.Duration = "2:34";
                searchSongs.Add(track);
            }*/
        }
    }
}
