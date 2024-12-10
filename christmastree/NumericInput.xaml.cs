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
    /// Interaction logic for NumericInput.xaml
    /// </summary>
    public partial class NumericInput : UserControl
    {
        public TextBox textBox;
        public int Value
        {
            get
            {
                try
                {
                    return int.Parse(textbox.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                if (value > 0) textbox.Text = value.ToString();
            }
        }

        public NumericInput()
        {
            InitializeComponent();
            textBox = textbox;
        }

        private void decrButton_Click(object sender, RoutedEventArgs e) => Value--;

        private void incrButton_Click(object sender, RoutedEventArgs e) => Value++;

        private void textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                e.Handled = true;
            }
        }
    }
}
