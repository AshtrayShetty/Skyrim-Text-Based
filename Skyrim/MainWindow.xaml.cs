using System;
using System.Collections.Generic;
using System.IO;
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
using Engine.EventArgs;
using Engine.Models;
using Engine.ViewModels;

namespace Skyrim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly GameSession _gameSession = new GameSession();

        public MainWindow()
        {
            InitializeComponent();
            _gameSession.OnMessageRaised += OnGameMessageRaised;
            DataContext = _gameSession;
        }
        private void OnGameMessageRaised(object sender, GameMessageEventArgs e)
        {
            GameMessages.Document.Blocks.Add(new Paragraph(new Run(e.message)));
            GameMessages.ScrollToEnd();
        }
        private void MoveNorth(object sender, RoutedEventArgs e) { _gameSession.MoveNorth(); }
        private void MoveWest(object sender, RoutedEventArgs e) { _gameSession.MoveWest(); }
        private void MoveEast(object sender, RoutedEventArgs e) { _gameSession.MoveEast(); }
        private void MoveSouth(object sender, RoutedEventArgs e) { _gameSession.MoveSouth(); }
    }
}
