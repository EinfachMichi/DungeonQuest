using Main;

namespace Units
{
    public abstract class Unit : ITickable
    {
        private const int TicksForRegeneration = 5;
        
        protected string name;
        protected int level;
        protected const int maxLevel = 100;
        protected float baseMaxHealth;
        protected float baseDamage;
        protected float baseRegeneration;
            
        protected float maxHealthPerLevel;
        protected float damagePerLevel;
        protected float regenertionPerLevel;
        
        protected float health;
        protected bool isAlive = true;

        private int regenerationCounter;

        #region Properties

        public string Name => name;
        public int Level => level;
        public float MaxHealth
        {
            get
            {
                if (level != 1) return baseMaxHealth + (level * maxHealthPerLevel);
                return baseMaxHealth;
            }
        }
        public float Damage
        {
            get
            {
                if (level != 1) return baseDamage + (level * damagePerLevel);
                return baseDamage;
            }
        }
        public float Regeneration
        {
            get
            {
                if (level != 1) return baseRegeneration + (level * regenertionPerLevel);
                return baseRegeneration;
            }
        }
        public float Health => health;

        #endregion

        public Unit()
        {
            GameManager.Instance.AddToRegister(this);
        }
        
        public virtual void Tick()
        {
            if (!isAlive) return;
            Regenerate();
        }
        
        public void Heal()
        {
            health = MaxHealth;
        }
        
        public void ApplyDamage(Unit target)
        {
            target.ReceiveDamage(baseDamage);
        }

        private void ReceiveDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                Death();
            }
        }

        private void Regenerate()
        {
            regenerationCounter++;
            if (regenerationCounter >= TicksForRegeneration)
            {
                regenerationCounter = 0;
                health += Regeneration;
                if (health >= MaxHealth) health = MaxHealth;
            }
        }

        protected virtual void Death()
        {
            isAlive = false;
        }
    }
}