using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Attributes 
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _healthPoint;

        [SerializeField] private bool _isDead = false;

        private float _healthPointsAtStart;

        private void Start()
        {
            _healthPointsAtStart = _healthPoint;
        }

        public void TakeDamage(float damage)
        {
            _healthPoint = Mathf.Max(_healthPoint - damage, 0);

            if (_healthPoint == 0)
            {
                Die();
            }
        }

        public float GetFraction()
        {
            return _healthPoint / _healthPointsAtStart;
        }

        private void Die()
        {
            if (_isDead) return;
            _isDead = true;
            StartCoroutine(RagdallDilay());
        }

        public bool IsAlive()
        {
            return _isDead;
        }

        IEnumerator RagdallDilay()
        {
            GetComponent<Rigidbody>().AddForce(100f * Vector3.up);
            yield return new WaitForSeconds(0.3f);
            GetComponent<RagdollController>().TurnOnRagdall();
        }
    }
}


