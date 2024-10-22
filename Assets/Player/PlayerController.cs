using UnityEngine;

namespace Invader.Player
{
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(PlayerWeapon))]
    [RequireComponent(typeof(PlayerAbility))]
    public class PlayerController : MonoBehaviour
    {
        public Vector2 Movement { get; set; }
        public bool IsFireButtonPressed { get; set; }
        public bool IsSpecialButtonPressed { get; set; }
        
        private Movement _movement;
        private PlayerWeapon _playerWeapon;
        private PlayerAbility _playerAbility;
        
        private void Awake()
        {
            TryGetComponent(out _movement);
            TryGetComponent(out _playerWeapon);
            TryGetComponent(out _playerAbility);
        }
        
        private void Update()
        {
            _movement.Move(new Vector3(Movement.x, 0.0f, Movement.y));
            
            if (IsFireButtonPressed)
            {
                _playerWeapon.Fire();
            }

            if (IsSpecialButtonPressed)
            {
                _playerAbility.Use();
                IsSpecialButtonPressed = false;
            }
        }
    }
}
