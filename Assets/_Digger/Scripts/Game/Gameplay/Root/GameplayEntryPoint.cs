using System;
using UnityEngine;
using UnityEngine.UI;
using Unity.Cinemachine;
using Assets._Digger.Scripts.Units.Player;

namespace _Digger.Scripts.Game.Gameplay.Root
{
	public class GameplayEntryPoint : MonoBehaviour
	{
        [SerializeField] private Button _goToMainMenuButton;
        [SerializeField] private SpawnerPlayer _spawnerPlayer;
        [SerializeField] private CinemachineCamera _cinemamachine;

        public event Action GoToMainMenuButtonClicked;

        public void Run()
        {
            _goToMainMenuButton.onClick.AddListener(HandleMainMenuButtonClick);

            Player player = _spawnerPlayer.Spawn();
            _cinemamachine.Follow = player.transform;
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