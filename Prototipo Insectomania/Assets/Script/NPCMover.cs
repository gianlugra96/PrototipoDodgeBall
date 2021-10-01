using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class NPCMover : MonoBehaviour
    {
        [SerializeField] private MeshCollider floorCollider;

        private NavMeshAgent _navMeshAgent;


        void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();


            var dest = RandomPointInBounds(floorCollider.bounds);
            _navMeshAgent.SetDestination(dest);
        }


        void Update()
        {
            if (TargetReached())
            {
                var dest = RandomPointInBounds(floorCollider.bounds);
                _navMeshAgent.SetDestination(dest);
            }
        }

        private bool TargetReached()
        {
            if (!_navMeshAgent.pathPending)
                if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
                    if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude <= 0f)
                        return true;

            return false;
        }

        public static Vector3 RandomPointInBounds(Bounds bounds)
        {
            return new Vector3(
                Random.Range(bounds.min.x + 0.2f, bounds.max.x - 0.2f),
                0.01f,
                Random.Range(bounds.min.z + 0.2f, bounds.max.z - 0.2f)
            );
        }
    }
}