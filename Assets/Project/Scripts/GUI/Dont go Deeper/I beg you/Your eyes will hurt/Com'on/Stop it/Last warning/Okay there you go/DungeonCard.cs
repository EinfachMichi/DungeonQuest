using Dungeons;
using TMPro;
using Units;
using UnityEngine;
using UnityEngine.UI;

namespace GUI
{
    public class DungeonCard : MonoBehaviour
    {
        private Dungeon dungeon;

        [SerializeField] private TextMeshProUGUI difficultyText;
        [SerializeField] private Button enterButton;
        [SerializeField] private Button openButton;
        [SerializeField] private Button exitButton;

        public void InitCard(Dungeon dungeon)
        {
            this.dungeon = dungeon;
            UpdateCard();
        }

        public void UpdateCard()
        {
            difficultyText.text = dungeon.Info.ID.ToString("0");
            if (dungeon.Active)
            {
                enterButton.gameObject.SetActive(false);
                openButton.gameObject.SetActive(true);
                exitButton.gameObject.SetActive(true);
            }
            else
            {
                enterButton.gameObject.SetActive(true);
                openButton.gameObject.SetActive(false);
                exitButton.gameObject.SetActive(false);
            }
        }

        public void EnterDungeon()
        {
            Ally ally = GUIManager.Instance.selectedAlly;
            if (ally == null || DungeonManager.Instance.AllyInDungeon(ally)) return;
            DungeonManager.Instance.EnterDungeon(GUIManager.Instance.selectedAlly, dungeon);
            OpenDungeon();
            UpdateCard();
        }

        public void ExitDungeon()
        {
            DungeonManager.Instance.ExitDungeon(dungeon.Info.ID - 1);
            UpdateCard();
        }

        public void OpenDungeon()
        {
            DungeonPage.Instance.inDisplay = true;
            DungeonPage.Instance.display.InitDisplay(dungeon);
            GUIManager.Instance.UpdateDungeonPage();
        }
    }
}