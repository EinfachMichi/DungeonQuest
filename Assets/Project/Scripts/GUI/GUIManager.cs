using System;
using Main;
using TMPro;
using UnityEngine;

namespace GUI
{
    public class GUIManager : MonoBehaviour, ITickable
    {
        [SerializeField] private TextMeshProUGUI goldText;

        private void Start()
        {
            GameManager.Instance.AddToRegister(this);
        }

        public void Tick()
        {
            UpdateGoldInfo();
        }

        private void UpdateGoldInfo()
        {
            goldText.text = PlayerManager.Instance.Gold.ToString("0");
        }
    }
}