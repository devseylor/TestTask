using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class PlayerPath : MonoBehaviour
    {
        [SerializeField] private float _enemyInWaypointRadius;
        Vector3 _plusPosition = new Vector3(0, 0, 5);
        private void OnDrawGizmos()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(GetWaypoint(i), 0.5f);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
                Gizmos.DrawWireSphere(GetWaypoint(i) + _plusPosition, _enemyInWaypointRadius);
                IsEnemyInWaypoint(i);
            }
        }

        public bool IsEnemyInWaypoint(int i)
        {
            RaycastHit[] hits = Physics.SphereCastAll(GetWaypoint(i) + _plusPosition, _enemyInWaypointRadius, Vector3.up, 0);
            foreach(RaycastHit hit in hits)
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if(enemy != null && !enemy.IsAlive())
                {
                    return true;
                }
            }
            return false;
        }

        public int GetNextIndex(int i)
        {
            if (i + 1 == transform.childCount) return i;
            return i + 1;
        }

        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }
    }
}
