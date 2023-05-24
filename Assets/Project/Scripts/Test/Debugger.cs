using System.Collections.Generic;
using Dungeons;
using Main;
using Units;
using UnityEngine;

namespace Test
{
    public class Debugger : MonoBehaviour, ITickable
    {
        public bool printAllyInfo;
        public bool printGold;
        public bool printDungeonInfo;

        private void Start()
        {
            GameManager.Instance.AddToRegister(this);
        }

        public void Tick()
        {
            if(printGold) PrintGold(PlayerManager.Instance.Gold);
            if(printAllyInfo) PrintUnitInfo(PlayerManager.Instance.OwndedAllies);
            if (printDungeonInfo)
            {
                foreach (Dungeon dungeon in DungeonManager.Instance.Dungeons)
                {
                    if(!dungeon.Active) continue;
                    PrintDungeonInfo(dungeon.Info);
                }
            }
        }

        private void PrintGold(float gold)
        {
            print($"Gold: {gold}");
        }

        private void PrintUnitInfo(List<Unit> units)
        {
            foreach (Unit unit in units)
            {
                if (unit.Name == "Steve")
                {
                    print(
                        $"Name: {unit.Name}; " +
                        $"Level: {unit.Level}; " +
                        $"Health: {unit.Health}/{unit.MaxHealth}; " +
                        $"XP: {((Ally)unit).Experience}/{((Ally)unit).MaxExperience}"
                    );
                }
                else
                {
                    print(
                        $"Name: {unit.Name}; " +
                        $"Level: {unit.Level}; " +
                        $"Health: {unit.Health}/{unit.MaxHealth}"
                    );
                }
            }
        }

        private void PrintDungeonInfo(DungeonInfo info)
        {
            print("********DungeonInfo*********");
            print($"Dungeon ID: {info.ID}");
            PrintUnitInfo(new List<Unit> {info.Ally});
            PrintUnitInfo(new List<Unit> {info.Enemy});
            print($"Total Enemies: {info.CurrentEnemyIndex}/{info.EnemiesInDungeon}");
            print("****************************");
        }
    }
}