using System;
using Main;

namespace Units
{
    public class Ally : Unit
    {
        public event Action OnDeath;
        
        private float baseMaxExperience = 100;
        private float experience;

        private float maxExperiencePerLevel = 1.5f;

        #region Properties

        public float MaxExperience
        {
            get
            {
                if (level != 1) return baseMaxExperience + (level * maxExperiencePerLevel);
                
                return baseMaxExperience;
            }
        }

        public float Experience => experience;

        #endregion

        #region Constructors

        public Ally(AllyData allyData)
        {
            name = allyData.name;
            level = allyData.level;
            baseMaxHealth = allyData.baseMaxHealth;
            baseDamage = allyData.baseDamage;
            baseRegeneration = allyData.baseRegeneration;

            maxHealthPerLevel = allyData.maxHealthPerLevel;
            damagePerLevel = allyData.damagePerLevel;
            maxExperiencePerLevel = allyData.maxExperiencePerLevel;
            regenertionPerLevel = allyData.regenerationPerLevel;

            Heal();
        }

        #endregion

        public void AddExperience(float xp)
        {
            if (level >= maxLevel)
            {
                experience = MaxExperience;
                return;
            }
            
            experience += xp;
            if (experience >= MaxExperience)
            {
                experience -= MaxExperience;
                LevelUp();
            }
        }

        private void LevelUp()
        {
            level++;
            Heal();
        }

        protected override void Death()
        {
            base.Death();
            OnDeath?.Invoke();
        }
    }
}