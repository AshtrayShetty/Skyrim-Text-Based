using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World Skyrim = new World();

            Skyrim.AddLocation(0, 0, 5, 5, "Helgen", "Helgen is a moderately-sized community in Falkreath Hold in The Elder Scrolls V: Skyrim. " +
                "It was one of the only heavily inhabited settlements located in Falkreath Hold, apart from the city of Falkreath itself and Half-Moon Mill. " +
                "It is destroyed in the prologue by Alduin.");

            Skyrim.LocationAt(0, 0).AddMonster(1, 0.99);
            QuestFactory.GiveQuest(1, Skyrim.LocationAt(0, 0));

            return Skyrim;
        }
    }
}
