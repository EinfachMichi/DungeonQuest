using UnityEngine;

namespace Units
{
    [CreateAssetMenu(fileName = "New Ally", menuName = "Custom/Ally")]
    public class AllyData : ScriptableObject
    {
        [Header("Base")] 
        public Sprite icon;
        public string name;
        public int level = 1;
        public float baseMaxHealth = 20;
        public float baseDamage = 1;
        public float baseRegeneration = 1;
        
        [Header("Level Up")]
        public float maxHealthPerLevel = 5;
        public float damagePerLevel = 1;
        public float maxExperiencePerLevel = 1.5f;
        public float regenerationPerLevel = 0.25f;
    }
}