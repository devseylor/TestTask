using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using RPG.EnemyBehaviour;

namespace RPG.Combat 
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _damage = 20;
        private Launcher _launcher;
        private IObjectPool<Bullet> _bulletPool;

        public void SetPool(IObjectPool<Bullet> pool)
        {
            _bulletPool = pool;
        }

        private void Awake()
        {
            _launcher = FindObjectOfType<Launcher>();

        }

        private void Start()
        {
            transform.LookAt(_launcher.BulletLaunchDirection());
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            _bulletPool.Release(this);
            if (other.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy>().TakeDamage(_damage);
            }
        }

        //public IEnumerator ReleaseAfterTime()
        //{
        //    yield return new WaitForSeconds(5f);
        //    _bulletPool.Release(this);
        //}
    }
}


