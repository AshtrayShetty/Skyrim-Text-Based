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

        internal void AddLocation(int xCoord, int yCoord, string name, string description, int width, int height, string type, string image)
        {
            Location location = new Location
            {
                xCoord = xCoord,
                yCoord = yCoord,
                Name = name,
                Description = description,
                Width = width,
                Height = height,
                Type = type,
                Image = image
            };
            if (!_locations.Any(l => l.Equals(location))){ _locations.Add(location); }
        }

        public Location LocationAt(int xCoord, int yCoord)
        {
            foreach(Location location in _locations)
            {
                if (location.xCoord == xCoord && location.yCoord == yCoord) { return location; }
            }
            return null;
        }
    }
}
