using Units;

namespace Dungeons
{
    public struct DungeonInfo
    {
        public int ID;
        public Ally Ally;
        public Enemy Enemy;
        public int CurrentEnemyIndex;
        public int EnemiesInDungeon;

        public DungeonInfo(int id, Ally ally, Enemy enemy, int currentEnemyIndex, int enemiesInDungeon)
        {
            ID = id;
            Ally = ally;
            Enemy = enemy;
            CurrentEnemyIndex = currentEnemyIndex;
            EnemiesInDungeon = enemiesInDungeon;
        }
    }
}