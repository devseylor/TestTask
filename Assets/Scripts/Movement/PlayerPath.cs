using UnityEngine;
using RPG.Attributes;

namespace RPG.Movement
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
            }
        }

        public bool IsEnemyInWaypoint(int i)
        {
            RaycastHit[] hits = Physics.SphereCastAll(GetWaypoint(i) + _plusPosition, _enemyInWaypointRadius, Vector3.up, 0);
            foreach(RaycastHit hit in hits)
            {
                Health enemy = hit.collider.GetComponent<Health>();
                if(enemy && !enemy.IsAlive())
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

        public int CountWaypoints()
        {
            return transform.childCount -1;
        }

        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }
    }
}
