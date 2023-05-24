using Dungeons;
using Units;
using UnityEngine;

namespace Test
{
    public class TestManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerManager.Instance.AddNewAlly();
                print("New Ally added");
            }
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                DungeonManager.Instance.EnterDungeon((Ally) PlayerManager.Instance.OwndedAllies[0], 0);
                print("Dungeon enterd");
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                DungeonManager.Instance.ExitDungeon(0);
                print("Dungeon exited");
            }
        }
    }
}