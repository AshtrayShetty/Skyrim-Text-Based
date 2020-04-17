using Engine.ViewModels;
using System;

namespace Engine.Models
{
    public class Monster : BaseNotificationClass
    {
        private string _name;
        private string _enemyType;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string EnemyType
        {
            get => _enemyType;
            set
            {
                _enemyType = value;
                OnPropertyChanged(nameof(EnemyType));
            }
        }
        public int Health { get; set; }

        private int _level;
        public Monster(string name, string enemyType)
        {
            Name = name;
            EnemyType = enemyType;
        }

        Random rnd = new Random();
        public void SetLevel(Player player)
        {
            if (EnemyType == "Animals/Bugs")
            {
                if (player.Level != 1) { _level = rnd.Next(player.Level - 5, player.Level - 2); }
                else { _level = 1; }
            }
            else if (EnemyType == "Human")
            {
                if (player.Level >= 10) { _level = rnd.Next(player.Level - 2, player.Level + 2); }
                else { _level = player.Level; }
            }
            else if (EnemyType == "Large") { _level = rnd.Next(30, 40); }
        }
        public void SetHealth(Player player)
        {
            if (EnemyType == "Animals/Bugs") { Health = 3 * player.Health / 5; }
            else if (EnemyType == "Human") { Health = player.Health; }
            else if (EnemyType == "Large") { Health = 5 * player.Health / 4; }
        }

    }
}
