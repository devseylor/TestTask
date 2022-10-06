using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        //[SerializeField] private float _playerMoveingSpeed = 5f;
        [SerializeField] private PlayerPath _playerPath;

        private int _currentWaypointIndex = 0;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _currentWaypointIndex == 0)
            {
                MoveTo(GetCurrentWaypointPosition());
            }
            if (!_playerPath.IsEnemyInWaypoint(_currentWaypointIndex))
            {
                NextWaypoint();
                MoveTo(GetCurrentWaypointPosition());
            }
            UpdateAnimator();
        }

        private void NextWaypoint()
        {
            _currentWaypointIndex = _playerPath.GetNextIndex(_currentWaypointIndex);
        }

        private Vector3 GetCurrentWaypointPosition()
        {
            return _playerPath.GetWaypoint(_currentWaypointIndex);
        }

        public int GetCurrentWaypointIndex()
        {
            return _currentWaypointIndex;
        }
            

        private void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
            //GetComponent<NavMeshAgent>().speed = _playerMoveingSpeed;
            GetComponent<NavMeshAgent>().isStopped = false;
        }
        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed",speed);
        }
    }
}
