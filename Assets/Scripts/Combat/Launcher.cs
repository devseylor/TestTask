using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Pool;

namespace RPG.Combat
{
    public class Launcher : MonoBehaviour
    {   
        [SerializeField] Bullet _bulletPrefab;
        [SerializeField] Transform _launchPosition;
        [SerializeField] private float _fireRate = 1;
        private Vector3 _launchDirection;
        private IObjectPool<Bullet> _bulletPool;

        private bool CanShoot = true;

        private void Awake()
        {
            _bulletPool = new ObjectPool<Bullet>(
                CreateBullet,
                OnGet,
                OnRelease,
                OnDestroyExtraBullet,
                maxSize:10
                );
        }

        private Bullet CreateBullet()
        {
            Bullet bullet = Instantiate(_bulletPrefab, _launchPosition.position, Quaternion.identity);
            bullet.SetPool(_bulletPool);
            return bullet;
        }

        private void OnGet(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
            //StartCoroutine(bullet.ReleaseAfterTime());
            bullet.transform.position = _launchPosition.position;
            bullet.gameObject.transform.LookAt(BulletLaunchDirection());
        }

        private void OnRelease(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        private void OnDestroyExtraBullet(Bullet bullet)
        {
            Destroy(bullet.gameObject);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && CanShoot)
            {
                _bulletPool.Get();
                CanShoot = false;
                StartCoroutine(FireRateTimer());
            }
        }

        public Vector3 BulletLaunchDirection()
        {
            return _launchDirection = MousePosition();
        }

        private Vector3 MousePosition()
        {
            Vector3 rayPosition;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                return rayPosition = raycastHit.point;
            }
            return rayPosition = ray.GetPoint(100);
        }

        private IEnumerator FireRateTimer()
        {
            yield return new WaitForSeconds(_fireRate);
            CanShoot = true;
        }
    }
}

