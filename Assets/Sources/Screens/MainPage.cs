using Balthazariy.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Balthazariy.Screens
{
    public class MainPage : MonoBehaviour
    {
        public static MainPage Instance { get; private set; }

        [SerializeField] private Button _playButton;

        private void Awake()
        {
            if (Instance != null) Destroy(this.gameObject);

            if (Instance == null)
                Instance = this;
        }

        private void Start()
        {
            _playButton.onClick.AddListener(PlayButtonOnClickHandler);
        }

        #region Button Handlers
        private void PlayButtonOnClickHandler()
        {
            GameplayManager.Instance.StartGameplay();

            CommonSceneManager.Instance.LoadSceneByName(Settings.SceneNameEnumerators.LoadingScreenScene, true, Settings.SceneNameEnumerators.GameplayScene);
            CommonSceneManager.Instance.OnAsycnOperationCompleteEvent += OnAsycnOperationCompleteEventEvent;
        }
        #endregion

        private void OnAsycnOperationCompleteEventEvent()
        {
            CommonSceneManager.Instance.OnAsycnOperationCompleteEvent -= OnAsycnOperationCompleteEventEvent;

            CommonSceneManager.Instance.OpenLoadedScene();
        }
    }
}