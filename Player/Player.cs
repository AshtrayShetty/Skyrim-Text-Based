using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    // INotifyPropertyChanged interface lets the other classes using this class know that a property has been changed
    public class Player : INotifyPropertyChanged
    {
        // Create backing variables to handle the setting of the variables (By default, the variables are auto property)
        private int _health;
        private int _level;
        private int _xp;
        private int _gold;

        // The event handled in the "set" part of the variables
        public string Name { get; set; }
        public string CharacterClass { get; set; }
        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                OnPropertyChanged(nameof(Health));
            }
        }
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public int XP
        {
            get => _xp;
            set
            {
                _xp = value;
                OnPropertyChanged(nameof(XP));
            }
        }
        public int Gold
        {
            get => _gold;
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }
        // Observable collection automatically updates the UI
        public ObservableCollection<Item> Inventory { get; set; } = new ObservableCollection<Item>();
        public List<Item> Weapons => Inventory.Where(i => i.Type.Equals("Weapon") || i.Type.Equals("Potion")).ToList();
        public ObservableCollection<Quest> Quests { get; set; } = new ObservableCollection<Quest>();
        public Player(string name, string charClass, int health, int level, int xp, int gold)
        {
            Name = name;
            CharacterClass = charClass;
            Health = health;
            Level = level;
            XP = xp;
            Gold = gold;
        }

        // Function to add item to inventory and notify UI about change in the Weapons List
        public void AddItemToInventory(int id, int quantity)
        {
            while (quantity > 0)
            {
                Inventory.Add(ItemFactory.AddItem(id));
                --quantity;
                OnPropertyChanged(nameof(Weapons));
            }
        }
        public void RemoveItemFromInventory(Item item)
        {
            Inventory.Remove(item);
            OnPropertyChanged(nameof(Weapons));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            // If any class is listening, only then use the event handler
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
