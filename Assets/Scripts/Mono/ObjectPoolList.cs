using Chebureck.Objects.IObjects;
using Chebureck.Utilities.Gameplay;
using System.Collections.Generic;
using UnityEngine;

namespace Chebureck.Mono
{
    public class ObjectPoolList
    {
        public BaseInteractableObjects iObject { get; }
        private Transform _container;

        public List<BaseInteractableObjects> Pool { get; private set; }

        private RandomDrop _randomItemDrop;

        public ObjectPoolList(int count, Transform container, bool activeByDefault)
        {
            _randomItemDrop = new RandomDrop();
            _container = container;
            CreatePool(count, activeByDefault);
        }

        public void CreatePool(int count, bool activeByDefault)
        {
            Pool = new List<BaseInteractableObjects>();

            for (int i = 0; i < count; i++)
                CreateObject(activeByDefault);
        }

        private BaseInteractableObjects CreateObject(bool isActiveByDefault)
        {
            var randomDrop = _randomItemDrop.GetDrop();
            var go = MonoBehaviour.Instantiate(randomDrop.prefab, _container).GetComponent<BaseInteractableObjects>();
            go.Init(randomDrop);
            go.gameObject.SetActive(isActiveByDefault);
            Pool.Add(go);
            return go;
        }

        public bool HasFreeElement(out BaseInteractableObjects element)
        {
            foreach (var mono in Pool)
            {
                if (!mono.GetIObject().activeInHierarchy)
                {
                    element = mono;
                    mono.SetObjectActive(true);
                    return true;
                }
            }
            element = null;
            return false;
        }

        public BaseInteractableObjects GetFreeElement()
        {
            if (HasFreeElement(out var element))
                return element;

            return null;
        }
    }
}