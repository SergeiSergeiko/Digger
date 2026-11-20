using Assets._Digger.Scripts.Game.Gameplay.UI;
using Assets._Digger.Scripts.Spawners;
using Assets._Digger.Scripts.Units.Player;
using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Digger.Scripts.Game.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private Button _goToMainMenuButton;
        [SerializeField] private SpawnerPlayer _spawnerPlayer;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private UIRootView _uiRoot;
        [SerializeField] private CinemachineCamera _cinemamachine;

        private Player _player;

        public event Action GoToMainMenuButtonClicked;

        private void OnEnable()
        {
            _goToMainMenuButton.onClick.AddListener(HandleMainMenuButtonClick);

            _uiRoot.PopupUI.DeathWindow.ButtonClicked += OnDeathWindowButtonClicked;
            _uiRoot.PopupUI.DeathWindow.HideDeathWindow();
        }

        private void OnDisable()
        {
            _goToMainMenuButton.onClick.RemoveListener(HandleMainMenuButtonClick);

            _uiRoot.PopupUI.DeathWindow.ButtonClicked -= OnDeathWindowButtonClicked;
            _player.Health.Died -= OnPlayerDie;
        }

        public void Run()
        {
            SpawnPlayer();
        }

        private void HandleMainMenuButtonClick()
        {
            GoToMainMenuButtonClicked?.Invoke();
        }

        private void OnPlayerDie()
        {
            _cinemamachine.Follow = null;
            _uiRoot.PopupUI.DeathWindow.ShowDeathWindow();
        }

        private void OnDeathWindowButtonClicked()
        {
            _uiRoot.PopupUI.DeathWindow.HideDeathWindow();

            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            if (_player == null)
            {
                _player = _spawnerPlayer.CreatePlayer();
                _uiRoot.GameplayUI.InitHealthBar(_player.Health);
                _player.Health.Died += OnPlayerDie;
            }
            else
            {
                _player.ResetState();
            }

            _spawnerPlayer.Spawn(_player, _playerSpawnPoint.position);
            _cinemamachine.Follow = _player.transform;
        }
    }
}