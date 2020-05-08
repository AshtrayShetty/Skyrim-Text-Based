using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class QuestFactory
    {
        public static void GiveQuest(int id, Location location)
        {
            switch (id)
            {
                case 1:
                    location.QuestHere = new Quest("Escape from helgen", "Flee from the scene of destruction caused by Alduin and get to safety");
                    break;

                default:
                    throw new ArgumentNullException();
            }
        }
    }
}
