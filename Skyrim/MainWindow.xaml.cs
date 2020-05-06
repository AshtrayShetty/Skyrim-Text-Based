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
using Engine;
using log4net;

namespace Skyrim
{
    /// <summary>
    /// Interaction logic for CreateChar.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private GameSession _gameSession;
        public MainWindow()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            _gameSession = new GameSession();
            DataContext = _gameSession;
            //log.Info($"{DataContext.ToString()}");
        }

        private void Button_Click_North(object sender, RoutedEventArgs e)
        {
            if (_gameSession.HasNorth) 
            { 
                _gameSession.CurrentLocation = _gameSession.CurrentWorld.LocationAt(_gameSession.CurrentLocation.xCoord, _gameSession.CurrentLocation.yCoord + 1); 
            }
        }

        private void Button_Click_West(object sender, RoutedEventArgs e)
        {
            if (_gameSession.HasWest)
            {
                _gameSession.CurrentLocation = _gameSession.CurrentWorld.LocationAt(_gameSession.CurrentLocation.xCoord - 1, _gameSession.CurrentLocation.yCoord);
            }
        }

        private void Button_Click_South(object sender, RoutedEventArgs e)
        {
            if (_gameSession.HasSouth)
            {
                _gameSession.CurrentLocation = _gameSession.CurrentWorld.LocationAt(_gameSession.CurrentLocation.xCoord, _gameSession.CurrentLocation.yCoord - 1);
            }
        }

        private void Button_Click_East(object sender, RoutedEventArgs e)
        {
            if (_gameSession.HasEast)
            {
                _gameSession.CurrentLocation = _gameSession.CurrentWorld.LocationAt(_gameSession.CurrentLocation.xCoord + 1, _gameSession.CurrentLocation.yCoord);
            }
        }
    }
}
