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

namespace WPF_API__2
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
                    var variable = JsonConvert.DeserializeObject<Results>(content);

                    foreach (var item in variable.results)
                    {
                        lstPokemon.Items.Add(item);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetMorePokemonInfo();
        }

        private void GetMorePokemonInfo()
        {
            var selectedItem = ((Result)lstPokemon.SelectedItem);

            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(selectedItem.url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var variable = JsonConvert.DeserializeObject<pokemon>(content);

                    txtPokemonInformation.Text = variable.ToString();
                }
            }
        }
    }
}
