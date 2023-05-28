using System;
using System.Collections.Generic;
using Main;
using Units;

namespace Dungeons
{
    public class DungeonManager : Singleton<DungeonManager>, ITickable
    {
        public event Action<Dungeon> OnDungeonEntered;

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

        public void EnterDungeon(Ally ally, Dungeon dungeon)
        {
            if (dungeon.Active) return;
            
            dungeon.ResetDungeon(ally, (DungeonData) Archive.Instance.Dungeons[dungeon.Info.ID - 1]);
            dungeon.Active = true;
        }

        public bool AllyInDungeon(Ally ally)
        {
            foreach (Dungeon dungeon in dungeons)
            {
                if (dungeon.Info.Ally == ally) return true;
            }

            return false;
        }

        public void ExitDungeon(int index)
        {
            if (!dungeons[index].Active) return;

            dungeons[index].Exit();
        }
    }
}