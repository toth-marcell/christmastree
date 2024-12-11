using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace christmastree
{
    /// <summary>
    /// Interaction logic for NumericInput.xaml
    /// </summary>
    public partial class NumericInput : UserControl
    {
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
