using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.EnemyBehaviour 
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _healthPoint;

        [SerializeField] private bool _isDead = false;

        public void TakeDamage(float damage)
        {
            _healthPoint = Mathf.Max(_healthPoint - damage, 0);

            if (_healthPoint == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (_isDead) return;
            _isDead = true;
            //Add Rigdoll
        }

        public bool IsAlive()
        {
            return _isDead;
        }
    }
}


