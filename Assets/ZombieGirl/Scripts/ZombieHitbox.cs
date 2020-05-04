using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoofleGang.Enemies
{
    public class ZombieHitbox : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _damageMultiplicater;
        private ZombieController _zombie;

        void Start()
        {
            _zombie = GetComponentInParent<ZombieController>();
        }

        public void TakeDamage(float damage)
        {
            _zombie.TakeDamage(damage * _damageMultiplicater);
        }
    }
}