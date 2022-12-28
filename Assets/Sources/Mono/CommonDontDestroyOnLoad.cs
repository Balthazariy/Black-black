using UnityEngine;

namespace Balthazariy.Mono
{
    public static class CommonDontDestroyOnLoad
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Execute() => Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load("Prefabs/Common/CommonDontDestroyOnLoad")));
    }
}