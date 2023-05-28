using TMPro;
using Units;
using UnityEngine;
using UnityEngine.UI;

namespace GUI
{
    public class AllyCard : MonoBehaviour
    {
        private Ally ally;

        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI xpText;
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI damageText;
        [SerializeField] private TextMeshProUGUI regenText;
        
        public void InitCard(Ally ally)
        {
            this.ally = ally;
            iconImage.sprite = ally.Icon;
            UpdateCard();
        }

        public void SelectAlly()
        {
            GUIManager.Instance.selectedAlly = ally;
        }
        
        public void UpdateCard()
        {
            nameText.text = ally.Name;
            levelText.text = ally.Level.ToString("0");
            xpText.text = $"{ally.Experience}/{ally.MaxExperience}";
            healthText.text = $"{ally.Health}/{ally.MaxHealth}";
            damageText.text = ally.Damage.ToString("0");
            regenText.text = ally.Regeneration.ToString("0");
        }
    }
}