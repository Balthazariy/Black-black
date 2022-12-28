using UnityEngine;

namespace Balthazariy.Utilities
{
    public class AppVersionChecker : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI _versionText;

        private void Awake()
        {
            _versionText.text = "VERSION - " + Application.version.ToString();
        }
    }
}