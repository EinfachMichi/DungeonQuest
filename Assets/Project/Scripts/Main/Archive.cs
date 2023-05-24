using Dungeons;
using Units;
using UnityEngine;

namespace Main
{
    public class Archive : Singleton<Archive>
    {
        [HideInInspector] public Object[] Allies;
        [HideInInspector] public Object[] Dungeons;

        protected override void Awake()
        {
            base.Awake();
            Allies = Resources.LoadAll("Units/Allies", typeof(AllyData));
            Dungeons = Resources.LoadAll("Dungeons", typeof(DungeonData));
        }
    }
}