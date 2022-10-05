using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat 
{
    public class Launcher : MonoBehaviour
    {
        [SerializeField] Bullet _bullet;
        [SerializeField] Transform _launchPosition;

        private Vector3 _launchDirection;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            Instantiate(_bullet, _launchPosition.position, Quaternion.identity);
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
    }
}

