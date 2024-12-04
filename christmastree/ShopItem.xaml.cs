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
            AddToCartCallback((Decoration)DataContext, int.Parse(quantity.Text));
        }
    }
}
