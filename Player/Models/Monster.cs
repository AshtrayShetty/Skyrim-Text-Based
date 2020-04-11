using System;

namespace Engine.Models
{
    public class Monster
    {
        Player player;
        public string name { get; set; }
        public string enemyType { get; set; }
        private int _health;
        public int health { get => _health; set => setHealth(); }
        public int level { get => _level; set => setLevel(); }
        private int _level;
        public Monster(string name, string enemyType)
        {
            this.name = name;
            this.enemyType = enemyType;
        }

        Random rnd = new Random();
        private void setLevel()
        {
            if (enemyType == "Animals/Bugs")
            {
                if (player.level != 1) { _level = rnd.Next(player.level - 5, player.level - 2); }
                else { _level = 1; }
            }
            else if (enemyType == "Human")
            {
                if (player.level >= 10) { _level = rnd.Next(player.level - 2, player.level + 2); }
                else { _level = player.level; }
            }
            else if (enemyType == "Large") { _level = rnd.Next(30, 40); }
        }
        private void setHealth()
        {
            if (enemyType == "Animals/Bugs") { _health = 3 * player.health / 5; }
            else if (enemyType == "Human") { _health = player.health; }
            else if (enemyType == "Large") { _health = 5 * player.health / 4; }
        }

    }
}
