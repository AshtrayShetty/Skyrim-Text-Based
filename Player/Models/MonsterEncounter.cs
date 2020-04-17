using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class MonsterEncounter
    {
        public int ID { get; set; }
        public double ChanceOfEncountering { get; set; }
        public MonsterEncounter(int ID, double chanceOfEncountering)
        {
            this.ID = ID;
            ChanceOfEncountering = chanceOfEncountering;
        }
    }
}
