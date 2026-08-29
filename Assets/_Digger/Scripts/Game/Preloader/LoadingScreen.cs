using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Digger.Scripts.Game.Preloader
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Text _progressText;
        [SerializeField] private LoadingLogo _loadingLogo;

        public IEnumerator Run(AsyncOperation loadingScene)
        {
            _loadingLogo.Show();
            yield return StartCoroutine(RefreshingProgress(loadingScene));
            _loadingLogo.Hide();
        }

#if UNITY_EDITOR
        public IEnumerator Run(AsyncOperation loadingScene, float loadingTime)
        {
            _loadingLogo.Show();
            yield return StartCoroutine(SimulationLongLoadingTime(loadingScene, loadingTime));
            _loadingLogo.Hide();
        }
#endif

        private IEnumerator RefreshingProgress(AsyncOperation loadingScene)
        {
            float divider = .9f;
            float multiplier = 100f;

            while (loadingScene.isDone == false)
            {
                float progress = loadingScene.progress / divider;
                int percent = Mathf.RoundToInt(progress * multiplier);
                _progressText.text = percent.ToString();

                yield return null;
            }
        }

#if UNITY_EDITOR
        private IEnumerator SimulationLongLoadingTime(AsyncOperation loadingScene, float loadingTime)
        {
            loadingScene.allowSceneActivation = false;
            int maxCount = 100;
            WaitForSeconds wait = new WaitForSeconds(loadingTime / maxCount);

            for (int count = 0; count <= maxCount; count++)
            {
                _progressText.text = count.ToString();
                yield return wait;
            }

            loadingScene.allowSceneActivation = true;
        }
#endif
    }
}