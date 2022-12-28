using Balthazariy.Controllers;
using Balthazariy.Objects.ScriptableObjects;
using UnityEngine;

namespace Balthazariy.Managers
{
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager Instance { get; private set; }

        public bool IsGameStarted { get; private set; }
        public bool IsGamePaused { get; private set; }

        public IObjectsData IObjectData { get; private set; }

        private void Awake()
        {
            if (Instance != null) Destroy(this.gameObject);

            if (Instance == null)
                Instance = this;
        }

        private void Start()
        {
            IObjectData = LoadObjectsManager.Instance.GetObjectByPath<IObjectsData>("ScriptableObjects/IObjectsData");

            PauseController.Instance.IsGamePausedEvent += IsGamePausedEventHandler;
        }

        public void StartGameplay()
        {
            IsGameStarted = true;
        }

        public void StopGameplay()
        {
            IsGameStarted = false;
        }

        private void IsGamePausedEventHandler(bool isPaused)
        {
            IsGamePaused = isPaused;
        }
    }
}