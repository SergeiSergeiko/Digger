using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Digger.Scripts.UI
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public event Action ButtonClicked;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);   
        }

        public void ShowDeathWindow()
        {
            gameObject.SetActive(true);
        }

        public void HideDeathWindow()
        {
            gameObject.SetActive(false);
        }

        private void OnClicked()
        {
            ButtonClicked?.Invoke();
        }
    }
}