using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class Location : INotifyPropertyChanged 
    {
        private int _xCoord;
        private int _yCoord;
        private string _name;
        private string _description;
        private Quest _quest;
        public int xCoord
        {
            get => _xCoord;
            set
            {
                _xCoord = value;
                OnPropertyChanged(nameof(xCoord));
            }
        }
        public int yCoord
        {
            get => _yCoord;
            set
            {
                _yCoord = value;
                OnPropertyChanged(nameof(yCoord));
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public Quest QuestHere
        {
            get => _quest;
            set
            {
                _quest = value;
                OnPropertyChanged(nameof(QuestHere));
            }
        }
        public Location(int x, int y, string name, string desc)
        {
            xCoord = x;
            yCoord = y;
            Name = name;
            Description = desc;
        }
        public Location() { }
        private List<MonsterEncounter> _monsters { get; set; } = new List<MonsterEncounter>();
        public void AddMonster(int id, double chanceOfEncountering)
        {
            MonsterEncounter monsterEncounter = new MonsterEncounter(id, chanceOfEncountering);
            if (_monsters.Exists(m => m.ID == monsterEncounter.ID)) { monsterEncounter.ChanceOfEncounter = chanceOfEncountering; }
            else { _monsters.Add(monsterEncounter); }
        }
        public Monster GetMonster()
        {
            if (!_monsters.Any()) { return null; }
            Random random = new Random();
            double chance = random.NextDouble();

            foreach (MonsterEncounter monsterEncounter in _monsters)
            {
                if (monsterEncounter.ChanceOfEncounter >= chance) { return MonsterFactory.GetMonster(monsterEncounter.ID); }
            }
            return MonsterFactory.GetMonster(_monsters.Last().ID);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
