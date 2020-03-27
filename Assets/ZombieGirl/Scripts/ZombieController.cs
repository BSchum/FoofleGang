using FoofleGang.Movement;
using UnityEngine;

namespace FoofleGang.Enemies
{
    [RequireComponent(typeof(IMotor))]
    public class ZombieController : MonoBehaviour
    {
        [Header("Movement Stats")]
        [SerializeField] private float _speed;
        [Tooltip("Need to be set when zombie is spawned")]
        [SerializeField] private Transform _target;
        [SerializeField] private float _range;

        [Header("Animation")]
        [SerializeField] private Animator _animator;

        private IMotor _motor;
        private bool _isWalking = true;
        #region Unity Methods
        private void Awake()
        {
            _motor = GetComponent<IMotor>();
        }

        public void Update()
        {
            if(Vector3.Distance(this.gameObject.transform.position, _target.gameObject.transform.position) > _range)
            {
                _motor.Move(Vector3.forward, _speed);
                _isWalking = true;
            }
            else
            {
                _isWalking = false;
            }
            _animator.SetBool(ZombieAnimationConstants.IsWalkingParamName, _isWalking);
            _motor.Look(_target);
        }
        #endregion
    }
}

