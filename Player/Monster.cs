using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class Monster : INotifyPropertyChanged
    {
        private string _name;
        private string _description;
        private int _health;
        private int _gold;
        private int _minDamage;
        private int _maxDamage;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
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
        public int Gold
        {
            get => _gold;
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }
        public int MinDamage
        {
            get => _minDamage;
            set
            {
                _minDamage = value;
                OnPropertyChanged(nameof(MinDamage));
            }
        }
        public int MaxDamage
        {
            get => _maxDamage;
            set
            {
                _maxDamage = value;
                OnPropertyChanged(nameof(MaxDamage));
            }
        }
        public Monster(string name, string desc, int health, int gold, int minDamage, int maxDamage)
        {
            Name = name;
            Description = desc;
            Health = health;
            Gold = gold;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
