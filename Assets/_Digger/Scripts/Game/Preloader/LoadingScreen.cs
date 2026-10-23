using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Digger.Scripts.Game.Preloader
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Text _progressText;
        [SerializeField] private LoadingLogo _loadingLogo;

        private float _simulationLoadingTime = 3f;

        public IEnumerator Run(AsyncOperation loadingScene)
        {
            _loadingLogo.Show();

            //if (Application.isEditor)
            //    yield return StartCoroutine(SimulationLoading(loadingScene));
            //else
                yield return StartCoroutine(RefreshingProgress(loadingScene));

            _loadingLogo.Hide();
        }

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
        private IEnumerator SimulationLoading(AsyncOperation loadingScene)
        {
            loadingScene.allowSceneActivation = false;
            int maxCount = 100;
            WaitForSeconds wait = new(_simulationLoadingTime / maxCount);

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