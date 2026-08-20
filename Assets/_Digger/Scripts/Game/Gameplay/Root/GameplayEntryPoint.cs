using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Digger.Scripts.Game.Gameplay.Root
{
	public class GameplayEntryPoint : MonoBehaviour
	{
        [SerializeField] private Button _goToMainMenuButton;

        public event Action GoToMainMenuButtonClicked;

        public void Run()
        {
            _goToMainMenuButton.onClick.AddListener(HandleMainMenuButtonClick);
        }

        private void HandleMainMenuButtonClick()
        {
            GoToMainMenuButtonClicked?.Invoke();
        }

        private void OnDestroy()
        {
            _goToMainMenuButton.onClick.RemoveListener(HandleMainMenuButtonClick);
        }
    }
}