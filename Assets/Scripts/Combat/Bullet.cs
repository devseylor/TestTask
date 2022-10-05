using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        private Launcher _launcher;
        
        private void Awake()
        {
            _launcher = FindObjectOfType<Launcher>();
        }

        private void Start()
        {
            transform.LookAt(_launcher.BulletLaunchDirection());
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    Destroy(gameObject);
        //}

        private void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}
