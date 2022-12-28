using UnityEngine;

namespace Balthazariy.Objects.Player
{
    public class Player : MonoBehaviour
    {
        public static Player Instance { get; private set; }

        public Rigidbody Rigidbody { get; private set; }
        public Collider Collider { get; private set; }
        public GameObject SelfObject { get; private set; }
        public Transform Transform => SelfObject?.transform;
        public Transform HoleDownObject { get; private set; }

        private void Awake()
        {
            if (Instance != null) Destroy(this.gameObject);

            if (Instance == null)
                Instance = this;
        }

        private void Start()
        {
            SelfObject = gameObject;

            Collider = SelfObject.GetComponent<Collider>();
            Rigidbody = SelfObject.GetComponent<Rigidbody>();

            HoleDownObject = Transform.Find("HoleDownObject");
        }
    }
}