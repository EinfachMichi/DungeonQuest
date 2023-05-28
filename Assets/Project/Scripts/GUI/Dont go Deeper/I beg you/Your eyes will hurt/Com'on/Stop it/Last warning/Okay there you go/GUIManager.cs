using System;
using Main;
using TMPro;
using Units;
using UnityEngine;

namespace GUI
{
    public class GUIManager : Singleton<GUIManager>, ITickable
    {
        [SerializeField] private TextMeshProUGUI goldText;
        [SerializeField] private AllyPage allyPage;
        [SerializeField] private DungeonPage dungeonPage;
        public TextMeshProUGUI headline;

        public Ally selectedAlly;

        private void Start()
        {
            GameManager.Instance.AddToRegister(this);
            
            dungeonPage.InitPage();
        }

        public void Tick()
        {
            UpdateGoldInfo();
            if(allyPage != null) UpdateAllyPage();
            UpdateDungeonPage();
        }

        public void ChangePage(int page)
        {
            allyPage.gameObject.SetActive(page == 0);
            dungeonPage.gameObject.SetActive(page == 1);

            if (page == 0) headline.text = "Allies";
            if (page == 1) headline.text = "Dungeons";
        }

        private void UpdateGoldInfo()
        {
            goldText.text = PlayerManager.Instance.Gold.ToString("0");
        }

        private void UpdateAllyPage()
        {
            allyPage.UpdatePage();
        }

        public void UpdateDungeonPage()
        {
            dungeonPage.UpdateDungeonInfo();
            dungeonPage.UpdateDungeonDisplay();
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}