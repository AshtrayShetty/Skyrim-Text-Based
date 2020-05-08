using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class ItemFactory
    {
        public static Item AddItem(int id)
        {
            switch (id)
            {
                case 1:
                    return new Item(id ,"Iron Dagger", "Weapon", 25, 25, 35);

                case 2:
                    return new Item(id, "Apple", "Potion", 5, -10, 0);

                case 3:
                    return new Item(id, "Skewer Tail", "Misc", 10, 0, 0);

                default:
                    throw new ArgumentNullException();
            }
        }
    }
}
