using UnityEngine;

namespace Assets._Digger.Scripts.Game.Preloader
{
    public class LoadingLogo : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] string _nameBoolParameterActiveLogo;

        public void Show()
        {
            _animator.SetBool(_nameBoolParameterActiveLogo, true);
        }

        public void Hide()
        {
            _animator.SetBool(_nameBoolParameterActiveLogo, false);
        }
    }
}