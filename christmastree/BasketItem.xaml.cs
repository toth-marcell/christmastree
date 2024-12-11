using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace christmastree
{
    /// <summary>
    /// Interaction logic for BasketItem.xaml
    /// </summary>
    public partial class BasketItem : UserControl
    {
        Action<Decoration> RemoveAction;

        public BasketItem(KeyValuePair<Decoration, int> item, Action<Decoration> removeAction, Action<KeyValuePair<Decoration, int>> changedQuantityAction)
        {
            InitializeComponent();
            DataContext = item;
            RemoveAction = removeAction;
            quantity.Value = item.Value;
            quantity.textbox.TextChanged += (s, e) =>
            {
                DataContext = new KeyValuePair<Decoration, int>(((KeyValuePair<Decoration, int>)DataContext).Key, quantity.Value);
                changedQuantityAction((KeyValuePair<Decoration, int>)DataContext);
            };
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveAction(((KeyValuePair<Decoration, int>)DataContext).Key);
        }
    }
}
