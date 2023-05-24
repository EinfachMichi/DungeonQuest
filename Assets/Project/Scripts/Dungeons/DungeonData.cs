using Units;
using UnityEngine;

namespace Dungeons
{
    [CreateAssetMenu(fileName = "New Dungeon", menuName = "Custom/Dungeon")]
    public class DungeonData : ScriptableObject
    {
        public int ID;
        public EnemyData[] EnemyDatas;
    }
}