using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _playerMoveingSpeed = 5f;
        [SerializeField] private PlayerPath _playerPath;

        private int _currentWaypointIndex = 0;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _currentWaypointIndex == 0)
            {
                MoveTo(GetCurrentWaypoint());
            }
            if (!_playerPath.IsEnemyInWaypoint(_currentWaypointIndex))
            {
                MoveTo(GetCurrentWaypoint());
                NextWaypoint();
            }
        }

        private void NextWaypoint()
        {
            _currentWaypointIndex = _playerPath.GetNextIndex(_currentWaypointIndex);
        }

        private Vector3 GetCurrentWaypoint()
        {
            return _playerPath.GetWaypoint(_currentWaypointIndex);
        }

        private void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
            GetComponent<NavMeshAgent>().speed = _playerMoveingSpeed;
            GetComponent<NavMeshAgent>().isStopped = false;
        }
    }
}
