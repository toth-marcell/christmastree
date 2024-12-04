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
    /// Interaction logic for BasketItem.xaml
    /// </summary>
    public partial class BasketItem : UserControl
    {
        Action<Decoration> RemoveAction;
        public BasketItem(KeyValuePair<Decoration, int> item, Action<Decoration> removeAction)
        {
            InitializeComponent();
            DataContext = item;
            RemoveAction = removeAction;
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveAction(((KeyValuePair<Decoration, int>)DataContext).Key);
        }
    }
}
