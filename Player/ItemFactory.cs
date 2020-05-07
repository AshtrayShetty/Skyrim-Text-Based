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
        public static void AddItem(int id, int quantity, ObservableCollection<Item> list)
        {
            while (quantity>0)
            {
                switch (id)
                {
                    case 1:
                        Item item = new Item("Iron Dagger", "Weapon", 25, 25, 35);
                        list.Add(item);
                        break;

                    default:
                        break;
                }
                --quantity;
            }
        }
    }
}
