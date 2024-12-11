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
    }
}
