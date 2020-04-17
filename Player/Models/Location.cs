using Engine.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Location
    {
        public int xCoord { get; set; }
        public int yCoord { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Image { get; set; }

        public List<MonsterEncounter> monsters = new List<MonsterEncounter>();
        public void AddMonster(int ID, int chanceOfEncountering)
        {
            if (!monsters.Any(m => m.ID == ID))
            {
                MonsterEncounter mEnc = new MonsterEncounter(ID, chanceOfEncountering);
                monsters.Add(mEnc);
            }
            else
            {
                monsters.First(m => m.ID == ID).ChanceOfEncountering = chanceOfEncountering;
            }
        }
        public Monster GetMonster()
        {
            if (!monsters.Any()) { return null; }
            Random rnd = new Random();
            int totalChances = monsters.Sum(s => s.ChanceOfEncountering);
            int chance = rnd.Next(1, totalChances);
            int runningTotal = 0;
            foreach (var monster in monsters)
            {
                if (chance < totalChances)
                {
                    runningTotal += monster.ChanceOfEncountering;
                    if (runningTotal <= totalChances) { return MonsterFactory.GetMonster(monster.ID); }
                }
            }
            return MonsterFactory.GetMonster(monsters.Last().ID);
        }

    }
}
