using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_API
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(@"https://pokeapi.co/api/v2/pokemon?limit=964").Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    //Made a "Results" class that is {get; set;} variables
                    var variable = JsonConvert.DeserializeObject<Results>(content);

                    // the .results is the list I created in the intial class Results
                    foreach (var item in variable.results)
                    {
                        LstPokemon.Items.Add(item);
                    }

                }

            }


        }

        private void BtnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            GetMorePokemonInformation();
        }

        private void GetMorePokemonInformation()
        {
            var selectedItem = ((Result)LstPokemon.SelectedItem);
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(selectedItem.url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var variable = JsonConvert.DeserializeObject<Pokemon>(content);

                    txtPokemonInformation.Text = variable.ToString();
                }
            }
        }
    }
}
