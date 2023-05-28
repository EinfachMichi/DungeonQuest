using Dungeons;
using TMPro;
using Units;
using UnityEngine;
using UnityEngine.UI;

namespace GUI
{
    public class DungeonDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI allyNameText;
        [SerializeField] private TextMeshProUGUI allyLevelText;
        [SerializeField] private TextMeshProUGUI allyHealthText;
        [SerializeField] private Image allySprite;

        [SerializeField] private TextMeshProUGUI enemyNameText;
        [SerializeField] private TextMeshProUGUI enemyLevelText;
        [SerializeField] private TextMeshProUGUI enemyHealthText;
        [SerializeField] private Image enemySprite;

        private Dungeon dungeon;
        public void InitDisplay(Dungeon dungeon)
        {
            this.dungeon = dungeon;
        }
        
        public void UpdateDisplay()
        {
            allyNameText.text = dungeon.Info.Ally.Name;
            allyLevelText.text = "Level: " + dungeon.Info.Ally.Level.ToString("0");
            allyHealthText.text = $"HP: {dungeon.Info.Ally.Health}/{dungeon.Info.Ally.MaxHealth}";
            allySprite.sprite = dungeon.Info.Ally.Icon;

            enemyNameText.text = dungeon.Info.Enemy.Name;
            enemyLevelText.text = "Level: " + dungeon.Info.Enemy.Level.ToString("0");
            enemyHealthText.text = $"HP: {dungeon.Info.Enemy.Health}/{dungeon.Info.Enemy.MaxHealth}";
            enemySprite.sprite = dungeon.Info.Enemy.Icon;
        }

        public void ExitDisplay()
        {
            DungeonPage.Instance.inDisplay = false;
            GUIManager.Instance.UpdateDungeonPage();
        }
    }
}