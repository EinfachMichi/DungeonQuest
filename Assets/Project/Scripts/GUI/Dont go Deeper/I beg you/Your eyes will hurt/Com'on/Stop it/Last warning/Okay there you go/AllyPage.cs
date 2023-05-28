using System;
using System.Collections.Generic;
using Units;
using UnityEngine;

namespace GUI
{
    public class AllyPage : MonoBehaviour
    {
        [SerializeField] private AllyCard cardPrefab;
        private List<AllyCard> cards = new();

        private void Start()
        {
            PlayerManager.Instance.OnAllyAdded += OnAllyAdded;
            
            List<Unit> units = PlayerManager.Instance.OwndedAllies;
            for (int i = 0; i < units.Count; i++)
            {
                cards.Add(Instantiate(cardPrefab, transform));
                cards[i].InitCard((Ally) units[i]);
            }
        }

        private void OnAllyAdded(Ally ally)
        {
            AllyCard card = Instantiate(cardPrefab, transform);
            card.InitCard(ally);
            cards.Add(card);
        }
        
        public void UpdatePage()
        {
            foreach (AllyCard card in cards)
            {
                card.UpdateCard();
            }
        }
    }
}