using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Digger.Scripts.Game.MainMenu.Root
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private Button _goToGameplayButton;

        public event Action GoToGameplayButtonClicked;

        public void Run()
        {
            _goToGameplayButton.onClick.AddListener(HandleStartButtonClick);
        }

        private void HandleStartButtonClick()
        {
            GoToGameplayButtonClicked?.Invoke();
        }

        private void OnDestroy()
        {
            _goToGameplayButton.onClick.RemoveListener(HandleStartButtonClick);
        }
    }
}