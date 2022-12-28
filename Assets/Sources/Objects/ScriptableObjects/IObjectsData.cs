using Balthazariy.Settings;
using System;
using UnityEngine;

namespace Balthazariy.Objects.ScriptableObjects
{
    [CreateAssetMenu(fileName = "IObjectsData", menuName = "Chebureck/IObjectsData", order = 3)]
    public class IObjectsData : ScriptableObject
    {
        public IObjectBasic[] objectBasics;

        public IObjectBasic GetBasicObjectById(int id)
        {
            foreach (var item in objectBasics)
                if (item.id == id)
                    return item;

            return null;
        }
    }

    public class IObjectInfo
    {
        public int id;
        public GameObject prefab;
        public float spawnYPosition;
        public float weight;
        public IObjectTypeEnumerators type;
    }

    [Serializable]
    public class IObjectBasic : IObjectInfo
    {

    }
}