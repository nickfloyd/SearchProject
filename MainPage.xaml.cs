using SearchProject.Models;
using System;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SearchProject
{
    public sealed partial class MainPage : Page
    {
        public RelatedTopicsViewModel ViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new RelatedTopicsViewModel();
        }

        private void ExecuteSearch(string searchString)
        {

            var t = Task.Run(() => TryGetSearchAsync(searchString));
            t.Wait();

            var relatedTopicsVM = new RelatedTopicsViewModel(t.Result);

            this.ResultsList.ItemsSource = relatedTopicsVM.RelatedTopics;
            this.TopicsList.ItemsSource = relatedTopicsVM.Topics;

        }

        private static bool IsEnterPressed()
        {
            var enterState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Enter);
            return (enterState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
        }

        private void ContentPanel_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (IsEnterPressed())
            {
                ExecuteSearch(searchInput.Text);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExecuteSearch(searchInput.Text);

        }

        /* This approach uses view modles backed by POCO
         * It takes the results off of the response and 
         * saerializes them to the view models
         */
        private async Task<SearchResults> TryGetSearchAsync(string query)
        {
            //Create an HTTP client object
            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

            //Add a user-agent header to the GET request. 
            var headers = httpClient.DefaultRequestHeaders;

            //The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
            //especially if the header value is coming from user input.
            if (!headers.Accept.TryParseAdd("application/json"))
            {
                throw new Exception("Invalid header value");
            }

            var baseUri = new UriBuilder("http://api.duckduckgo.com");
            string queryToAppend = $"q={query}&format=json&pretty=1&no_html=1&skip_disambig=1";

            baseUri.Query = queryToAppend;


            //Send the GET request asynchronously and retrieve the response as a string.
            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
            string httpResponseBody = "";

            SearchResults searchResults = new SearchResults();

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(baseUri.Uri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                searchResults = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchResults>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
            finally
            {
                httpClient.Dispose();
            }

            return searchResults;

        }

    }
}
