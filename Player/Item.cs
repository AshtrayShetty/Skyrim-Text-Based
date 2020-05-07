using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Engine
{
    public class Item
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public Item(string name, string type, int val, int minDamage, int maxDamage)
        {
            Name = name;
            Type = type;
            Value = val;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }
    }
}
