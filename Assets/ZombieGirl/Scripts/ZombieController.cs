using FoofleGang.Movement;
using UnityEngine;

namespace FoofleGang.Enemies
{
    [RequireComponent(typeof(IMotor))]
    public class ZombieController : MonoBehaviour, IDamageable
    {
        [Header("Health Stats")]
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;
        [Header("Movement Stats")]
        [SerializeField] private float _speed;
        [Tooltip("Need to be set when zombie is spawned")]
        [SerializeField] private Transform _target;
        [SerializeField] private float _range;
        private int zombiePower = 15;
        private float hitSpeed = 1.6f;
        private float spawnDelta = 0.0f;

        [Header("Animation")]
        [SerializeField] private Animator _animator;

        private IMotor _motor;
        private bool _isWalking = true;
        #region Unity Methods
        private void Awake()
        {
            _motor = GetComponent<IMotor>();
            this._animator = gameObject.GetComponentInChildren<Animator>();
        }

        public void Update()
        {
            spawnDelta += Time.deltaTime;
            if (Vector3.Distance(this.gameObject.transform.position, _target.gameObject.transform.position) > _range)
            {
                _motor.Move(Vector3.forward, _speed);
                _isWalking = true;
            }
            else
            {
                _isWalking = false;
                if(spawnDelta >= hitSpeed)
                {
                    HitPlayer(zombiePower);
                    spawnDelta = 0.0f;
                }
            }
            _animator.SetBool(ZombieAnimationConstants.IsWalkingParamName, _isWalking);
            _motor.Look(_target);
        }
        #endregion

        public void SetSpeed(float speed)
        {
            this._speed = speed;
        }

        public void SetTarget(Transform target)
        {
            this._target = target;
            this._target.position = new Vector3(target.position.x, GlobalVariable.Instance.planeY, target.position.z);
        }
        public void SetRange(float range)
        {
            this._range = range;
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
            Debug.Log($"{gameObject.name} a pris {damage}, il lui reste {_health} PV");

            if (_health <= 0)
            {
                Destroy(this.gameObject);
                GlobalVariable.Instance.gameScore += GameManager.GetGameDifficulty(GlobalVariable.Instance.difficulty) * 10;
            }
        }

        private void HitPlayer(int damage)
        {
            GlobalVariable.Instance.player.TakeDamage(damage);
            Debug.Log($"Player a pris {damage}, il lui reste {GlobalVariable.Instance.player.getHealth()} PV");
        }
    }
}

