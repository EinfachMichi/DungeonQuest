using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GUI
{
    public class ButtonNavigation : MonoBehaviour
    {
        public Button[] buttons;

        private Button selectedButton;
        private int buttonIndex;
        
        private void Start()
        {
            selectedButton = buttons[buttonIndex];
            selectedButton.interactable = false;
            GUIManager.Instance.ChangePage(buttonIndex);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                ScrollButton(1);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                ScrollButton(-1);
            }
        }

        private void ScrollButton(int dir)
        {
            selectedButton.interactable = true;
            buttonIndex += dir;
            if (buttonIndex < 0) buttonIndex = buttons.Length - 1;
            else if (buttonIndex >= buttons.Length) buttonIndex = 0;
            selectedButton = buttons[buttonIndex];
            selectedButton.interactable = false;
            
            GUIManager.Instance.ChangePage(buttonIndex);
        }

        public void SetButton(int index)
        {
            selectedButton.interactable = true;
            buttonIndex = index;
            selectedButton = buttons[buttonIndex];
            selectedButton.interactable = false;
            
            GUIManager.Instance.ChangePage(buttonIndex);
        }
    }
}