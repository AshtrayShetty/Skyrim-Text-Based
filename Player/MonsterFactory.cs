using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class MonsterFactory
    {
        public static Monster GetMonster(int id)
        {
            Random rnd = new Random();
            switch (id)
            {
                case 1:
                    Monster skewer = new Monster("Skewer", "A huge ass filthy rat", 50, 3, 10, 35);
                    for(int i = 0; i < 3; ++i)
                    {
                        double probablilty = rnd.NextDouble();
                        if (probablilty > 0.5) { skewer.RewardItems.Add(ItemFactory.AddItem(i)); }
                    }
                    return skewer;

                default:
                    throw new ArgumentNullException();
            }
        }
    }
}
