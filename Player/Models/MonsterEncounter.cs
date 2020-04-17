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
        public int ChanceOfEncountering { get; set; }
        public MonsterEncounter(int ID, int chanceOfEncountering)
        {
            this.ID = ID;
            ChanceOfEncountering = chanceOfEncountering;
        }
    }
}
