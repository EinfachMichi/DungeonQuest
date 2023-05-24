using System;
using System.Collections.Generic;
using Main;
using Units;

namespace Dungeons
{
    public class DungeonManager : Singleton<DungeonManager>, ITickable
    {
        private List<Dungeon> dungeons = new();

        #region Properties

        public List<Dungeon> Dungeons => dungeons;

        #endregion
        
        private void Start()
        {
            GameManager.Instance.AddToRegister(this);
            
            foreach (DungeonData data in Archive.Instance.Dungeons)
            {
                dungeons.Add(new Dungeon(null, data));
            }
        }

        public void Tick()
        {
            foreach (Dungeon dungeon in dungeons)
            {
                if(dungeon.Active) dungeon.Run();
            }
        }

        public void EnterDungeon(Ally ally, int index)
        {
            if (dungeons[index].Active) return;
            
            dungeons[index] = new Dungeon(ally, (DungeonData) Archive.Instance.Dungeons[index]);
            dungeons[index].Active = true;
        }

        public void ExitDungeon(int index)
        {
            if (!dungeons[index].Active) return;

            dungeons[index].Active = false;
        }
    }
}