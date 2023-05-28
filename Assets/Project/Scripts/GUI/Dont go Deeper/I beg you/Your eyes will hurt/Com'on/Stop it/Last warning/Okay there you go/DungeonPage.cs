using System;
using System.Collections.Generic;
using Dungeons;
using Main;
using UnityEngine;

namespace GUI
{
    public class DungeonPage : Singleton<DungeonPage>
    {
        [SerializeField] private DungeonCard cardPrefab;
        [SerializeField] private Transform cardParent;
        [SerializeField] private GameObject infoPage;
        public DungeonDisplay display;
        
        private List<DungeonCard> cards = new();
        [HideInInspector] public bool inDisplay;

        public void InitPage()
        {
            List<Dungeon> dungeons = DungeonManager.Instance.Dungeons;
            for (int i = 0; i < dungeons.Count; i++)
            {
                DungeonCard card = Instantiate(cardPrefab, cardParent);
                card.InitCard(dungeons[i]);
                cards.Add(card);
            }
        }

        public void UpdateDungeonInfo()
        {
            if (inDisplay)
            {
                infoPage.SetActive(false);   
                return;
            }
            infoPage.SetActive(true);
            
            foreach (DungeonCard card in cards)
            {
                card.UpdateCard();
            }
        }

        public void UpdateDungeonDisplay()
        {
            if (!inDisplay)
            {
                display.gameObject.SetActive(false);
                return;
            }
            display.gameObject.SetActive(true);
            
            display.UpdateDisplay();
        }
    }
}