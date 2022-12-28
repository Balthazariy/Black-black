using Balthazariy.Managers;
using Balthazariy.Settings;
using System.Collections.Generic;
using UnityEngine;

namespace Balthazariy.Mono
{
    public class WhiteListObjects : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _whiteListedObjects = new List<GameObject>();

        private void Start()
        {
            _whiteListedObjects.ForEach(x => x.SetActive(false));
            CommonSceneManager.Instance.OnSceneLoadedEvent += OnSceneLoadedEventHandler;
        }

        private void OnSceneLoadedEventHandler(SceneNameEnumerators sceneNameEnumerators)
        {
            switch (sceneNameEnumerators)
            {
                case SceneNameEnumerators.MainMenuScene:
                case SceneNameEnumerators.GameplayScene:
                    _whiteListedObjects.ForEach(x => x.SetActive(true));
                    break;
                default:
                    _whiteListedObjects.ForEach(x => x.SetActive(false));
                    break;
            }
        }
    }
}