using UnityEngine;

namespace Units
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Custom/Enemy")]
    public class EnemyData : ScriptableObject
    {
        [Header("Base")]
        public string name;
        public int level = 1;
        public float baseMaxHealth = 5;
        public float baseDamage = 1;
        public float baseMinGoldDrop;
        public float baseMaxGoldDrop;
        public float baseExperienceDrop;
        public float baseRegeneration;
        
        [Header("Level Up")]
        public float maxHealthPerLevel = 5;
        public float damagePerLevel = 1;
        public float regnerationPerLevel = 0.25f;
        public float minGoldDropPerLevel = 2;
        public float maxGoldDropPerLevel = 3;
        public float experienceDropPerLevel = 5;
    }
}