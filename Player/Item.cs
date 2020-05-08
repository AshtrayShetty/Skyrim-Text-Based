using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Engine
{
    public class Item : INotifyPropertyChanged 
    {
        private int _id;
        private string _name;
        private string _type;
        private int _value;
        private int _min;
        private int _max;
        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        public int MinDamage
        {
            get => _min;
            set
            {
                _min = value;
                OnPropertyChanged(nameof(MinDamage));
            }
        }
        public int MaxDamage
        {
            get => _max;
            set
            {
                _max = value;
                OnPropertyChanged(nameof(MaxDamage));
            }
        }
        public Item(int id, string name, string type, int val, int minDamage, int maxDamage)
        {
            ID = id;
            Name = name;
            Type = type;
            Value = val;
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
