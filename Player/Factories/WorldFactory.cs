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
                " Before its destruction by Alduin, the keep was controlled by the Imperial Legion.", 1, 1, "Forest", "");

            skyrim.AddLocation(1, 0, "Helgen", "Hegen was a thriving town and keep on the southern border of Skyrim with Cyrodiil." +
                " Before its destruction by Alduin, the keep was controlled by the Imperial Legion.", 1, 1, "Forest", "");

            skyrim.AddLocation(0, 1, "Helgen", "Helgn was a thriving town and keep on the southern border of Skyrim with Cyrodiil." +
                " Before its destruction by Alduin, the keep was controlled by the Imperial Legion.", 1, 1, "Forest", "");

            skyrim.AddLocation(0, -1, "Helgen", "Helge was a thriving town and keep on the southern border of Skyrim with Cyrodiil." +
                " Before its destruction by Alduin, the keep was controlled by the Imperial Legion.", 1, 1, "Forest", "");

            skyrim.AddLocation(-1, 0, "Helgen", "Hlgen was a thriving town and keep on the southern border of Skyrim with Cyrodiil." +
                " Before its destruction by Alduin, the keep was controlled by the Imperial Legion.", 1, 1, "Forest", "");

            return skyrim;
        }
    }
}
