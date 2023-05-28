using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Units
{
    public class Enemy : Unit
    {
        public event Action OnDeath;

        private float baseMinGoldDrop;
        private float baseMaxGoldDrop;
        private float baseExperienceDrop;

        private float minGoldDropPerLevel;
        private float maxGoldDropPerLevel;
        private float experienceDropPerLevel;

        #region Properties

        public float ExperienceDrop
        {
            get
            {
                if(level != 1) return baseExperienceDrop + (level * experienceDropPerLevel);
                return baseExperienceDrop;
            }
        } 
        
        public float GoldDrop
        {
            get
            {
                float min = baseMinGoldDrop;
                float max = baseMaxGoldDrop;
                if (level != 1)
                {
                    min = baseMinGoldDrop + (level * minGoldDropPerLevel);
                    max = baseMaxGoldDrop + (level * maxGoldDropPerLevel);
                }
                return Mathf.RoundToInt(Random.Range(min, max));
            }
        } 

        #endregion
        
        #region Constructors

        public Enemy(EnemyData enemyData)
        {
            icon = enemyData.icon;
            name = enemyData.name;
            level = enemyData.level;
            baseMaxHealth = enemyData.baseMaxHealth;
            baseDamage = enemyData.baseDamage;
            baseRegeneration = enemyData.baseRegeneration;
            baseMinGoldDrop = enemyData.baseMinGoldDrop;
            baseMaxGoldDrop = enemyData.baseMaxGoldDrop;
            baseExperienceDrop = enemyData.baseExperienceDrop;

            maxHealthPerLevel = enemyData.maxHealthPerLevel;
            damagePerLevel = enemyData.damagePerLevel;
            regenertionPerLevel = enemyData.regnerationPerLevel;
            experienceDropPerLevel = enemyData.experienceDropPerLevel;
            minGoldDropPerLevel = enemyData.minGoldDropPerLevel;
            maxGoldDropPerLevel = enemyData.maxGoldDropPerLevel;

            Heal();
        }

        #endregion

        protected override void Death()
        {
            base.Death();
            OnDeath?.Invoke();
        }
    }
}