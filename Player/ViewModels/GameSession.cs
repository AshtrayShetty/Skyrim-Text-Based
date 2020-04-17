using Engine.EventArgs;
using Engine.Factories;
using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotificationClass 
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        private Player _currentPlayer;
        private Monster _currentMonster;
        private Location _currentLocation;

        public Player CurrentPlayer
        {
            get => _currentPlayer;
            set
            {
                _currentPlayer = value;
            }
        }
        public Monster CurrentMonster
        {
            get => _currentMonster;
            set
            {
                _currentMonster = value;
                _currentMonster.SetHealth(CurrentPlayer);
                _currentMonster.SetLevel(CurrentPlayer);
            }
        }
        public Location CurrentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;
            }
        }
        public World CurrentWorld { get; set; }
        public GameSession()
        {
            CurrentPlayer = new Player("", "", 1, 0, 50, 100);
            CurrentWorld = WorldFactory.CreateWorld();
            CurrentLocation = CurrentWorld.LocationAt(0, 0);
            
        }
        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }
    }
}
