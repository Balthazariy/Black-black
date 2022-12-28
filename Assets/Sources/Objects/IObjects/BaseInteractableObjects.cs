using Balthazariy.Objects.ScriptableObjects;
using Balthazariy.Utilities;
using System;
using UnityEngine;

namespace Balthazariy.Objects.IObjects
{
    public class BaseInteractableObjects : MonoBehaviour
    {
        public event Action ObjectPickUpEvent;

        protected GameObject _selfObject;
        protected Transform _transform => _selfObject?.transform;
        protected Rigidbody _rigidbody;
        protected Collider _collider;
        protected OnBehaviourHandler _onBehaviourHandler;

        private Transform _playerTransform;

        private bool _isPlayerDetected;

        private IObjectInfo _info;

        #region Move Variables
        public AnimationCurve curve;
        private Vector3 end;

        private Vector3 start;
        private float time = 0f;
        #endregion

        public virtual void Init(IObjectInfo info)
        {
            _info = info;

            _selfObject = gameObject;

            _rigidbody = gameObject.GetComponent<Rigidbody>();
            _collider = gameObject.GetComponent<Collider>();
            _onBehaviourHandler = gameObject.GetComponent<OnBehaviourHandler>();

            _playerTransform = Player.Player.Instance.Transform;

            _onBehaviourHandler.TriggerEntered += TriggerEnteredHandler;

            _isPlayerDetected = false;

            SetObjectActive(false);
            SetPosition();
        }

        public void ObjectPicked()
        {
            SetObjectActive(false);
            SetPosition();
        }

        public void SetObjectActive(bool isActive) => gameObject.SetActive(isActive);
        public GameObject GetIObject() => _selfObject;

        public void SetPosition()
        {
            int x1 = -50;
            int x2 = 50;
            int z1 = -50;
            int z2 = 50;

            float randX = UnityEngine.Random.Range(x1, x2);
            float randY = UnityEngine.Random.Range(z1, z2);

            transform.position = new Vector3(randX, _info.spawnYPosition, randY);
            _collider.isTrigger = false;
        }

        private void Update()
        {
            if (_isPlayerDetected)
            {
                time += Time.deltaTime;
                Vector3 pos = Vector3.Lerp(start, end, time);
                pos.y += curve.Evaluate(time);
                transform.position = pos;
            }
        }

        public void TriggerEnteredHandler(Collider collider)
        {
            if (collider.gameObject.name == "Player")
            {
                if (_info.type == Settings.IObjectTypeEnumerators.PermanentBooster)
                    Utilities.Logger.Log("You pick up the PermanentBooster", Settings.LogTypeEnumerators.Info);

                if (_info.type == Settings.IObjectTypeEnumerators.TimeBooster)
                    Utilities.Logger.Log("You pick up the TimeBooster", Settings.LogTypeEnumerators.Info);

                InitEnteredVariables();

                _isPlayerDetected = true;
                _collider.isTrigger = true;
            }

            if (collider.gameObject.name == "HoleDownLimitOBject")
            {
                ObjectPicked();
                ObjectPickUpEvent?.Invoke();
                _isPlayerDetected = false;
            }
        }

        private void InitEnteredVariables()
        {
            start = _transform.position;
            end = Player.Player.Instance.HoleDownObject.transform.position;
        }
    }
}