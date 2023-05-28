using System;
using Units;
using UnityEngine;

namespace Dungeons
{
    public class Dungeon
    {
        public bool Active;

        private int ID;
        private Ally ally;
        private Enemy[] enemies;
        private Enemy enemy;
        private int currentEnemyIndex;
        private int enemiesInDungeon;
        private Turn turn = Turn.Ally;

        #region Properties

        public DungeonInfo Info => new(ID, ally, enemy, currentEnemyIndex, enemiesInDungeon);

        #endregion
        
        public Dungeon(Ally ally, DungeonData data)
        {
            if(ally != null)
            {
                this.ally = ally;
                ally.OnDeath += AllyDeath;
            }

            ID = data.ID;

            currentEnemyIndex = 0;
            int length = data.EnemyDatas.Length;
            enemies = new Enemy[length];
            for (int i = 0; i < length; i++)
            {
                enemies[i] = new Enemy(data.EnemyDatas[i]);
            }

            enemy = enemies[currentEnemyIndex];
            enemy.OnDeath += EnemyDeath;

            enemiesInDungeon = length;
        }
        
        public void Run()
        {
            switch (turn)
            {
                case Turn.Ally:
                    Combat(ally, enemy);
                    turn = Turn.Enemy;
                    break;
                case Turn.Enemy:
                    Combat(enemy, ally);
                    turn = Turn.Ally;
                    break;
            }
        }

        private void Combat(Unit user, Unit target)
        {
            user.ApplyDamage(target);
        }

        private void AllyDeath()
        {
            ally.OnDeath -= AllyDeath;
            DungeonComplete(false);
        }

        private void EnemyDeath()
        {
            enemy.OnDeath -= EnemyDeath;
            currentEnemyIndex++;
            
            PlayerManager.Instance.AddGold(enemy.GoldDrop);
            ally.AddExperience(enemy.ExperienceDrop);

            if (currentEnemyIndex >= enemies.Length)
            {
                DungeonComplete(true);
                return;
            }
            
            enemy = enemies[currentEnemyIndex];
            enemy.OnDeath += EnemyDeath;
        }

        private void DungeonComplete(bool complete)
        {
            if (complete)
            {
                // TODO: Reward Ally
            }

            Active = false;
        }

        public void ResetDungeon(Ally ally, DungeonData data)
        {
            this.ally = ally;
            ally.OnDeath += AllyDeath;
            
            currentEnemyIndex = 0;
            int length = data.EnemyDatas.Length;
            enemies = new Enemy[length];
            for (int i = 0; i < length; i++)
            {
                enemies[i] = new Enemy(data.EnemyDatas[i]);
            }

            enemy = enemies[currentEnemyIndex];
            enemy.OnDeath += EnemyDeath;

            enemiesInDungeon = length;
        }

        public void Exit()
        {
            ally = null;
            Active = false;
        }

        enum Turn
        {
            Ally,
            Enemy
        }
    }
}