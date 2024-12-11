using System;
using System.Windows;
using System.Windows.Controls;

namespace christmastree
{
    /// <summary>
    /// Interaction logic for ShopItem.xaml
    /// </summary>
    public partial class ShopItem : UserControl
    {
        Action<Decoration, int> AddToCartCallback;
        public ShopItem(Decoration decoration, Action<Decoration, int> addToCartCallback)
        {
            InitializeComponent();
            DataContext = decoration;
            AddToCartCallback = addToCartCallback;
        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            AddToCartCallback((Decoration)DataContext, quantity.Value);
        }
    }
}
