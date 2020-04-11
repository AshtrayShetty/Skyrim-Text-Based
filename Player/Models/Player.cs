using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Player
    {
        public string name { get; set; }
        public string characterClass { get; set; }
        public int level { get; set; }
        public int XP { get; set; }
        public int gold { get; set; }
        public int health { get; set; }
        public Player(string name, string characterClass, int level, int XP, int gold, int health)
        {
            this.name = name;
            this.characterClass = characterClass;
            this.level = level;
            this.XP = XP;
            this.gold = gold;
            this.health = health;
        }
    }
}
