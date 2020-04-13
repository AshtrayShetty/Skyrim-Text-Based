using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class World
    {
        private List<Location> _locations = new List<Location>();

        internal void addLocation(int xCoord, int yCoord, string name, string description, string type, int width, int height, string image)
        {
            Location location = new Location();
            location.xCoord = xCoord;
            location.yCoord = yCoord;
            location.name = name;
            location.description = description;
            location.type = type;
            location.width = width;
            location.height = height;
            location.image = image;
            if (!_locations.Any(l => l.Equals(location))){ _locations.Add(location); }
        }

        public Location locationAt(int xCoord, int yCoord)
        {
            foreach(Location location in _locations)
            {
                if(location.xCoord==xCoord && location.yCoord == yCoord) { return location; }
            }
            return null;
        }
    }
}
