using System;
using System.Collections.Generic;
using System.Linq;
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

namespace christmastree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Decoration> decorations = new List<Decoration>
        {
            new Decoration("dísz", 300, 500),
            new Decoration("dísz1", 600, 500),
            new Decoration("dísz2", 500 ,500),
            new Decoration("dísz3", 100, 1),
            new Decoration("dísz4", 100, 2)
        };
        Dictionary<Decoration, int> basket = new Dictionary<Decoration, int>();
        public MainWindow()
        {
            InitializeComponent();
            UpdateBasket();
            foreach (Decoration decoration in decorations)
            {
                shopItemsPanel.Children.Add(new ShopItem(decoration, AddToCart));
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
                basketItemsPanel.Children.Add(new BasketItem(item, RemoveFromBasket));
            }
            totalPrice.DataContext = TotalPrice;
        }

        void RemoveFromBasket(Decoration decoration)
        {
            basket.Remove(decoration);
            UpdateBasket();
        }
    }
}
