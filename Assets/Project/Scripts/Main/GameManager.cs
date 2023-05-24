using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public class GameManager : Singleton<GameManager>
    {
        public float TicksPerSecond = 1f;
        
        private List<ITickable> tickables = new();
        private float tickTimer;

        private void Update()
        {
            tickTimer += Time.deltaTime;
            if (tickTimer >= 1 / TicksPerSecond)
            {
                tickTimer = 0;
                Tick();
            }
        }

        private void Tick()
        {
            foreach (ITickable tickable in tickables)
            {
                tickable.Tick();
            }
        }

        public void AddToRegister(ITickable tickable)
        {
            tickables.Add(tickable);
        }
    }
}