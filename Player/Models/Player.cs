using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Player : BaseNotificationClass
    {
        private string _name;
        private string _characterClass;
        private int _level;
        private int _xp;
        private int _gold;
        private int _health;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string CharacterClass
        {
            get => _characterClass;
            set
            {
                _characterClass = value;
                OnPropertyChanged(nameof(CharacterClass));
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
        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                OnPropertyChanged(nameof(Health));
            }
        }
        public Player(string name, string characterClass, int level, int XP, int gold, int health)
        {
            Name = name;
            CharacterClass = characterClass;
            Level = level;
            this.XP = XP;
            Gold = gold;
            Health = health;
        }
    }
}
