using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using Newtonsoft.Json;
namespace christmastree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Decoration> decorations;
        Dictionary<Decoration, int> basket = new Dictionary<Decoration, int>();
        HttpClient httpClient = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
            UpdateBasket();
            LoadDecorations();
        }

        async void LoadDecorations()
        {
            try
            {
                HttpResponseMessage result = await httpClient.GetAsync("http://localhost:8000/api/decorations");
                result.EnsureSuccessStatusCode();
                string body = await result.Content.ReadAsStringAsync();
                decorations = JsonConvert.DeserializeObject<List<Decoration>>(body);
                foreach (Decoration decoration in decorations)
                {
                    shopItemsPanel.Children.Add(new ShopItem(decoration, AddToCart));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba");
            }
        }

        void AddToCart(Decoration decoration, int quantity)
        {
            if (basket.ContainsKey(decoration)) basket[decoration] += quantity;
            else basket[decoration] = quantity;
            UpdateBasket();
        }

        void UpdateBasket()
        {
            basketItemsPanel.Children.Clear();
            int TotalPrice = 0;
            foreach (var item in basket)
            {
                TotalPrice += item.Key.Price * item.Value;
                basketItemsPanel.Children.Add(new BasketItem(item, RemoveFromBasket, ChangeQuantity));
            }
            totalPrice.DataContext = TotalPrice;
        }

        void RemoveFromBasket(Decoration decoration)
        {
            basket.Remove(decoration);
            UpdateBasket();
        }

        void ChangeQuantity(KeyValuePair<Decoration, int> item)
        {
            basket[item.Key] = item.Value;
            UpdateBasket();
        }

        async private void payButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var item in basket)
                {
                    string jsonData = JsonConvert.SerializeObject(new BuyHttpBody(item));
                    StringContent body = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PutAsync("http://localhost:8000/api/decorations", body);
                    if ((int)response.StatusCode == 400)
                    {
                        MessageBox.Show(JsonConvert.DeserializeObject<ApiError>(await response.Content.ReadAsStringAsync()).Msg);
                        break;
                    }
                    response.EnsureSuccessStatusCode();
                }
                basket.Clear();
                UpdateBasket();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba");
            }
        }
    }

    struct BuyHttpBody
    {
        public int id { get; set; }
        public int pcs { get; set; }
        public BuyHttpBody(KeyValuePair<Decoration, int> pair)
        {
            id = pair.Key.Id;
            pcs = pair.Value;
        }
    }

    struct ApiError
    {
        public string Msg { get; set; }
    }
}
