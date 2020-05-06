using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class World
    {
        private List<Location> _locations = new List<Location>();
        internal void AddLocation(int x, int y, int height, int width, string name, string desc)
        {
            for (int i = 0; i < width; ++i) 
            {
                for (int j = 0; j < height; ++j)
                {
                    _locations.Add(new Location(x + i, y + j, name, desc));
                }
            }
        }
        public Location LocationAt(int x, int y)
        {
            foreach (Location location in _locations)
            {
                if (location.xCoord == x && location.yCoord == y)
                {
                    return location;
                }
            }
            return null;
        }
    }
}
