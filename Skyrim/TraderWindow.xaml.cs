using Engine;
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
using System.Windows.Shapes;

namespace Skyrim
{
    /// <summary>
    /// Interaction logic for Trader.xaml
    /// </summary>
    public partial class TraderWindow : Window
    {
        public GameSession Session => DataContext as GameSession;
        public TraderWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Buy(object sender, RoutedEventArgs e)
        {
            Item item = ((FrameworkElement)sender).DataContext as Item;

            Session.CurrentPlayer.Gold -= item.Value;
            Session.CurrentPlayer.AddItemToInventory(item.ID, 1);
            Session.CurrentTrader.Items.Remove(item);
        }

        private void Button_Click_Sell(object sender, RoutedEventArgs e)
        {
            Item item = ((FrameworkElement)sender).DataContext as Item;

            Session.CurrentPlayer.Gold += item.Value;
            Session.CurrentPlayer.RemoveItemFromInventory(item);
            Session.CurrentTrader.Items.Add(item);
        }
    }
}
