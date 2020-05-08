using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class MonsterFactory
    {
        public static GameSession game=new GameSession();

        public static Monster GetMonster(int id)
        {
            switch (id)
            {
                case 1:
                    Monster skewer = new Monster("Skewer", "A huge ass filthy rat", 50, 3, 10, 35);
                    return skewer;
                default:
                    throw new ArgumentNullException();
            }
        }
    }
}
