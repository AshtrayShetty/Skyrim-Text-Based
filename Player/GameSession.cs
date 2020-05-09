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
        public Item CurrentItem { get; set; }
        public GameSession()
        {
            CurrentPlayer = new Player("Dohvak", "Nord", 100, 1, 0, 0);

            if (!CurrentPlayer.Weapons.Any())
            {
                CurrentPlayer.AddItemToInventory(1, 1);
                CurrentPlayer.AddItemToInventory(2, 1);
            }

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
            if (CurrentLocation.QuestHere != null && !CurrentLocation.QuestHere.IsFinished)
            {
                if (!CurrentPlayer.Quests.Any(quest => quest.Name.Equals(CurrentLocation.QuestHere.Name)))
                {
                    CurrentPlayer.Quests.Add(CurrentLocation.QuestHere);
                }
                while (CurrentLocation.QuestHere.ItemsList.Count != 0)
                {
                    if (CurrentPlayer.Inventory.Any(item => item.ID == CurrentLocation.QuestHere.ItemsList[0].ID))
                    {
                        CurrentPlayer.RemoveItemFromInventory(CurrentPlayer.Inventory.First(item => item.ID == CurrentLocation.QuestHere.ItemsList[0].ID));
                    }
                    else { return; }
                    CurrentLocation.QuestHere.ItemsList.RemoveAt(0);
                }
                CurrentLocation.QuestHere.IsFinished = true;
                RaiseMessage($"You finished the quest \"{CurrentLocation.QuestHere.Name}\"");

                CurrentPlayer.Gold += CurrentLocation.QuestHere.Gold;
                CurrentPlayer.XP += CurrentLocation.QuestHere.XP;
                RaiseMessage($"You recieved {CurrentLocation.QuestHere.Gold} gold");
                RaiseMessage($"You recieved {CurrentLocation.QuestHere.XP} experience points");
            }   
        }
        public void UseInventory()
        {
            if (!HasMonster)
            {
                if (CurrentItem == null)
                {
                    RaiseMessage("You don't have a weapon in your hand");
                    return;
                }
                if (CurrentItem.Type.Equals("Weapon"))
                {
                    RaiseMessage("There is no monster here.");
                    RaiseMessage("You decide it is a stupid idea to take your weapon out.");
                    RaiseMessage("");
                    return;
                }
            }

            if (CurrentItem == null) 
            { 
                RaiseMessage("You must select a weapon to attack");
                return;
            }

            if (CurrentItem.MinDamage < 0)
            {
                CurrentPlayer.Health -= CurrentItem.MinDamage;
                RaiseMessage($"You gained {-CurrentItem.MinDamage} health points");
                RaiseMessage("");
                CurrentPlayer.RemoveItemFromInventory(CurrentItem);
            }
            else
            {
                Random rnd = new Random();
                int damage = rnd.Next(CurrentMonster.MinDamage, CurrentMonster.MaxDamage);
                CurrentMonster.Health -= damage;
                RaiseMessage($"You did {damage} points damage to the {CurrentMonster.Name}");
                RaiseMessage("");

                if (CurrentMonster.Health <= 0)
                {
                    RaiseMessage($"You beat the {CurrentMonster.Name}!!");

                    while (CurrentMonster.RewardItems.Count != 0)
                    {
                        CurrentPlayer.AddItemToInventory(CurrentMonster.RewardItems[0].ID, 1);
                        RaiseMessage($"You received a {CurrentMonster.RewardItems[0].Name}!");
                        CurrentMonster.RewardItems.Remove(CurrentMonster.RewardItems[0]);
                    }
                    RaiseMessage($"You received {CurrentMonster.Gold} gold");
                    CurrentPlayer.Gold += CurrentMonster.Gold;
                    GetMonstersAtLocation();
                }
                else
                {
                    CurrentPlayer.Health -= damage;
                    RaiseMessage($"The {CurrentMonster.Name} dealt {damage} points damage");
                    if (CurrentPlayer.Health <= 0)
                    {
                        RaiseMessage("You succumbed to your injuries in the heat of battle.");
                        RaiseMessage($"The {CurrentMonster.Name} was just too powerful for you to defeat.");
                        RaiseMessage("Taking your last breath, you praised the gods and joined the gods above.");
                        RaiseMessage("The people will surely remember your name for time eternal");
                        CurrentLocation = CurrentWorld.LocationAt(0, 0);
                        CurrentPlayer.Health = 100;
                    }
                }
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
