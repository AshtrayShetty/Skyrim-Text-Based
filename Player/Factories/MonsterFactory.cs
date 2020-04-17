using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Factories
{
    public static class MonsterFactory
    {
        public static Monster GetMonster(int ID)
        {
            switch (ID)
            {
                case 1:
                    Monster skewer = new Monster("Skewer", "Animals/Bugs");
                    return skewer;
                
                case 2:
                    Monster spider = new Monster("Spider", "Animals/Bugs");
                    return spider;

                case 3:
                    Monster wolf = new Monster("Wolf", "Animals/Bugs");
                    return wolf;

                case 4:
                    Monster falmer = new Monster("Falmer", "Human");
                    return falmer;

                case 5:
                    Monster giant = new Monster("Giant", "Large");
                    return giant;

                default:
                    throw new ArgumentException($"Monster of type {ID} doesn't exist");
            }
        }
    }
}
