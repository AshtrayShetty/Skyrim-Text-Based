using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Quest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFinished { get; set; }
        public ObservableCollection<Item> ItemsList { get; set; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> RewardItems { get; set; } = new ObservableCollection<Item>();
        public int Gold { get; set; }
        public int XP { get; set; }
        public Quest(string name, string desc, int gold, int xp)
        {
            Name = name;
            Description = desc;
            Gold = gold;
            XP = xp;
        }
    }
}
