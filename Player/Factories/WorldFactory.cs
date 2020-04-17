using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Factories
{
    public static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World skyrim = new World();

            skyrim.AddLocation(0, 0, "Helgen", "Helgen was a thriving town and keep on the southern border of Skyrim with Cyrodiil." +
                " Before its destruction by Alduin, the keep was controlled by the Imperial Legion.", 5, 5, "Forest", "");

            skyrim.LocationAt(0, 0).AddMonster(1, 1);

            skyrim.AddLocation(0, 5, "Riverwood", "Riverwood is a small village located in the province of Skyrim. The village is built on the eastern bank of the White River, in Whiterun Hold." +
                " It is a small Nordic village set in a valley, between the river and the steep mountainside of the Throat of the World." +
                " It serves largely as a stopping point and rural community along the road from Helgen to Whiterun.", 1, 4, "Town", "");

            skyrim.AddLocation(-1, 0, "Pinewatch", "Pinewatch is northeast of Falkreath, about halfway between Falkreath and the Guardian Stones along the main road." +
                " An easy way to get to Pinewatch is to head directly west from Helgen." +
                " There is a bandit watchtower with a double rock fall trap just to the south of the house." +
                " It is also near Lakeview Manor.", 1, 1, "Cave", "");

            skyrim.AddLocation(0, -1, "Greywater Grotto", "Greywater Grotto is a cave located southeast of Helgen and west of Fort Neugrad." +
                " It was once a hideout for a group of bandits, but they were killed by wild beasts, which now occupy this grotto.", 1, 1, "Cave", "");

            skyrim.AddLocation(5, 0, "Alchemist's Shack", "The Alchemist's Shack is a small cabin located south-south-west of Ivarstead, roughly halfway between the village and Arcwind Point." +
                " Inside are several alchemical ingredients, an Alchemist's Journal and a Butterfly in a Jar." +
                " Behind the cabin is a small garden with some deathbell and an alchemy lab.", 1, 1, "Trader", "");

            return skyrim;
        }
    }
}
