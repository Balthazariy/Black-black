using Chebureck.Managers;
using UnityEngine;

namespace Chebureck.Objects.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] Utilities.Gameplay.Joysticks.Joystick _joystick;
        [SerializeField] private Rigidbody _rigidbody;
        private float _speed = 200f;

        private Vector3 _input;

        private void GetInput()
        {
#if UNITY_EDITOR
            _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
#endif

            //#if !UNITY_EDITOR
            //            _input = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
            //#endif
        }

        private void PlayerMove()
        {
            _rigidbody.velocity = _input * _speed * Time.deltaTime;
        }

        private void Update()
        {
            if (!GameplayManager.Instance.IsGameStarted) return;

            GetInput();
        }

        private void FixedUpdate()
        {
            if (!GameplayManager.Instance.IsGameStarted) return;

            PlayerMove();
        }
    }
}