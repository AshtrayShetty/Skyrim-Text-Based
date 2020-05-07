using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class GameSession : INotifyPropertyChanged 
    {
        private Location _currentLocation;
        private Monster _currentMonster;
        private Player _currentPlayer;
        public Player CurrentPlayer
        {
            get => _currentPlayer;
            set
            {
                _currentPlayer = value;
                OnPropertyChanged(nameof(Player));
            }
        }
        public World CurrentWorld { get; set; }
        public Location CurrentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(HasNorth));
                OnPropertyChanged(nameof(HasSouth));
                OnPropertyChanged(nameof(HasWest));
                OnPropertyChanged(nameof(HasEast));

                GiveQuestAtLocation();
                GetMonstersAtLocation();
            }
        }
        public Monster CurrentMonster
        {
            get => _currentMonster;
            set
            {
                _currentMonster = value;
                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));

                if (CurrentMonster != null)
                {
                    RaiseMessage("");
                    RaiseMessage($"You see a {CurrentMonster.Name} here.");
                }
            }
        }
        public GameSession()
        {
            CurrentPlayer = new Player("Dohvak", "Nord", 100, 1, 0, 0);
            ItemFactory.AddItem(1, 1, CurrentPlayer.Inventory);
            CurrentWorld = WorldFactory.CreateWorld();
            CurrentLocation = CurrentWorld.LocationAt(0, 0);
        }
        public bool HasNorth => CurrentWorld.LocationAt(CurrentLocation.xCoord, CurrentLocation.yCoord + 1) != null;
        public bool HasSouth => CurrentWorld.LocationAt(CurrentLocation.xCoord, CurrentLocation.yCoord - 1) != null;
        public bool HasEast => CurrentWorld.LocationAt(CurrentLocation.xCoord + 1, CurrentLocation.yCoord) != null;
        public bool HasWest => CurrentWorld.LocationAt(CurrentLocation.xCoord - 1, CurrentLocation.yCoord) != null;
        public bool HasMonster => CurrentMonster != null;
        private void GetMonstersAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster();
        }
        private void GiveQuestAtLocation()
        {
            if (CurrentLocation.QuestHere != null)
            {
                CurrentPlayer.Quests.Add(CurrentLocation.QuestHere);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Custom event. (to raise message in the rich text box on some event)
        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }
    }
}
