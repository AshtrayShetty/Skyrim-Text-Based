using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class MonsterEncounter
    {
        public int ID { get; set; }
        public double ChanceOfEncounter { get; set; }
        public MonsterEncounter(int id, double chance)
        {
            ID = id;
            ChanceOfEncounter = chance;
        }
    }
}
