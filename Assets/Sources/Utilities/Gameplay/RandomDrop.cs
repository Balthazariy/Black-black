using Balthazariy.Managers;
using Balthazariy.Objects.ScriptableObjects;

namespace Balthazariy.Utilities.Gameplay
{
    public class RandomDrop
    {
        private float totalWeight;

        public RandomDrop()
        {
            GetTotalWeight();
        }

        private void GetTotalWeight()
        {
            foreach (var item in GameplayManager.Instance.IObjectData.objectBasics)
            {
                totalWeight += item.weight;
            }
        }

        public IObjectBasic GetDrop()
        {
            float roll = UnityEngine.Random.Range(0f, totalWeight);

            foreach (var item in GameplayManager.Instance.IObjectData.objectBasics)
            {
                if (item.weight >= roll)
                    return item;

                roll -= item.weight;
            }

            throw new System.Exception("Reward generation exaption!");
        }
    }
}