using Balthazariy.Managers;
using Balthazariy.Objects.IObjects;
using Balthazariy.Settings;
using UnityEngine;

namespace Balthazariy.Mono
{
    public class IObjectsPool : MonoBehaviour
    {
        public static IObjectsPool Instance { get; private set; }

        [SerializeField] private Transform _poolContainer;

        private ObjectPoolList _iObjectPool;

        private float _timeToAppearObject = 0.5f,
                      _currentTimeToAppearObject;
        private bool _startToShowObjects;

        private void Awake()
        {
            if (Instance != null) Destroy(this.gameObject);

            if (Instance == null)
                Instance = this;
        }

        private void Start()
        {
            _iObjectPool = new ObjectPoolList(AppConstants.MAX_ITEMS_ON_SCENE, _poolContainer, true);

            foreach (var item in _iObjectPool.Pool)
            {
                item.ObjectPickUpEvent += ObjectPickUpEventHandler;
            }

            _currentTimeToAppearObject = _timeToAppearObject;
        }

        private void Update()
        {
            if (!GameplayManager.Instance.IsGameStarted) return;

            if (_startToShowObjects)
            {
                _currentTimeToAppearObject -= Time.deltaTime;

                if (_currentTimeToAppearObject <= 0)
                {
                    IObject io = _iObjectPool.GetFreeElement() as IObject;

                    if (io == null)
                    {
                        _startToShowObjects = false;
                        return;
                    }

                    io.SetObjectActive(true);
                    _currentTimeToAppearObject = _timeToAppearObject;
                }
            }
        }

        private void ObjectPickUpEventHandler()
        {
            _startToShowObjects = true;
        }
    }
}