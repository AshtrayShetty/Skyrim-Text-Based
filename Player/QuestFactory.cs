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
            Random rnd = new Random();
            switch (id)
            {
                case 1:
                    location.QuestHere = new Quest("Escape from helgen", 
                        "Flee from the scene of destruction caused by Alduin and get to safety", 
                        rnd.Next(15, 100), 
                        rnd.Next(50, 100));
                    location.QuestHere.ItemsList.Add(ItemFactory.AddItem(2));
                    location.QuestHere.ItemsList.Add(ItemFactory.AddItem(2));
                    break;

                default:
                    throw new ArgumentNullException();
            }
        }
    }
}
